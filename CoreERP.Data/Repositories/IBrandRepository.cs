using CoreERP.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoreERP.Data.Repositories
{
    public interface IBrandRepository
    {
        Task<IEnumerable<Brand>> GetAllBrands();

        Task<Brand> GetBrandDetails(int id);

        Task<bool> InsertBrand(Brand brand);

        Task<bool> UpdateBrand(Brand brand);

        Task<bool> DeleteBrand(int id);
    }
}
