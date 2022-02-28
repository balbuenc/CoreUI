using CoreERP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreERP.UI.Interfaces
{
    public interface IAccountDetailsService
    {
        Task<IEnumerable<AccountDetails>> GetAllAccountDetails(int accountID);

        Task<AccountDetails> GetAccountDetailsDetail(int id);

        Task SaveAccountDetail(AccountDetails accountDetail);


        Task DeleteAccountDetail(int id);
    }
}
