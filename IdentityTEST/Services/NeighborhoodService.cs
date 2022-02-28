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
    public class NeighborhoodService : INeighborhoodService
    {

        private readonly HttpClient _httpClient;

        public NeighborhoodService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task DeleteNeighborhood(int id)
        {
            await _httpClient.DeleteAsync($"api/neighborhood/{id}");
        }

        public async Task<IEnumerable<Neighborhood>> GetAllNeighborhoods()
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<Neighborhood>>(
                await _httpClient.GetStreamAsync($"api/neighborhood"),
                new JsonSerializerOptions() { PropertyNameCaseInsensitive = true }
                );
        }

        public async Task<Neighborhood> GetNeighborhoodDetails(int id)
        {
            return await JsonSerializer.DeserializeAsync<Neighborhood>(
              await _httpClient.GetStreamAsync($"api/neighborhood/{id}"),
              new JsonSerializerOptions() { PropertyNameCaseInsensitive = true }
              );
        }

        public async Task SaveNeighborhood(Neighborhood neighborhood)
        {
            var clientJson = new StringContent(JsonSerializer.Serialize(neighborhood),
              Encoding.UTF8, "application/json");

            if (neighborhood.id_barrio == 0)
                await _httpClient.PostAsync("api/neighborhood", clientJson);
            else
                await _httpClient.PutAsync("api/neighborhood", clientJson);
        }
    }
}
