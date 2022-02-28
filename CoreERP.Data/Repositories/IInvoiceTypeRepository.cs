using CoreERP.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoreERP.Data.Repositories
{
    public interface IInvoiceTypeRepository
    {
        Task<IEnumerable<InvoiceType>> GetAllInvoiceTypes();

        Task<InvoiceType> GetInvoiceTypeDetails(int id);

        Task<bool> InsertInvoiceType(InvoiceType client);

        Task<bool> UpdateInvoiceType(InvoiceType client);

        Task<bool> DeleteInvoiceType(int id);
    }
}
