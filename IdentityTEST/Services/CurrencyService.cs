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
    public class CurrencyService : ICurrencyService
    {
        private readonly HttpClient _httpClient;

        public CurrencyService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task DeleteCurrency(int id)
        {
            await _httpClient.DeleteAsync($"api/currency/{id}");
        }

        public async Task<IEnumerable<Currency>> GetAllCurrencies()
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<Currency>>(
                await _httpClient.GetStreamAsync($"api/currency"),
                new JsonSerializerOptions() { PropertyNameCaseInsensitive = true }
                );
        }

        public async Task<Currency> GetCurrencyDetails(int id)
        {
            return await JsonSerializer.DeserializeAsync<Currency>(
              await _httpClient.GetStreamAsync($"api/currency/{id}"),
              new JsonSerializerOptions() { PropertyNameCaseInsensitive = true }
              );
        }

        public async Task SaveCurrency(Currency currency)
        {
            var clientJson = new StringContent(JsonSerializer.Serialize(currency),
              Encoding.UTF8, "application/json");

            if (currency.id_moneda == 0)
                await _httpClient.PostAsync("api/currency", clientJson);
            else
                await _httpClient.PutAsync("api/currency", clientJson);
        }
    }
}
