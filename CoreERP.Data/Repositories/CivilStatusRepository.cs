using CoreERP.Model;
using Dapper;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoreERP.Data.Repositories
{
    public class CivilStatusRepository : ICivilStatusRepository
    {

        private SqlConfiguration _connectionString;

        public CivilStatusRepository(SqlConfiguration connectionStringg)
        {
            _connectionString = connectionStringg;
        }

        protected NpgsqlConnection dbConnection()
        {
            return new NpgsqlConnection(_connectionString.ConnectionString);
        }

        public async Task<bool> DeleteCivilStatus(int id)
        {
            var db = dbConnection();

            var sql = @"DELETE from estados_civiles
                        WHERE id_estado_civil = @Id ";

            var result = await db.ExecuteAsync(sql, new { Id = id });

            return result > 0;
        }

        public async Task<IEnumerable<CivilStatus>> GetAllCivilStatus()
        {
            var db = dbConnection();
            var sql = @"select id_estado_civil , estado_civil from estados_civiles ec order by estado_civil;";

            return await db.QueryAsync<CivilStatus>(sql, new { });
        }

        public async Task<CivilStatus> GetCivilStatusDetails(int id)
        {
            var db = dbConnection();
            var sql = "select id_estado_civil , estado_civil from estados_civiles where id_eatado_civil = @Id";


            return await db.QueryFirstOrDefaultAsync<CivilStatus>(sql, new { Id = id });
        }

        public async Task<bool> InsertCivilStatus(CivilStatus civilStatus)
        {
            var db = dbConnection();

            var sql = @"INSERT INTO public.estados_civiles
                        (estado_civil)
                        VALUES(@estado_civil);";

            var result = await db.ExecuteAsync(sql, new
            {
                civilStatus.estado_civil
            }
            );

            return result > 0;
        }

        public async Task<bool> UpdateCivilStatus(CivilStatus civilStatus)
        {
            var db = dbConnection();

            var sql = @"UPDATE public.estados_civiles
                        SET estado_civil=@estado_civil
                        WHERE id_estado_civil=@id_estado_civil;";

            var result = await db.ExecuteAsync(sql, new
            {
                civilStatus.id_estado_civil,
                civilStatus.estado_civil
            }
            );

            return result > 0;
        }
    }
}
