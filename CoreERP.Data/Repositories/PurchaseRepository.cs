using CoreERP.Model;
using Dapper;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoreERP.Data.Repositories
{
    public class PurchaseRepository : IPurchaseRepository
    {
        private SqlConfiguration _connectionString;

        public PurchaseRepository(SqlConfiguration connectionStringg)
        {
            _connectionString = connectionStringg;
        }

        protected NpgsqlConnection dbConnection()
        {
            return new NpgsqlConnection(_connectionString.ConnectionString);
        }

        public async Task<bool> DeletePurchase(int id)
        {
            try
            {
                var db = dbConnection();

                var sql = @"DELETE from compras
                        WHERE id_compra = @Id ";

                var result = await db.ExecuteAsync(sql, new { Id = id });

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<IEnumerable<Purchase>> GetAllPurchases()
        {
            try
            {
                var db = dbConnection();
                var sql = @"SELECT c.id_compra, c.factura, c.id_proveedor, c.importe, c.id_moneda, c.id_deposito, c.estado, c.id_condicion_venta, c.fecha, c.nro_orden_compra, c.id_funcionario,
                            p.proveedor, m.moneda , d.deposito, f.usuario as funcionario
                            FROM public.compras c
                            inner join public.proveedores p on c.id_proveedor = p.id_proveedor
                            inner join public.monedas m  on c.id_moneda = m.id_moneda
                            inner join public.depositos d on c.id_deposito  = d.id_deposito
                            inner join public.funcionarios f on c.id_funcionario = f.id_funcionario
                            order by c.id_compra desc;";

                var result = await db.QueryAsync<Purchase>(sql, new { });

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Purchase> GetPurchaseDetails(int id)
        {
            try
            {
                var db = dbConnection();
                var sql = @"SELECT c.id_compra, c.factura, c.id_proveedor, c.importe, c.id_moneda, c.id_deposito, c.estado, c.id_condicion_venta, c.fecha, c.nro_orden_compra, c.id_funcionario,
                            p.proveedor, m.moneda , d.deposito, f.usuario as funcionario
                            FROM public.compras c
                            inner join public.proveedores p on c.id_proveedor = p.id_proveedor
                            inner join public.monedas m  on c.id_moneda = m.id_moneda
                            inner join public.depositos d on c.id_deposito  = d.id_deposito
                            inner join public.funcionarios f on c.id_funcionario = f.id_funcionario where id_compra = @Id";


                return await db.QueryFirstOrDefaultAsync<Purchase>(sql, new { Id = id });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> InsertPurchase(Purchase compra)
        {
            try
            {
                var db = dbConnection();

                var sql = @"INSERT INTO public.compras
                            (factura, id_proveedor, importe, id_moneda, id_deposito, estado, id_condicion_venta, fecha, nro_orden_compra, id_funcionario)
                            VALUES(@factura, @id_proveedor, @importe, @id_moneda, @id_deposito, @estado, @id_condicion_venta, @fecha, @nro_orden_compra, @id_funcionario);";

                var result = await db.ExecuteAsync(sql, new
                {
                    compra.factura,
                    compra.id_proveedor,
                    compra.importe,
                    compra.id_moneda,
                    compra.id_deposito,
                    compra.estado,
                    compra.id_condicion_venta,
                    compra.fecha,
                    compra.nro_orden_compra,
                    compra.id_funcionario
                }
                );

                return result > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> UpdatePurchase(Purchase compra)
        {
            try
            {
                var db = dbConnection();

                var sql = @"UPDATE public.compras
                            SET factura=@factura, id_proveedor=@id_proveedor, importe=@importe, id_moneda=@id_moneda, id_deposito=@id_deposito, estado=@estado
                            WHERE id_compra=@id_compra;";

                var result = await db.ExecuteAsync(sql, new
                {
                    compra.id_compra,
                    compra.factura,
                    compra.id_proveedor,
                    compra.importe,
                    compra.id_moneda,
                    compra.id_deposito,
                    compra.estado
                }
                );

                return result > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
