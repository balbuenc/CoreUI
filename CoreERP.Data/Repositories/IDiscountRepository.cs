using CoreERP.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoreERP.Data.Repositories
{
    public interface IDiscountRepository
    {
        Task<IEnumerable<Discount>> GetAllDiscounts();

        Task<Discount> GetDiscountDetails(int id);

        Task<bool> InsertDiscount(Discount client);

        Task<bool> UpdateDiscount(Discount client);

        Task<bool> DeleteDiscount(int id);
    }
}
