using CoreERP.Model;
using Dapper;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoreERP.Data.Repositories
{
    public class PositionRepository : IPositionRepository
    {
        private SqlConfiguration _connectionString;

        public PositionRepository(SqlConfiguration connectionStringg)
        {
            _connectionString = connectionStringg;
        }

        protected NpgsqlConnection dbConnection()
        {
            return new NpgsqlConnection(_connectionString.ConnectionString);
        }

        public async Task<bool> DeletePosition(int id)
        {
            var db = dbConnection();

            var sql = @"DELETE from cargos
                        WHERE id_cargo = @Id ";

            var result = await db.ExecuteAsync(sql, new { Id = id });

            return result > 0;
        }

        public async Task<IEnumerable<Position>> GetAllPositions()
        {
            var db = dbConnection();
            var sql = @"SELECT c.id_cargo, c.id_area, c.cargo, a.area 
                        FROM public.cargos c
                        inner join public.areas a on a.id_area = c.id_area
                        order by a.area , c.cargo;";

            return await db.QueryAsync<Position>(sql, new { });
        }

        public async Task<Position> GetPositionDetails(int id)
        {
            var db = dbConnection();
            var sql = "select * from cargos  where id_cargo = @Id";


            return await db.QueryFirstOrDefaultAsync<Position>(sql, new { Id = id });
        }

        public async Task<bool> InsertPosition(Position position)
        {
            var db = dbConnection();

            var sql = @"INSERT INTO public.cargos (id_area, cargo) VALUES(@id_area, @cargo);";

            var result = await db.ExecuteAsync(sql, new
            {
                position.id_area,
                position.cargo
            }
            );

            return result > 0;
        }

        public async Task<bool> UpdatePosition(Position position)
        {
            var db = dbConnection();

            var sql = @"UPDATE public.cargos
                        set cargo =@cargo,
                            id_area =@id_area
                        where id_cargo=@id_cargo;";

            var result = await db.ExecuteAsync(sql, new
            {
                position.id_cargo,
                position.id_area,
                position.cargo
            }
            );

            return result > 0;
        }
    }
}
