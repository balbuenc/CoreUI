using CoreERP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreERP.UI.Interfaces
{
    public interface IBankService
    {
        Task<IEnumerable<Bank>> GetAllBanks();

        Task<Bank> GetBankDetails(int id);

        Task SaveBank(Bank bank);


        Task DeleteBank(int id);
    }
}
