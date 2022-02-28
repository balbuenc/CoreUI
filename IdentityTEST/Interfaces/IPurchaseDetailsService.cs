using CoreERP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreERP.UI.Interfaces
{
    public interface IPurchaseDetailsService
    {
        Task<IEnumerable<PurchaseDetails>> GetAllPurchaseDetails();

        Task<IEnumerable<PurchaseDetails>> GetPurchaseDetails(int id);

        Task<byte[]> GetPurchasePDF(int id);

        Task<byte[]> GetInvoicePDF(int id);

        Task SavePurchaseDetails(PurchaseDetails budget);


        Task DeletePurchaseDetails(int id);
    }
}
