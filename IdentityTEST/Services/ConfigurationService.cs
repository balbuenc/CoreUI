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
    public class ConfigurationService : IConfigurationService
    {
        private readonly HttpClient _httpClient;

        public ConfigurationService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task DeleteConfiguration(int id)
        {
            await _httpClient.DeleteAsync($"api/configuration/{id}");
        }

        public async Task<IEnumerable<Configuration>> GetAllConfigurations()
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<Configuration>>(
                await _httpClient.GetStreamAsync($"api/configuration"),
                new JsonSerializerOptions() { PropertyNameCaseInsensitive = true }
                );
        }

        public async Task<Configuration> GetConfigurationDetails(string param)
        {
            return await JsonSerializer.DeserializeAsync<Configuration>(
              await _httpClient.GetStreamAsync($"api/configuration/{param}"),
              new JsonSerializerOptions() { PropertyNameCaseInsensitive = true }
              );
        }

        public async Task SaveConfiguration(Configuration configuration)
        {
            var clientJson = new StringContent(JsonSerializer.Serialize(configuration),
              Encoding.UTF8, "application/json");

            if (configuration.id_configuracion == 0)
                await _httpClient.PostAsync("api/configuration", clientJson);
            else
                await _httpClient.PutAsync("api/configuration", clientJson);
        }
    }
}
