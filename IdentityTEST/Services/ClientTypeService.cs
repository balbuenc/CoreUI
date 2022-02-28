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
    public class ClientTypeService : IClientTypeService
    {
        private readonly HttpClient _httpClient;
        public ClientTypeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task DeleteClientType(int id)
        {
            await _httpClient.DeleteAsync($"api/ClientType/{id}");
        }

        public async Task<IEnumerable<ClientType>> GetAllClientTypes()
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<ClientType>>(
                await _httpClient.GetStreamAsync($"api/clientType"),
                new JsonSerializerOptions() { PropertyNameCaseInsensitive = true }
                );
        }

        public async Task<ClientType> GetClientTypeDetails(int id)
        {
            return await JsonSerializer.DeserializeAsync<ClientType>(
              await _httpClient.GetStreamAsync($"api/ClientType/{id}"),
              new JsonSerializerOptions() { PropertyNameCaseInsensitive = true }
              );
        }

        public async Task SaveClientType(ClientType ClientType)
        {
            var clientJson = new StringContent(JsonSerializer.Serialize(ClientType),
             Encoding.UTF8, "application/json");

            if (ClientType.id_tipo_cliente == 0)
                await _httpClient.PostAsync("api/ClientType", clientJson);
            else
                await _httpClient.PutAsync("api/ClientType", clientJson);
        }
    }
}
