using CoreERP.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoreERP.Data.Repositories
{
    public interface IPurchaseRepository
    {
        Task<IEnumerable<Purchase>> GetAllPurchases();

        Task<Purchase> GetPurchaseDetails(int id);

        Task<bool> InsertPurchase(Purchase client);

        Task<bool> UpdatePurchase(Purchase client);

        Task<bool> DeletePurchase(int id);
    }
}
