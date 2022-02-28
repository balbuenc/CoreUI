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
    public class AreaService : IAreaService
    {

        private readonly HttpClient _httpClient;

        public AreaService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task DeleteArea(int id)
        {
            await _httpClient.DeleteAsync($"api/area/{id}");
        }

        public async Task<IEnumerable<Area>> GetAllAreas()
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<Area>>(
                await _httpClient.GetStreamAsync($"api/area"),
                new JsonSerializerOptions() { PropertyNameCaseInsensitive = true }
                );
        }

        public async Task<Area> GetAreaDetails(int id)
        {
            return await JsonSerializer.DeserializeAsync<Area>(
              await _httpClient.GetStreamAsync($"api/area/{id}"),
              new JsonSerializerOptions() { PropertyNameCaseInsensitive = true }
              );
        }

        public async Task SaveArea(Area area)
        {
            var clientJson = new StringContent(JsonSerializer.Serialize(area),
              Encoding.UTF8, "application/json");

            if (area.id_area == 0)
                await _httpClient.PostAsync("api/area", clientJson);
            else
                await _httpClient.PutAsync("api/area", clientJson);
        }
    }
}
