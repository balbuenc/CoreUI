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
    public class BankService : IBankService
    {
        private readonly HttpClient _httpClient;

        public BankService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task DeleteBank(int id)
        {
            await _httpClient.DeleteAsync($"api/bank/{id}");
        }

        public async Task<IEnumerable<Bank>> GetAllBanks()
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<Bank>>(
                await _httpClient.GetStreamAsync($"api/bank"),
                new JsonSerializerOptions() { PropertyNameCaseInsensitive = true }
                );
        }

        public async Task<Bank> GetBankDetails(int id)
        {
            return await JsonSerializer.DeserializeAsync<Bank>(
              await _httpClient.GetStreamAsync($"api/bank/{id}"),
              new JsonSerializerOptions() { PropertyNameCaseInsensitive = true }
              );
        }

        public async Task SaveBank(Bank bank)
        {
            var clientJson = new StringContent(JsonSerializer.Serialize(bank),
              Encoding.UTF8, "application/json");

            if (bank.id_banco == 0)
                await _httpClient.PostAsync("api/bank", clientJson);
            else
                await _httpClient.PutAsync("api/bank", clientJson);
        }
    }
}
