using CoreERP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreERP.UI.Interfaces
{
    public interface IDiscountService
    {
        Task<IEnumerable<Discount>> GetAllDiscounts();

        Task<Discount> GetDiscountDetails(int id);

        Task SaveDiscount(Discount area);


        Task DeleteDiscount(int id);
    }
}
