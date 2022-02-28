using CoreERP.Model;
using Dapper;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoreERP.Data.Repositories
{
    public class PurchaseDetailsRepository : IPurchaseDetailsRepository
    {
        private SqlConfiguration _connectionString;

        public PurchaseDetailsRepository(SqlConfiguration connectionStringg)
        {
            _connectionString = connectionStringg;
        }

        protected NpgsqlConnection dbConnection()
        {
            return new NpgsqlConnection(_connectionString.ConnectionString);
        }

        public async Task<bool> DeletePurchaseDetail(int id)
        {
            var db = dbConnection();

            var sql = @"DELETE FROM public.compra_detalles
                        WHERE id_compra_detalle=@Id;";

            var result = await db.ExecuteAsync(sql, new { Id = id });

            return result > 0;
        }

        public async Task<IEnumerable<PurchaseDetails>> GetAllPurchaseDetails()
        {
            var db = dbConnection();
            var sql = @"SELECT id_compra, factura, fecha, estado, codigo, producto, cantidad, monto, imagen, proveedor, vendedor, moneda, total_compra, monto_total, id_compra_detalle
                        FROM public.v_impresion_compras";

            return await db.QueryAsync<PurchaseDetails>(sql, new { });
        }

        public async Task<IEnumerable<PurchaseDetails>> GetPurchaseDetails(int id)
        {
            try
            {  
            var db = dbConnection();
            var sql = @"SELECT id_compra, factura, fecha, estado, codigo, producto, cantidad, monto, imagen, proveedor, vendedor, moneda, total_compra, monto_total, id_compra_detalle, id_producto, total
                        FROM public.v_impresion_compras
                        where id_compra = @Id";


            return await db.QueryAsync<PurchaseDetails>(sql, new { Id = id });

            }
            catch( Exception ex)
            {
                throw ex;
            }
        }

     



        public async Task<bool> InsertPurchaseDetail(PurchaseDetails purchaseDetail)
        {
            
            Product product;
            Currency currency;
            Purchase purchase;

            try
            {
                var db = dbConnection();

                var sql_compra = "select * from compras c  where id_compra =@id_compra";
                purchase = await db.QueryFirstOrDefaultAsync<Purchase>(sql_compra, new
                {
                    purchaseDetail.id_compra
                });


                var sql_producto = "select * from productos d where d.id_producto = @id_producto";
                product = await db.QueryFirstOrDefaultAsync<Product>(sql_producto, new
                {
                    purchaseDetail.id_producto
                }
                );

               
                purchaseDetail.monto = product.costo;


               
                var sql_moneda = "select cotizacion from  monedas m where m.id_moneda =@id_moneda";
                currency = await db.QueryFirstOrDefaultAsync<Currency>(sql_moneda, new
                {
                    product.id_moneda
                }
                );

                if (product.id_moneda != purchase.id_moneda)
                {
                    purchaseDetail.monto = purchaseDetail.monto * currency.cotizacion;
                }

                purchaseDetail.total = purchaseDetail.monto * purchaseDetail.cantidad;

                var sql = @"INSERT INTO public.compra_detalles
                                (id_compra, cantidad, descripcion, monto, id_producto, total)
                                VALUES(@id_compra, @cantidad, @producto, @monto, @id_producto, @total);";

                var result = await db.ExecuteAsync(sql, new
                {
                    purchaseDetail.id_compra,
                    purchaseDetail.cantidad,
                    purchaseDetail.producto,
                    purchaseDetail.monto,
                    purchaseDetail.id_producto,
                    purchaseDetail.total
                }
                );

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> UpdatePurchaseDetail(PurchaseDetails purchaseDetail)
        {
           
            Product product;

            try
            {
                var db = dbConnection();

                var sql_producto = "select costo, precio from productos d where d.id_producto = @id_producto";
                product = await db.QueryFirstOrDefaultAsync<Product>(sql_producto, new
                {
                    purchaseDetail.id_producto
                }
                );

             
                purchaseDetail.monto = product.costo;

                purchaseDetail.total = purchaseDetail.monto * purchaseDetail.cantidad;

                var sql = @"UPDATE public.compra_detalles
                                SET id_compra=@id_compra, cantidad=@cantidad, descripcion=@descripcion, monto=@monto, id_producto=@id_producto, total=@total
                                WHERE id_compra_detalle=@id_compra_detalle;";

                var result = await db.ExecuteAsync(sql, new
                {
                    purchaseDetail.id_compra,
                    purchaseDetail.id_producto,                  
                    purchaseDetail.cantidad,
                    purchaseDetail.monto,
                    purchaseDetail.descripcion,
                    purchaseDetail.total,
                    purchaseDetail.id_compra_detalle
                }
                );

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
