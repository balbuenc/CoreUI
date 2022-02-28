using CoreERP.Model;
using Dapper;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoreERP.Data.Repositories
{
    public class AccountTypeRepository : IAccountTypeRepository
    {
        private SqlConfiguration _connectionString;

        public AccountTypeRepository(SqlConfiguration connectionStringg)
        {
            _connectionString = connectionStringg;
        }

        protected NpgsqlConnection dbConnection()
        {
            return new NpgsqlConnection(_connectionString.ConnectionString);
        }

        public async Task<bool> DeleteAccountType(int id)
        {
            try
            {
                var db = dbConnection();

                var sql = @"DELETE from tipos_cuenta
                        WHERE id_tipo_cuenta = @Id ";

                var result = await db.ExecuteAsync(sql, new { Id = id });

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<IEnumerable<AccountType>> GetAllAccountTypes()
        {
            try
            {
                var db = dbConnection();
                var sql = "select * from tipos_cuenta order by id_tipo_cuenta asc";

                var result = await db.QueryAsync<AccountType>(sql, new { });

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<AccountType> GetAccountTypeDetails(int id)
        {
            try
            {
                var db = dbConnection();
                var sql = "select * from tipos_cuenta  where id_tipo_cuenta = @Id";


                return await db.QueryFirstOrDefaultAsync<AccountType>(sql, new { Id = id });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> InsertAccountType(AccountType accountType)
        {
            try
            {
                var db = dbConnection();

                var sql = @"INSERT INTO public.tipos_cuenta (tipo_cuenta) VALUES(@tipo_cuenta);";

                var result = await db.ExecuteAsync(sql, new
                {
                    accountType.tipo_cuenta
                }
                );

                return result > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> UpdateAccountType(AccountType accountType)
        {
            try
            {
                var db = dbConnection();

                var sql = @"UPDATE public.tipos_cuenta
                            SET tipo_cuenta=@tipo_cuenta
                            where id_tipo_cuenta=@id_tipo_cuenta;";

                var result = await db.ExecuteAsync(sql, new
                {
                    accountType.id_tipo_cuenta,
                    accountType.tipo_cuenta
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
