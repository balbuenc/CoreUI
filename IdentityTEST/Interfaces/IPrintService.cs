using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreERP.UI.Interfaces
{
    public interface IPrintService
    {
       

        Task<byte[]> GetInvoicePDF(int id);
        Task<byte[]> GetRemissionPDF(int id);

        Task<byte[]> GetSpecialRemissionPDF(int id);


    }
}
