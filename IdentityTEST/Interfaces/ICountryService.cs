using CoreERP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreERP.UI.Interfaces
{
    public interface ICountryService
    {
        Task<IEnumerable<Country>> GetAllCountries();

        Task<Country> GetCountryDetails(int id);

        Task SaveCountry(Country Country);


        Task DeleteCountry(int id);
    }
}
