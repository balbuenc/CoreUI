using CoreERP.Model;
using Dapper;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoreERP.Data.Repositories
{
    public class BankRepository : IBankRepository
    {

        private SqlConfiguration _connectionString;

        public BankRepository(SqlConfiguration connectionStringg)
        {
            _connectionString = connectionStringg;
        }

        protected NpgsqlConnection dbConnection()
        {
            return new NpgsqlConnection(_connectionString.ConnectionString);
        }

        public async Task<bool> DeleteBank(int id)
        {
            try
            {
                var db = dbConnection();

                var sql = @"DELETE from bancos
                        WHERE id_banco = @Id ";

                var result = await db.ExecuteAsync(sql, new { Id = id });

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<IEnumerable<Bank>> GetAllBanks()
        {
            try
            {
                var db = dbConnection();
                var sql = @"SELECT b.id_banco, b.banco, b.id_ciudad, b.nro_telefono, b.oficial, b.email, c.ciudad 
                            FROM public.bancos b
                            left outer join ciudades c on c.id_ciudad = b.id_ciudad order by b.id_banco asc";

                var result = await db.QueryAsync<Bank>(sql, new { });

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Bank> GetBankDetails(int id)
        {
            try
            {
                var db = dbConnection();
                var sql = "select * from bancos  where id_banco = @Id";


                return await db.QueryFirstOrDefaultAsync<Bank>(sql, new { Id = id });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> InsertBank(Bank bank)
        {
            try
            {
                var db = dbConnection();

                var sql = @"INSERT INTO public.bancos
                            (banco, id_ciudad, nro_telefono, oficial, email)
                            VALUES(@banco, @id_ciudad, @nro_telefono, @oficial, @email);";

                var result = await db.ExecuteAsync(sql, new
                {
                    bank.banco,
                    bank.id_ciudad,
                    bank.nro_telefono,
                    bank.oficial,
                    bank.email
                }
                );

                return result > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> UpdateBank(Bank bank)
        {
            try
            {
                var db = dbConnection();

                var sql = @"UPDATE public.bancos
                            SET id_ciudad=@id_ciudad, nro_telefono=@nro_telefono, oficial=@oficial, email= @email,banco = @banco
                            WHERE id_banco=@id_banco;";

                var result = await db.ExecuteAsync(sql, new
                {
                    bank.banco,
                    bank.id_ciudad,
                    bank.nro_telefono,
                    bank.oficial,
                    bank.email,
                    bank.id_banco
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
