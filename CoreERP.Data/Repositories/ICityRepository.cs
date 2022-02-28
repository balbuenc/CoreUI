using CoreERP.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoreERP.Data.Repositories
{
    public interface ICityRepository
    {
        Task<IEnumerable<City>> GetAllCities();

        Task<City> GetCityDetails(int id);

        Task<bool> InsertCity(City city);

        Task<bool> UpdateCity(City city);

        Task<bool> DeleteCity(int id);
    }
}
