using CoreERP.Model;
using Dapper;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoreERP.Data.Repositories
{
    public class DiscountRepository : IDiscountRepository
    {
        private SqlConfiguration _connectionString;

        public DiscountRepository(SqlConfiguration connectionStringg)
        {
            _connectionString = connectionStringg;
        }

        protected NpgsqlConnection dbConnection()
        {
            return new NpgsqlConnection(_connectionString.ConnectionString);
        }

        public async Task<bool> DeleteDiscount(int id)
        {
            try
            {
                var db = dbConnection();

                var sql = @"DELETE from descuentos
                        WHERE id_descuento = @Id ";

                var result = await db.ExecuteAsync(sql, new { Id = id });

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<Discount>> GetAllDiscounts()
        {
            try
            {
                var db = dbConnection();
                var sql = "select * from descuentos order by id_descuento asc";

                var result = await db.QueryAsync<Discount>(sql, new { });

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Discount> GetDiscountDetails(int id)
        {
            try
            {
                var db = dbConnection();
                var sql = "select * from descuentos  where id_descuento = @Id";


                return await db.QueryFirstOrDefaultAsync<Discount>(sql, new { Id = id });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> InsertDiscount(Discount discount)
        {
            try
            {
                var db = dbConnection();

                var sql = @"INSERT INTO public.descuentos (descuento, porcentaje) VALUES(@descuento, @porcentaje);";

                var result = await db.ExecuteAsync(sql, new
                {
                    discount.descuento,
                    discount.porcentaje
                }
                );

                return result > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> UpdateDiscount(Discount discount)
        {
            try
            {
                var db = dbConnection();

                var sql = @"UPDATE public.descuentos
                        set descuento =@descuento,
                            porcentaje =@porcentaje
                        where id_descuento=@id_descuento;";

                var result = await db.ExecuteAsync(sql, new
                {
                    discount.id_descuento,
                    discount.descuento,
                    discount.porcentaje
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
