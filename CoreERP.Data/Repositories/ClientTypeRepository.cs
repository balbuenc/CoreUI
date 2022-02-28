using CoreERP.Model;
using Dapper;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoreERP.Data.Repositories
{
    public class ClientTypeRepository : IClientTypeRepository
    {

        private SqlConfiguration _connectionString;

        public ClientTypeRepository(SqlConfiguration connectionStringg)
        {
            _connectionString = connectionStringg;
        }

        protected NpgsqlConnection dbConnection()
        {
            return new NpgsqlConnection(_connectionString.ConnectionString);
        }

        public async Task<bool> DeleteClientType(int id)
        {
            var db = dbConnection();

            var sql = @"DELETE from tipos_clientes
                        WHERE id_tipo_cliente = @Id ";

            var result = await db.ExecuteAsync(sql, new { Id = id });

            return result > 0;
        }

        public async Task<IEnumerable<ClientType>> GetAllClientTypes()
        {
            var db = dbConnection();
            var sql = "select * from tipos_clientes order by id_tipo_cliente asc";

            return await db.QueryAsync<ClientType>(sql, new { });
        }

        public async Task<ClientType> GetClientTypeDetails(int id)
        {
            var db = dbConnection();
            var sql = "select * from tipos_clientes where id_tipo_cliente = @Id";


            return await db.QueryFirstOrDefaultAsync<ClientType>(sql, new { Id = id });
        }

        public async Task<bool> InsertClientType(ClientType clientType)
        {
            var db = dbConnection();

            var sql = @"    INSERT INTO public.tipos_clientes
                            (tipo)
                            VALUES(@tipo);";

            var result = await db.ExecuteAsync(sql, new
            {
                clientType.tipo
            });

            return result > 0;



        }

        public async Task<bool> UpdateClientType(ClientType clientType)
        {
            var db = dbConnection();

            var sql = @"UPDATE public.tipos_clientes
                        SET tipo=@tipo
                        WHERE id_tipo_cliente=@id_tipo_cliente;";

            var result = await db.ExecuteAsync(sql, new
            {
                clientType.id_tipo_cliente,
                clientType.tipo
            });

            return result > 0;
        }
    }
}
