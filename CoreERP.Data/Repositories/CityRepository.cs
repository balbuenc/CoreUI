using CoreERP.Model;
using Dapper;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoreERP.Data.Repositories
{
    public class CityRepository : ICityRepository
    {
        private SqlConfiguration _connectionString;

        public CityRepository(SqlConfiguration connectionStringg)
        {
            _connectionString = connectionStringg;
        }

        protected NpgsqlConnection dbConnection()
        {
            return new NpgsqlConnection(_connectionString.ConnectionString);
        }

        public async Task<bool> DeleteCity(int id)
        {
            var db = dbConnection();

            var sql = @"DELETE from ciudades
                        WHERE id_ciudad = @Id ";

            var result = await db.ExecuteAsync(sql, new { Id = id });

            return result > 0;
        }

        public async Task<IEnumerable<City>> GetAllCities()
        {
            var db = dbConnection();
            var sql = @"select c.id_ciudad, c.ciudad, c.id_pais, p.pais 
                        from ciudades c
                        inner
                        join paises p on c.id_pais = p.id_pais
                        order by p.pais, c.ciudad asc;";

            return await db.QueryAsync<City>(sql, new { });
        }

        public  async Task<City> GetCityDetails(int id)
        {
            var db = dbConnection();
            var sql = "select * from ciudades  where id_ciudad = @Id";


            return await db.QueryFirstOrDefaultAsync<City>(sql, new { Id = id });
        }

        public async Task<bool> InsertCity(City city)
        {
            var db = dbConnection();

            var sql = @"INSERT INTO public.ciudades (id_pais, ciudad) VALUES(@id_pais, @ciudad);";

            var result = await db.ExecuteAsync(sql, new
            {
                city.id_pais,
                city.ciudad
            }
            );

            return result > 0;
        }

        public async Task<bool> UpdateCity(City city)
        {
            var db = dbConnection();

            var sql = @"UPDATE public.ciudades
                        set ciudad =@ciudad
                        where id_ciudad=@id_ciudad;";

            var result = await db.ExecuteAsync(sql, new
            {
                city.id_ciudad,
                city.ciudad
            }
            );

            return result > 0;
        }
    }
}
