using CoreERP.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoreERP.Data.Repositories
{
    public interface ICountryRepository
    {
        Task<IEnumerable<Country>> GetAllCountries();

        Task<Country> GetCountryDetails(int id);

        Task<bool> InsertCountry(Country country);

        Task<bool> UpdateCountry(Country country);

        Task<bool> DeleteCountry(int id);
    }
}
