using CoreERP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreERP.UI.Interfaces
{
    public interface IAccountService
    {
        Task<IEnumerable<Account>> GetAllAccounts();

        Task<Account> GetAccountDetails(int id);

        Task SaveAccount(Account account);


        Task DeleteAccount(int id);
    }
}
