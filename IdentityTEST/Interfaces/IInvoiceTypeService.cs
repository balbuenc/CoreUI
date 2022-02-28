using CoreERP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreERP.UI.Interfaces
{
    public interface IInvoiceTypeService
    {
        Task<IEnumerable<InvoiceType>> GetAllInvoiceTypes();

        Task<InvoiceType> GetInvoiceTypeDetails(int id);

        Task SaveInvoiceType(InvoiceType area);


        Task DeleteInvoiceType(int id);
    }
}
