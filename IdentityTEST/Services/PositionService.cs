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
    public class PositionService : IPositionService
    {

        private readonly HttpClient _httpClient;

        public PositionService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task DeletePosition(int id)
        {
            await _httpClient.DeleteAsync($"api/position/{id}");
        }

        public async Task<IEnumerable<Position>> GetAllPositions()
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<Position>>(
               await _httpClient.GetStreamAsync($"api/position"),
               new JsonSerializerOptions() { PropertyNameCaseInsensitive = true }
               );
        }

        public async Task<Position> GetPositionDetails(int id)
        {
            return await JsonSerializer.DeserializeAsync<Position>(
            await _httpClient.GetStreamAsync($"api/position/{id}"),
            new JsonSerializerOptions() { PropertyNameCaseInsensitive = true }
            );
        }

        public async Task SavePosition(Position position)
        {
            var clientJson = new StringContent(JsonSerializer.Serialize(position),
             Encoding.UTF8, "application/json");

            if (position.id_cargo == 0)
                await _httpClient.PostAsync("api/position", clientJson);
            else
                await _httpClient.PutAsync("api/position", clientJson);
        }
    }
}
