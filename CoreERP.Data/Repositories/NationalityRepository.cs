using CoreERP.Model;
using Dapper;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoreERP.Data.Repositories
{
    public class NationalityRepository : INationalityRepository
    {
        private SqlConfiguration _connectionString;

        public NationalityRepository(SqlConfiguration connectionStringg)
        {
            _connectionString = connectionStringg;
        }

        protected NpgsqlConnection dbConnection()
        {
            return new NpgsqlConnection(_connectionString.ConnectionString);
        }

        public async Task<bool> DeleteNationality(int id)
        {
            var db = dbConnection();

            var sql = @"DELETE from nacionalidades
                        WHERE id_nacionalidad = @Id ";

            var result = await db.ExecuteAsync(sql, new { Id = id });

            return result > 0;
        }

        public async Task<IEnumerable<Nationality>> GetAllNationalitys()
        {
            var db = dbConnection();
            var sql = "select * from nacionalidades order by id_nacionalidad asc";

            return await db.QueryAsync<Nationality>(sql, new { });
        }

        public async Task<Nationality> GetNationalityDetails(int id)
        {
            var db = dbConnection();
            var sql = "select * from nacionalidades where id_nacionalidad = @Id";


            return await db.QueryFirstOrDefaultAsync<Nationality>(sql, new { Id = id });
        }

        public async Task<bool> InsertNationality(Nationality nationality)
        {
            var db = dbConnection();

            var sql = @"INSERT INTO public.nacionalidades (nacionalidad) VALUES(@nacionalidad);";

            var result = await db.ExecuteAsync(sql, new
            {
                nationality.nacionalidad
            }
            );

            return result > 0;
        }

        public async Task<bool> UpdateNationality(Nationality nationality)
        {
            var db = dbConnection();

            var sql = @"UPDATE public.nacionalidades
                        set nacionalidad =@nacionalidad
                        where id_nacionalidad=@id_nacionalidad;";

            var result = await db.ExecuteAsync(sql, new
            {
                nationality.id_nacionalidad,
                nationality.nacionalidad
            }
            );

            return result > 0;
        }
    }
}
