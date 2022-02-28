using CoreERP.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoreERP.Data.Repositories
{
    public interface IAccountDetailRepository
    {
        Task<IEnumerable<AccountDetails>> GetAllAccountDetails(int accountID);

        Task<AccountDetails> GetAccountDetailsDetail(int id);

        Task<bool> InsertAccountDetail(AccountDetails accountDetail);

        Task<bool> UpdateAccountDetail(AccountDetails accountDetail);

        Task<bool> DeleteAccountDetail(int id);
    }
}
