using CoreERP.Model;
using Dapper;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoreERP.Data.Repositories
{
    public class NeighborhoodRepository : INeighborhoodRepository
    {

        private SqlConfiguration _connectionString;

        public NeighborhoodRepository(SqlConfiguration connectionStringg)
        {
            _connectionString = connectionStringg;
        }

        protected NpgsqlConnection dbConnection()
        {
            return new NpgsqlConnection(_connectionString.ConnectionString);
        }

        public async Task<bool> DeleteNeighborhood(int id)
        {
            var db = dbConnection();

            var sql = @"DELETE from barrios
                        WHERE id_barrio = @Id ";

            var result = await db.ExecuteAsync(sql, new { Id = id });

            return result > 0;
        }

        public async Task<IEnumerable<Neighborhood>> GetAllNeighborhoods()
        {
            var db = dbConnection();
            var sql = @"SELECT b.id_barrio, b.barrio, b.id_ciudad, c.ciudad 
                        FROM public.barrios b
                        inner join public.ciudades c on c.id_ciudad = b.id_ciudad;";

            return await db.QueryAsync<Neighborhood>(sql, new { });
        }

        public async Task<Neighborhood> GetNeighborhoodDetails(int id)
        {
            var db = dbConnection();
            var sql = "select * from barrios  where id_barrio = @Id";


            return await db.QueryFirstOrDefaultAsync<Neighborhood>(sql, new { Id = id });
        }

        public async Task<bool> InsertNeighborhood(Neighborhood neighborhood)
        {
            var db = dbConnection();

            var sql = @"INSERT INTO public.barrios (barrio, id_ciudad) VALUES(@barrio, @id_ciudad);";

            var result = await db.ExecuteAsync(sql, new
            {
                neighborhood.barrio,
                neighborhood.id_ciudad
            }
            );

            return result > 0;
        }

        public async Task<bool> UpdateNeighborhood(Neighborhood neighborhood)
        {
            var db = dbConnection();

            var sql = @"UPDATE public.barrios
                        set barrio =@barrio, id_ciudad=@id_ciudad
                        where id_barrio=@id_barrio;";

            var result = await db.ExecuteAsync(sql, new
            {
                neighborhood.id_barrio,
                neighborhood.id_ciudad,
                neighborhood.barrio
            }
            );

            return result > 0;
        }
    }
}
