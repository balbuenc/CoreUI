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
    public class AccountService : IAccountService
    {
        private readonly HttpClient _httpClient;

        public AccountService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task DeleteAccount(int id)
        {
            await _httpClient.DeleteAsync($"api/account/{id}");
        }

        public async Task<IEnumerable<Account>> GetAllAccounts()
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<Account>>(
                await _httpClient.GetStreamAsync($"api/account"),
                new JsonSerializerOptions() { PropertyNameCaseInsensitive = true }
                );
        }

        public async Task<Account> GetAccountDetails(int id)
        {
            return await JsonSerializer.DeserializeAsync<Account>(
              await _httpClient.GetStreamAsync($"api/account/{id}"),
              new JsonSerializerOptions() { PropertyNameCaseInsensitive = true }
              );
        }

        public async Task SaveAccount(Account account)
        {
            var clientJson = new StringContent(JsonSerializer.Serialize(account),
              Encoding.UTF8, "application/json");

            if (account.id_cuenta == 0)
                await _httpClient.PostAsync("api/account", clientJson);
            else
                await _httpClient.PutAsync("api/account", clientJson);
        }
    }
}
