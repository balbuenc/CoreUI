using CoreERP.Model;
using CoreERP.UI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CoreERP.UI.Services
{
    public class CityService : ICityService
    {

        private readonly HttpClient _httpClient;

        public CityService (HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task DeleteCity(int id)
        {
            await _httpClient.DeleteAsync($"api/city/{id}");
        }

        public async  Task<IEnumerable<City>> GetAllCities()
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<City>>(
               await _httpClient.GetStreamAsync($"api/city"),
               new JsonSerializerOptions() { PropertyNameCaseInsensitive = true }
               );
        }

        public async Task<City> GetCityDetails(int id)
        {
            return await JsonSerializer.DeserializeAsync<City>(
              await _httpClient.GetStreamAsync($"api/city/{id}"),
              new JsonSerializerOptions() { PropertyNameCaseInsensitive = true }
              );
        }

        public async Task SaveCity(City city)
        {
            var clientJson = new StringContent(JsonSerializer.Serialize(city),
             Encoding.UTF8, "application/json");

            if (city.id_ciudad == 0)
                await _httpClient.PostAsync("api/city", clientJson);
            else
                await _httpClient.PutAsync("api/city", clientJson);
        }
    }
}
