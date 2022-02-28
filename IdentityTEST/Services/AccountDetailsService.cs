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
    public class AccountDetailsService : IAccountDetailsService
    {
        private readonly HttpClient _httpClient;

        public AccountDetailsService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task DeleteAccountDetail(int id)
        {
            await _httpClient.DeleteAsync($"api/AccountDetails/{id}");
        }

        public async Task<IEnumerable<AccountDetails>> GetAllAccountDetails(int accountID)
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<AccountDetails>>(
                await _httpClient.GetStreamAsync($"api/AccountDetails/{accountID}"),
                new JsonSerializerOptions() { PropertyNameCaseInsensitive = true }
                );
        }

        public async Task<AccountDetails> GetAccountDetailsDetail(int id)
        {
            return await JsonSerializer.DeserializeAsync<AccountDetails>(
              await _httpClient.GetStreamAsync($"api/AccountDetails/{id}"),
              new JsonSerializerOptions() { PropertyNameCaseInsensitive = true }
              );
        }

        public async Task SaveAccountDetail(AccountDetails accountDetail)
        {
            var clientJson = new StringContent(JsonSerializer.Serialize(accountDetail),
              Encoding.UTF8, "application/json");

            if (accountDetail.id_cuenta_detalle == 0)
                await _httpClient.PostAsync("api/AccountDetails", clientJson);
            else
                await _httpClient.PutAsync("api/AccountDetails", clientJson);
        }
    }
}
