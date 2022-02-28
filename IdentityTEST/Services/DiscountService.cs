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
    public class DiscountService : IDiscountService
    {
        private readonly HttpClient _httpClient;

        public DiscountService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task DeleteDiscount(int id)
        {
            await _httpClient.DeleteAsync($"api/discount/{id}");
        }

        public async Task<IEnumerable<Discount>> GetAllDiscounts()
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<Discount>>(
                await _httpClient.GetStreamAsync($"api/discount"),
                new JsonSerializerOptions() { PropertyNameCaseInsensitive = true }
                );
        }

        public async Task<Discount> GetDiscountDetails(int id)
        {
            return await JsonSerializer.DeserializeAsync<Discount>(
              await _httpClient.GetStreamAsync($"api/discount/{id}"),
              new JsonSerializerOptions() { PropertyNameCaseInsensitive = true }
              );
        }

        public async Task SaveDiscount(Discount discount)
        {
            var clientJson = new StringContent(JsonSerializer.Serialize(discount),
              Encoding.UTF8, "application/json");

            if (discount.id_descuento == 0)
                await _httpClient.PostAsync("api/discount", clientJson);
            else
                await _httpClient.PutAsync("api/discount", clientJson);
        }
    }
}
