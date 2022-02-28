using CoreERP.Model;
using Dapper;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoreERP.Data.Repositories
{
    public class CountryRepository : ICountryRepository
    {
        private SqlConfiguration _connectionString;

        public CountryRepository(SqlConfiguration connectionStringg)
        {
            _connectionString = connectionStringg;
        }

        protected NpgsqlConnection dbConnection()
        {
            return new NpgsqlConnection(_connectionString.ConnectionString);
        }

        public async Task<bool> DeleteCountry(int id)
        {
            var db = dbConnection();

            var sql = @"DELETE from paises
                        WHERE id_pais = @Id ";

            var result = await db.ExecuteAsync(sql, new { Id = id });

            return result > 0;
        }

        public async Task<IEnumerable<Country>> GetAllCountries()
        {
            var db = dbConnection();
            var sql = @"select p.id_pais, p.pais ,p.id_moneda, m.moneda 
                        from paises p
                        inner
                        join monedas m on p.id_moneda = m.id_moneda ";


            return await db.QueryAsync<Country>(sql, new { });
        }

        public async Task<Country> GetCountryDetails(int id)
        {
            var db = dbConnection();
            var sql = "select * from paises where id_pais = @Id";


            return await db.QueryFirstOrDefaultAsync<Country>(sql, new { Id = id });
        }

        public async Task<bool> InsertCountry(Country country)
        {
            var db = dbConnection();

            var sql = @"INSERT INTO public.paises (pais, id_moneda) VALUES(@pais,@id_moneda);";

            var result = await db.ExecuteAsync(sql, new
            {
                country.pais,
                country.id_moneda
            }
            );

            return result > 0;
        }

        public async Task<bool> UpdateCountry(Country country)
        {
            var db = dbConnection();

            var sql = @"UPDATE public.paises
                        set pais =@pais,
                            id_moneda=@id_moneda
                        where id_pais=@id_pais;";

            var result = await db.ExecuteAsync(sql, new
            {
                country.id_pais,
                country.pais,
                country.id_moneda
            }
            );

            return result > 0;
        }
    }
}
