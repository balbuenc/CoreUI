using CoreERP.Model;
using Dapper;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoreERP.Data.Repositories
{
    public class ChildrenRepository : IChildrenRepository
    {
        private SqlConfiguration _connectionString;

        public ChildrenRepository(SqlConfiguration connectionStringg)
        {
            _connectionString = connectionStringg;
        }

        protected NpgsqlConnection dbConnection()
        {
            return new NpgsqlConnection(_connectionString.ConnectionString);
        }

        public async Task<bool> DeleteChildren(int id)
        {
            var db = dbConnection();

            var sql = @"DELETE from hijos
                        WHERE id_hijo = @Id ";

            var result = await db.ExecuteAsync(sql, new { Id = id });

            return result > 0;
        }

        public async Task<IEnumerable<Children>> GetAllChildrens()
        {
            var db = dbConnection();
            var sql = "select * from hijos order by id_hijo asc";

            return await db.QueryAsync<Children>(sql, new { });
        }

        public async Task<Children> GetChildrenDetails(int id)
        {
            var db = dbConnection();
            var sql = "select * from hijos  where id_hijo = @Id";


            return await db.QueryFirstOrDefaultAsync<Children>(sql, new { Id = id });
        }

        public async Task<bool> InsertChildren(Children children)
        {
            var db = dbConnection();

            var sql = @"INSERT INTO public.hijos (id_cliente,nombre,fecha_nacimiento) VALUES(@id_cliente,@nombre,@fecha_nacimiento);";

            var result = await db.ExecuteAsync(sql, new
            {
                children.id_cliente,
                children.nombre,
                children.fecha_nacimiento
            }
            );

            return result > 0;
        }

        public async Task<bool> UpdateChildren(Children children)
        {
            var db = dbConnection();

            var sql = @"UPDATE public.hijos
                        set id_cliente =@id_cliente,
                            nombre=@nombre,
                            fecha_nacimiento=@fecha_nacimiento
                        where id_hijo=@id_hijo;";

            var result = await db.ExecuteAsync(sql, new
            {
                children.id_hijo,
                children.id_cliente,
                children.nombre,
                children.fecha_nacimiento
            }
            );

            return result > 0;
        }
    }
}
