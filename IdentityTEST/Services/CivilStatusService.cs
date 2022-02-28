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
    public class CivilStatusService : ICivilStatusService
    {

        private readonly HttpClient _httpClient;

        public CivilStatusService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task DeleteCivilStatus(int id)
        {
            await _httpClient.DeleteAsync($"api/CivilStatus/{id}");
        }

        public async Task<IEnumerable<CivilStatus>> GetAllCivilStatus()
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<CivilStatus>>(
                await _httpClient.GetStreamAsync($"api/CivilStatus"),
                new JsonSerializerOptions() { PropertyNameCaseInsensitive = true }
                );
        }

        public async Task<CivilStatus> GetCivilStatusDetails(int id)
        {
            return await JsonSerializer.DeserializeAsync<CivilStatus>(
              await _httpClient.GetStreamAsync($"api/CivilStatus/{id}"),
              new JsonSerializerOptions() { PropertyNameCaseInsensitive = true }
              );
        }

        public async Task SaveCivilStatus(CivilStatus civilStatus)
        {
            var clientJson = new StringContent(JsonSerializer.Serialize(civilStatus),
           Encoding.UTF8, "application/json");

            if (civilStatus.id_estado_civil == 0)
                await _httpClient.PostAsync("api/CivilStatus", clientJson);
            else
                await _httpClient.PutAsync("api/CivilStatus", clientJson);
        }
    }
}
