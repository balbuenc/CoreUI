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
    public class InvoiceTypeService : IInvoiceTypeService
    {
        private readonly HttpClient _httpClient;

        public InvoiceTypeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task DeleteInvoiceType(int id)
        {
            await _httpClient.DeleteAsync($"api/invoiceType/{id}");
        }

        public async Task<IEnumerable<InvoiceType>> GetAllInvoiceTypes()
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<InvoiceType>>(
                await _httpClient.GetStreamAsync($"api/invoiceType"),
                new JsonSerializerOptions() { PropertyNameCaseInsensitive = true }
                );
        }

        public async Task<InvoiceType> GetInvoiceTypeDetails(int id)
        {
            return await JsonSerializer.DeserializeAsync<InvoiceType>(
              await _httpClient.GetStreamAsync($"api/invoiceType/{id}"),
              new JsonSerializerOptions() { PropertyNameCaseInsensitive = true }
              );
        }

        public async Task SaveInvoiceType(InvoiceType invoiceType)
        {
            var clientJson = new StringContent(JsonSerializer.Serialize(invoiceType),
              Encoding.UTF8, "application/json");

            if (invoiceType.id_condicion_venta == 0)
                await _httpClient.PostAsync("api/invoiceType", clientJson);
            else
                await _httpClient.PutAsync("api/invoiceType", clientJson);
        }
    }
}
