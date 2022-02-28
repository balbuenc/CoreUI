using CoreERP.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoreERP.Data.Repositories
{
    public interface IPurchaseDetailsRepository
    {
        Task<IEnumerable<PurchaseDetails>> GetAllPurchaseDetails();

        Task<IEnumerable<PurchaseDetails>> GetPurchaseDetails(int id);

        Task<bool> InsertPurchaseDetail(PurchaseDetails purchaseDetails);

        Task<bool> UpdatePurchaseDetail(PurchaseDetails purchaseDetails);

        Task<bool> DeletePurchaseDetail(int id);
    }
}
