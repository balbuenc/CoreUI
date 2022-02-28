using CoreERP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreERP.UI.Interfaces
{
    public interface IAccountTypeService
    {
        Task<IEnumerable<AccountType>> GetAllAccountTypes();

        Task<AccountType> GetAccountTypeDetails(int id);

        Task SaveAccountType(AccountType accountType);


        Task DeleteAccountType(int id);
    }
}
