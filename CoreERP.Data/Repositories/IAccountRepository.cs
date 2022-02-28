using CoreERP.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoreERP.Data.Repositories
{
    public interface IAccountRepository
    {
        Task<IEnumerable<Account>> GetAllAccounts();

        Task<Account> GetAccountDetails(int id);

        Task<bool> InsertAccount(Account account);

        Task<bool> UpdateAccount(Account account);

        Task<bool> DeleteAccount(int id);
    }
}
