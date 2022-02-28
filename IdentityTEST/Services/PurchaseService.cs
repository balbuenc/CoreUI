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
    public class PurchaseService : IPurchaseService
    {
        private readonly HttpClient _httpClient;

        public PurchaseService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task DeletePurchase(int id)
        {
            await _httpClient.DeleteAsync($"api/purchase/{id}");
        }

        public async Task<IEnumerable<Purchase>> GetAllPurchases()
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<Purchase>>(
                await _httpClient.GetStreamAsync($"api/purchase"),
                new JsonSerializerOptions() { PropertyNameCaseInsensitive = true }
                );
        }

        public async Task<Purchase> GetPurchaseDetails(int id)
        {
            return await JsonSerializer.DeserializeAsync<Purchase>(
              await _httpClient.GetStreamAsync($"api/purchase/{id}"),
              new JsonSerializerOptions() { PropertyNameCaseInsensitive = true }
              );
        }

        public async Task SavePurchase(Purchase purchase)
        {
            var clientJson = new StringContent(JsonSerializer.Serialize(purchase),
              Encoding.UTF8, "application/json");

            if (purchase.id_compra == 0)
                await _httpClient.PostAsync("api/purchase", clientJson);
            else
                await _httpClient.PutAsync("api/purchase", clientJson);
        }
    }
}
