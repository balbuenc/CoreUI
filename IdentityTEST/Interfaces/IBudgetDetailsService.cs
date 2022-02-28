using CoreERP.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreERP.UI.Interfaces
{
    public interface IBudgetDetailsService
    {
        Task<IEnumerable<BudgetDetails>> GetAllBudgetDetails();

        Task<IEnumerable<BudgetDetails>> GetBudgetDetails(int id);

        Task<byte[]> GetBudgetPDF(int id);

        Task<byte[]> GetInvoicePDF(int id);

        Task SaveBudgetDetails(BudgetDetails budget);
        Task SaveBudgetDetails(BudgetDetails budget, bool isChecked);



        Task DeleteBudgetDetails(int id);
    }
}
