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
    public class NationalityService : INationalityService
    {
        private readonly HttpClient _httpClient;

        public NationalityService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task DeleteNationality(int id)
        {
            await _httpClient.DeleteAsync($"api/nationality/{id}");
        }

        public async Task<IEnumerable<Nationality>> GetAllNationalitys()
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<Nationality>>(
               await _httpClient.GetStreamAsync($"api/nationality"),
               new JsonSerializerOptions() { PropertyNameCaseInsensitive = true }
               );
        }

        public async Task<Nationality> GetNationalityDetails(int id)
        {
            return await JsonSerializer.DeserializeAsync<Nationality>(
            await _httpClient.GetStreamAsync($"api/area/{id}"),
            new JsonSerializerOptions() { PropertyNameCaseInsensitive = true }
            );
        }

        public async Task SaveNationality(Nationality nationality)
        {
            var clientJson = new StringContent(JsonSerializer.Serialize(nationality),
            Encoding.UTF8, "application/json");

            if (nationality.id_nacionalidad == 0)
                await _httpClient.PostAsync("api/nationality", clientJson);
            else
                await _httpClient.PutAsync("api/nationality", clientJson);
        }
    }
}
