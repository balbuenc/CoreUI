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
    public class OriginService : IOriginService
    {
        private readonly HttpClient _httpClient;

        public OriginService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task DeleteOrigin(int id)
        {
            await _httpClient.DeleteAsync($"api/origin/{id}");
        }

        public async Task<IEnumerable<Origin>> GetAllOrigins()
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<Origin>>(
                await _httpClient.GetStreamAsync($"api/origin"),
                new JsonSerializerOptions() { PropertyNameCaseInsensitive = true }
                );
        }

        public async Task<Origin> GetOriginDetails(int id)
        {
            return await JsonSerializer.DeserializeAsync<Origin>(
              await _httpClient.GetStreamAsync($"api/origin/{id}"),
              new JsonSerializerOptions() { PropertyNameCaseInsensitive = true }
              );
        }

        public async Task SaveOrigin(Origin origin)
        {
            var clientJson = new StringContent(JsonSerializer.Serialize(origin),
              Encoding.UTF8, "application/json");

            if (origin.id_origen == 0)
                await _httpClient.PostAsync("api/origin", clientJson);
            else
                await _httpClient.PutAsync("api/origin", clientJson);
        }
    }
}
