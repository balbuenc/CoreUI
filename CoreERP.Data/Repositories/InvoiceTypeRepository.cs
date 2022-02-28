using CoreERP.Model;
using Dapper;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoreERP.Data.Repositories
{
    public class InvoiceTypeRepository : IInvoiceTypeRepository
    {
        private SqlConfiguration _connectionString;

        public InvoiceTypeRepository(SqlConfiguration connectionStringg)
        {
            _connectionString = connectionStringg;
        }

        protected NpgsqlConnection dbConnection()
        {
            return new NpgsqlConnection(_connectionString.ConnectionString);
        }

        public async Task<bool> DeleteInvoiceType(int id)
        {
            try
            {
                var db = dbConnection();

                var sql = @"DELETE from condicion_venta
                        WHERE id_condicion_venta = @Id ";

                var result = await db.ExecuteAsync(sql, new { Id = id });

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<IEnumerable<InvoiceType>> GetAllInvoiceTypes()
        {
            try
            {
                var db = dbConnection();
                var sql = "select * from condicion_venta order by id_condicion_venta asc";

                var result = await db.QueryAsync<InvoiceType>(sql, new { });

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<InvoiceType> GetInvoiceTypeDetails(int id)
        {
            try
            {
                var db = dbConnection();
                var sql = "select * from condicion_venta  where id_condicion_venta = @Id";


                return await db.QueryFirstOrDefaultAsync<InvoiceType>(sql, new { Id = id });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> InsertInvoiceType(InvoiceType invoiceType)
        {
            try
            {
                var db = dbConnection();

                var sql = @"INSERT INTO public.condicion_venta (condicion) VALUES(@condicion);";

                var result = await db.ExecuteAsync(sql, new
                {
                    invoiceType.condicion
                }
                );

                return result > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> UpdateInvoiceType(InvoiceType invoiceType)
        {
            try
            {
                var db = dbConnection();

                var sql = @"UPDATE public.condicion_venta
                        set condicion=@condicion
                        where id_condicion_venta=@id_condicion_venta;";

                var result = await db.ExecuteAsync(sql, new
                {
                    invoiceType.id_condicion_venta,
                    invoiceType.condicion
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
