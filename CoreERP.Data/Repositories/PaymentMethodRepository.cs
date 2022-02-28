using CoreERP.Model;
using Dapper;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoreERP.Data.Repositories
{
    public class PaymentMethodRepository : IPaymentMethodRepository
    {
        private SqlConfiguration _connectionString;

        public PaymentMethodRepository(SqlConfiguration connectionStringg)
        {
            _connectionString = connectionStringg;
        }

        protected NpgsqlConnection dbConnection()
        {
            return new NpgsqlConnection(_connectionString.ConnectionString);
        }

        public async Task<bool> DeletePaymentMethod(int id)
        {
            try
            {
                var db = dbConnection();

                var sql = @"DELETE from medios_pago
                        WHERE id_medio_pago = @Id ";

                var result = await db.ExecuteAsync(sql, new { Id = id });

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<IEnumerable<PaymentMethod>> GetAllPaymentMethods()
        {
            try
            {
                var db = dbConnection();
                var sql = "select * from medios_pago order by id_medio_pago asc";

                var result = await db.QueryAsync<PaymentMethod>(sql, new { });

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<PaymentMethod> GetPaymentMethodDetails(int id)
        {
            try
            {
                var db = dbConnection();
                var sql = "select * from medios_pago  where id_medio_pago = @Id";


                return await db.QueryFirstOrDefaultAsync<PaymentMethod>(sql, new { Id = id });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> InsertPaymentMethod(PaymentMethod method)
        {
            try
            {
                var db = dbConnection();

                var sql = @"INSERT INTO public.medios_pago (medio) VALUES(@medio);";

                var result = await db.ExecuteAsync(sql, new
                {
                    method.medio
                }
                );

                return result > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> UpdatePaymentMethod(PaymentMethod method)
        {
            try
            {
                var db = dbConnection();

                var sql = @"UPDATE public.medios_pago
                        set medio =@medio
                        where id_medio_pago=@id_medio_pago;";

                var result = await db.ExecuteAsync(sql, new
                {
                    method.id_medio_pago,
                    method.medio
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
