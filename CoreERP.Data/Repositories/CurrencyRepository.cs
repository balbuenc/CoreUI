using CoreERP.Model;
using Dapper;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoreERP.Data.Repositories
{
    public class CurrencyRepository : ICurrencyRepository
    {
        private SqlConfiguration _connectionString;

        public CurrencyRepository(SqlConfiguration connectionStringg)
        {
            _connectionString = connectionStringg;
        }

        protected NpgsqlConnection dbConnection()
        {
            return new NpgsqlConnection(_connectionString.ConnectionString);
        }

       

        public async Task<IEnumerable<Currency>> GetAllCurrencies()
        {
            var db = dbConnection();
            var sql = "select * from monedas";


            return await db.QueryAsync<Currency>(sql, new { });
        }

        public async Task<Currency> GetCurrencytDetails(int id)
        {
            var db = dbConnection();
            var sql = "select * from monedas where id_moneda = @Id";


            return await db.QueryFirstOrDefaultAsync<Currency>(sql, new { Id = id });
        }

        public async Task<bool> InsertCurrency(Currency currency)
        {
            var db = dbConnection();

            var sql = @"INSERT INTO public.monedas (moneda, simbolo, cotizacion) VALUES(@moneda,@simbolo,@cotizacion);";

            var result = await db.ExecuteAsync(sql, new
            {
                currency.moneda,
                currency.simbolo,
                currency.cotizacion
            }
            );

            return result > 0;
        }

        public async Task<bool> UpdateCurrency(Currency currency)
        {
            var db = dbConnection();

            var sql = @"UPDATE public.monedas
                        set moneda =@moneda,
                            simbolo=@simbolo,
                            cotizacion=@cotizacion
                        where id_moneda=@id_moneda;";

            var result = await db.ExecuteAsync(sql, new
            {
                currency.id_moneda,
                currency.moneda,
                currency.simbolo,
                currency.cotizacion
            }
            );

            return result > 0;
        }

        public async Task<bool> DeleteCurrency(int id)
        {
            var db = dbConnection();

            var sql = @"DELETE from monedas
                        WHERE id_moneda = @Id ";

            var result = await db.ExecuteAsync(sql, new { Id = id });

            return result > 0;
        }
    }
}
