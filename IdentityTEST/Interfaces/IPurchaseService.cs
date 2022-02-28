using CoreERP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreERP.UI.Interfaces
{
    public interface IPurchaseService
    {
        Task<IEnumerable<Purchase>> GetAllPurchases();

        Task<Purchase> GetPurchaseDetails(int id);

        Task SavePurchase(Purchase purchase);


        Task DeletePurchase(int id);
    }
}
