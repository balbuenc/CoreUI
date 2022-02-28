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
    public class CountryService : ICountryService
    {
        private readonly HttpClient _httpClient;

        public CountryService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task DeleteCountry(int id)
        {
            await _httpClient.DeleteAsync($"api/country/{id}");
        }

        public async Task<IEnumerable<Country>> GetAllCountries()
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<Country>>(
              await _httpClient.GetStreamAsync($"api/country"),
              new JsonSerializerOptions() { PropertyNameCaseInsensitive = true }
              );
        }

        public async Task<Country> GetCountryDetails(int id)
        {
            return await JsonSerializer.DeserializeAsync<Country>(
             await _httpClient.GetStreamAsync($"api/country/{id}"),
             new JsonSerializerOptions() { PropertyNameCaseInsensitive = true }
             );
        }

        public async Task SaveCountry(Country country)
        {
            var clientJson = new StringContent(JsonSerializer.Serialize(country),
            Encoding.UTF8, "application/json");

            if (country.id_pais == 0)
                await _httpClient.PostAsync("api/country", clientJson);
            else
                await _httpClient.PutAsync("api/country", clientJson);
        }
    }
}
