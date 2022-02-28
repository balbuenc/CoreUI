using CoreERP.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoreERP.Data.Repositories
{
    public interface IAccountTypeRepository
    {
        Task<IEnumerable<AccountType>> GetAllAccountTypes();

        Task<AccountType> GetAccountTypeDetails(int id);

        Task<bool> InsertAccountType(AccountType accountType);

        Task<bool> UpdateAccountType(AccountType accountType);

        Task<bool> DeleteAccountType(int id);
    }
}
