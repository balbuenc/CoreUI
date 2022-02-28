using CoreERP.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoreERP.Data.Repositories
{
    public interface IBankRepository
    {
        Task<IEnumerable<Bank>> GetAllBanks();

        Task<Bank> GetBankDetails(int id);

        Task<bool> InsertBank(Bank bank);

        Task<bool> UpdateBank(Bank bank);

        Task<bool> DeleteBank(int id);
    }
}
