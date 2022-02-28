using CoreERP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreERP.UI.Interfaces
{
    public interface ICityService
    {
        Task<IEnumerable<City>> GetAllCities();

        Task<City> GetCityDetails(int id);

        Task SaveCity(City city);


        Task DeleteCity(int id);
    }
}
