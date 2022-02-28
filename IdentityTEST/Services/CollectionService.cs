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
    public class CollectionService : ICollectionService
    {
        private readonly HttpClient _httpClient;

        public CollectionService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task DeleteCollection(int id)
        {
            await _httpClient.DeleteAsync($"api/collection/{id}");
        }

        public async Task<IEnumerable<Collection>> GetAllCollections()
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<Collection>>(
                await _httpClient.GetStreamAsync($"api/collection"),
                new JsonSerializerOptions() { PropertyNameCaseInsensitive = true }
                );
        }

        public async Task<Collection> GetCollectionDetails(int id)
        {
            return await JsonSerializer.DeserializeAsync<Collection>(
              await _httpClient.GetStreamAsync($"api/collection/{id}"),
              new JsonSerializerOptions() { PropertyNameCaseInsensitive = true }
              );
        }

        public async Task SaveCollection(Collection collection)
        {
            var clientJson = new StringContent(JsonSerializer.Serialize(collection),
              Encoding.UTF8, "application/json");

            if (collection.id_cobranza == 0)
                await _httpClient.PostAsync("api/collection", clientJson);
            else
                await _httpClient.PutAsync("api/collection", clientJson);
        }
    }
}
