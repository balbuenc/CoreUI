using CoreERP.Model;
using Dapper;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoreERP.Data.Repositories
{
    public class OriginRepository : IOriginRepository
    {
        private SqlConfiguration _connectionString;

        public OriginRepository(SqlConfiguration connectionStringg)
        {
            _connectionString = connectionStringg;
        }

        protected NpgsqlConnection dbConnection()
        {
            return new NpgsqlConnection(_connectionString.ConnectionString);
        }


        public async Task<bool> DeleteOrigin(int id)
        {
            var db = dbConnection();

            var sql = @"DELETE from origenes
                        WHERE id_origen = @Id ";

            var result = await db.ExecuteAsync(sql, new { Id = id });

            return result > 0;
        }

        public async Task<IEnumerable<Origin>> GetAllOrigins()
        {
            var db = dbConnection();
            var sql = @"select o.id_origen, o.origen, o.id_pais, p.pais 
                        from origenes o
                        left outer join paises p on p.id_pais = o.id_pais";

            return await db.QueryAsync<Origin>(sql, new { });
        }

        public async Task<Origin> GetOriginDetails(int id)
        {
            var db = dbConnection();
            var sql = "select * from origenes  where id_origen = @Id";


            return await db.QueryFirstOrDefaultAsync<Origin>(sql, new { Id = id });
        }

        public async Task<bool> InsertOrigin(Origin origin)
        {
            var db = dbConnection();

            var sql = @"INSERT INTO public.origenes (origen, id_pais) VALUES(@origen, @id_pais);";

            var result = await db.ExecuteAsync(sql, new
            {
                origin.origen,
                origin.id_pais
            }
            );

            return result > 0;
        }

        public async Task<bool> UpdateOrigin(Origin origin)
        {
            var db = dbConnection();

            var sql = @"UPDATE public.origenes
                        set id_pais =@id_pais,
                            origen = @origen
                        where id_origen=@id_origen;";

            var result = await db.ExecuteAsync(sql, new
            {
                origin.id_origen,
                origin.origen,
                origin.id_pais
            }
            );

            return result > 0;
        }
    }
}
