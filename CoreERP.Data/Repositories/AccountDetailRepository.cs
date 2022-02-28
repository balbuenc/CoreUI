using CoreERP.Model;
using Dapper;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoreERP.Data.Repositories
{
    public class AccountDetailRepository : IAccountDetailRepository
    {
        private SqlConfiguration _connectionString;

        public AccountDetailRepository(SqlConfiguration connectionStringg)
        {
            _connectionString = connectionStringg;
        }

        protected NpgsqlConnection dbConnection()
        {
            return new NpgsqlConnection(_connectionString.ConnectionString);
        }

        public async Task<bool> DeleteAccountDetail(int id)
        {
            try
            {
                var db = dbConnection();

                var sql = @"DELETE from cuentas
                        WHERE id_cuenta = @Id ";

                var result = await db.ExecuteAsync(sql, new { Id = id });

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<IEnumerable<AccountDetails>> GetAllAccountDetails(int accountID)
        {
            try
            {
                var db = dbConnection();
                var sql = @"SELECT cd.id_cuenta_detalle, cd.id_cuenta, cd.fecha, cd.id_funcionario, cd.tipo, cd.monto, c.nro_cuenta , f.usuario , cd.nro_comprobante , cd.concepto , cd.beneficiario , cd.detalle
                            FROM public.cuentas_detalles cd
                            left outer join cuentas c on c.id_cuenta = cd.id_cuenta 
                            left outer join funcionarios f on f.id_funcionario = cd.id_funcionario 
                            where cd.id_cuenta = @Id
                            order by cd.id_cuenta_detalle ";

                var result = await db.QueryAsync<AccountDetails>(sql, new { Id =accountID });

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<AccountDetails> GetAccountDetailsDetail(int id)
        {
            try
            {
                var db = dbConnection();
                var sql = @"SELECT cd.id_cuenta_detalle, cd.id_cuenta, cd.fecha, cd.id_funcionario, cd.tipo, cd.monto, c.nro_cuenta , f.usuario , cd.nro_comprobante , cd.concepto , cd.beneficiario , cd.detalle
                            FROM public.cuentas_detalles cd
                            left outer join cuentas c on c.id_cuenta = cd.id_cuenta
                            left outer join funcionarios f on f.id_funcionario = cd.id_funcionario
                            where cd.id_cuenta_detalle = @Id
                            order by cd.id_cuenta_detalle ";


                return await db.QueryFirstOrDefaultAsync<AccountDetails>(sql, new { Id = id });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> InsertAccountDetail(AccountDetails accountDetail)
        {
            try
            {
                var db = dbConnection();

                var sql = @"INSERT INTO public.cuentas_detalles
                            (id_cuenta, fecha, id_funcionario, tipo, monto, nro_comprobante , concepto , beneficiario , detalle) 
                            VALUES(@id_cuenta, @fecha, @id_funcionario, @tipo, @monto, @nro_comprobante , @concepto , @beneficiario , @detalle);";

                var result = await db.ExecuteAsync(sql, new
                {
                    accountDetail.id_cuenta,
                    accountDetail.fecha,
                    accountDetail.id_funcionario,
                    accountDetail.tipo,
                    accountDetail.monto,
                    accountDetail.nro_comprobante,
                    accountDetail.concepto,
                    accountDetail.beneficiario,
                    accountDetail.detalle
                }
                );

                return result > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> UpdateAccountDetail(AccountDetails accountDetail)
        {
            try
            {
                var db = dbConnection();

                var sql = @"UPDATE public.cuentas_detalles
                            SET id_cuenta=@id_cuenta, fecha=@fecha, id_funcionario=@id_funcionario, tipo=@tipo, monto=@monto, nro_comprobante=@nro_comprobante , concepto =@concepto , beneficiario=@beneficiario ,detalle= @detalle
                            WHERE id_cuenta_detalle=@id_cuenta_detalle;";

                var result = await db.ExecuteAsync(sql, new
                {
                    accountDetail.id_cuenta,
                    accountDetail.id_cuenta_detalle,
                    accountDetail.id_funcionario,
                    accountDetail.fecha,
                    accountDetail.tipo,
                    accountDetail.monto,
                    accountDetail.nro_comprobante,
                    accountDetail.concepto,
                    accountDetail.beneficiario,
                    accountDetail.detalle
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
