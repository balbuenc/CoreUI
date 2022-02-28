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
    public class AccountTypeService : IAccountTypeService
    {
        private readonly HttpClient _httpClient;

        public AccountTypeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task DeleteAccountType(int id)
        {
            await _httpClient.DeleteAsync($"api/accountType/{id}");
        }

        public async Task<IEnumerable<AccountType>> GetAllAccountTypes()
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<AccountType>>(
                await _httpClient.GetStreamAsync($"api/accountType"),
                new JsonSerializerOptions() { PropertyNameCaseInsensitive = true }
                );
        }

        public async Task<AccountType> GetAccountTypeDetails(int id)
        {
            return await JsonSerializer.DeserializeAsync<AccountType>(
              await _httpClient.GetStreamAsync($"api/accountType/{id}"),
              new JsonSerializerOptions() { PropertyNameCaseInsensitive = true }
              );
        }

        public async Task SaveAccountType(AccountType accountType)
        {
            var clientJson = new StringContent(JsonSerializer.Serialize(accountType),
              Encoding.UTF8, "application/json");

            if (accountType.id_tipo_cuenta == 0)
                await _httpClient.PostAsync("api/accountType", clientJson);
            else
                await _httpClient.PutAsync("api/accountType", clientJson);
        }
    }
}
