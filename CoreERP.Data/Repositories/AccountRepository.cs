using CoreERP.Model;
using Dapper;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoreERP.Data.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private SqlConfiguration _connectionString;

        public AccountRepository(SqlConfiguration connectionStringg)
        {
            _connectionString = connectionStringg;
        }

        protected NpgsqlConnection dbConnection()
        {
            return new NpgsqlConnection(_connectionString.ConnectionString);
        }

        public async Task<bool> DeleteAccount(int id)
        {
            try
            {
                var db = dbConnection();

                var sql = @"DELETE from cuentas
                        WHERE id_cuenta = @Id ";

                var result = await db.ExecuteAsync(sql, new { Id = id });

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<IEnumerable<Account>> GetAllAccounts()
        {
            try
            {
                var db = dbConnection();
                var sql = @"select c.id_cuenta , c.id_tipo_cuenta , c.denominacion , c.id_banco , c.nro_cuenta , b.banco , tc.tipo_cuenta , c.id_moneda , m.moneda 
                                from cuentas c 
                                left outer join bancos b on b.id_banco = c.id_banco 
                                left outer join tipos_cuenta tc on tc.id_tipo_cuenta = c.id_tipo_cuenta 
                                left outer join monedas m on m.id_moneda = c.id_moneda 
                                order by c.denominacion  ";

                var result = await db.QueryAsync<Account>(sql, new { });

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Account> GetAccountDetails(int id)
        {
            try
            {
                var db = dbConnection();
                var sql = "select * from cuentas  where id_cuenta = @Id";


                return await db.QueryFirstOrDefaultAsync<Account>(sql, new { Id = id });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> InsertAccount(Account account)
        {
            try
            {
                var db = dbConnection();

                var sql = @"INSERT INTO public.cuentas
                            (id_tipo_cuenta, denominacion, id_banco, nro_cuenta,id_moneda)
                            VALUES(@id_tipo_cuenta, @denominacion, @id_banco, @nro_cuenta, @id_moneda);";

                var result = await db.ExecuteAsync(sql, new
                {
                    account.id_tipo_cuenta,
                    account.denominacion,
                    account.id_banco,
                    account.nro_cuenta,
                    account.id_moneda
                }
                );

                return result > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> UpdateAccount(Account account)
        {
            try
            {
                var db = dbConnection();

                var sql = @"UPDATE public.cuentas
                            SET id_tipo_cuenta=@id_tipo_cuenta, denominacion=@denominacion, id_banco=@id_banco, nro_cuenta=@nro_cuenta, id_moneda=@id_moneda
                            WHERE id_cuenta=@id_cuenta;";

                var result = await db.ExecuteAsync(sql, new
                {
                    account.id_cuenta,
                    account.id_tipo_cuenta,
                    account.id_banco,
                    account.denominacion,
                    account.nro_cuenta,
                    account.id_moneda
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
