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
    public class BrandService : IBrandService
    {
        private readonly HttpClient _httpClient;

        public BrandService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task DeleteBrand(int id)
        {
            await _httpClient.DeleteAsync($"api/brand/{id}");
        }

        public async Task<IEnumerable<Brand>> GetAllBrands()
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<Brand>>(
                await _httpClient.GetStreamAsync($"api/brand"),
                new JsonSerializerOptions() { PropertyNameCaseInsensitive = true }
                );
        }

        public async Task<Brand> GetBrandDetails(int id)
        {
            return await JsonSerializer.DeserializeAsync<Brand>(
              await _httpClient.GetStreamAsync($"api/brand/{id}"),
              new JsonSerializerOptions() { PropertyNameCaseInsensitive = true }
              );
        }

        public async Task SaveBrand(Brand brand)
        {
            var clientJson = new StringContent(JsonSerializer.Serialize(brand),
              Encoding.UTF8, "application/json");

            if (brand.id_marca == 0)
                await _httpClient.PostAsync("api/brand", clientJson);
            else
                await _httpClient.PutAsync("api/brand", clientJson);
        }
    }
}
