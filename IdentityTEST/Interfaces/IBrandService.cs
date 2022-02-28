using CoreERP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreERP.UI.Interfaces
{
    public interface IBrandService
    {
        Task<IEnumerable<Brand>> GetAllBrands();

        Task<Brand> GetBrandDetails(int id);

        Task SaveBrand(Brand brand);


        Task DeleteBrand(int id);
    }
}
