using CoreERP.Model;
using Dapper;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoreERP.Data.Repositories
{
    public class ConfigurationRepository : IConfigurationRepository
    {
        private SqlConfiguration _connectionString;

        public ConfigurationRepository(SqlConfiguration connectionStringg)
        {
            _connectionString = connectionStringg;
        }

        protected NpgsqlConnection dbConnection()
        {
            return new NpgsqlConnection(_connectionString.ConnectionString);
        }

        public async Task<bool> DeleteConfiguration(int id)
        {
            try
            {
                var db = dbConnection();

                var sql = @"DELETE from configuraciones
                        WHERE id_configuracion = @Id ";

                var result = await db.ExecuteAsync(sql, new { Id = id });

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<IEnumerable<Configuration>> GetAllConfigurations()
        {
            try
            {
                var db = dbConnection();
                var sql = "select * from configuraciones order by id_configuracion asc";

                var result = await db.QueryAsync<Configuration>(sql, new { });

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Configuration> GetConfigurationDetails(string param)
        {
            try
            {
                var db = dbConnection();
                var sql = "select * from configuraciones  where parametro = @Param";
                return await db.QueryFirstOrDefaultAsync<Configuration>(sql, new { Param = param });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> InsertConfiguration(Configuration configuration)
        {
            var db = dbConnection();
            try
            {
              

                var sql = @"INSERT INTO public.configuraciones (parametro, valor) VALUES(@parametro, @valor);";

                var result = await db.ExecuteAsync(sql, new
                {
                    configuration.parametro,
                    configuration.valor
                }
                );

                return result > 0;
            }
            catch (Exception ex)
            {
                
                var sqlupdate = "update configuraciones set valor=@Valor  where parametro = @Parametro";


                var result = await db.QueryFirstOrDefaultAsync<Configuration>(sqlupdate, new { Parametro = configuration.parametro, Valor = configuration.valor });

                return true;
            }
        }

        public async Task<bool> UpdateConfiguration(Configuration configuration)
        {
            try
            {
                var db = dbConnection();

                var sql = @"UPDATE public.configuraciones
                        set parametro =@parametro,
                            valor=@valor
                        where id_configuracion=@id_configuracion;";

                var result = await db.ExecuteAsync(sql, new
                {
                    configuration.id_configuracion,
                    configuration.parametro,
                    configuration.valor
                }
                );

                return result > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
