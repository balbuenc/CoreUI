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
    public class PurchaseDetailsService : IPurchaseDetailsService
    {
        private readonly HttpClient _httpClient;
        public PurchaseDetailsService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task DeletePurchaseDetails(int id)
        {
            await _httpClient.DeleteAsync($"api/PurchaseDetail/{id}");
        }

        public async Task<IEnumerable<PurchaseDetails>> GetAllPurchaseDetails()
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<PurchaseDetails>>(
                 await _httpClient.GetStreamAsync($"api/PurchaseDetail"),
                 new JsonSerializerOptions() { PropertyNameCaseInsensitive = true }
                 );
        }

        public async Task<IEnumerable<PurchaseDetails>> GetPurchaseDetails(int id)
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<PurchaseDetails>>(
             await _httpClient.GetStreamAsync($"api/purchaseDetail/{id}"),
             new JsonSerializerOptions() { PropertyNameCaseInsensitive = true }
             );
        }

        public async Task<byte[]> GetPurchasePDF(int id)
        {

            var response = await _httpClient.GetByteArrayAsync($"api/Report/DownloadReport/{id}");
            return response;

        }

        public async Task<byte[]> GetInvoicePDF(int id)
        {

            var response = await _httpClient.GetByteArrayAsync($"api/InvoicePrint/DownloadInvoice/{id}");
            return response;

        }


        public async Task SavePurchaseDetails(PurchaseDetails budgetDetails)
        {
            var clientJson = new StringContent(JsonSerializer.Serialize(budgetDetails),
               Encoding.UTF8, "application/json");

            if (budgetDetails.id_compra_detalle == 0)
                await _httpClient.PostAsync("api/PurchaseDetail", clientJson);
            else
                await _httpClient.PutAsync("api/PurchaseDetail", clientJson);
        }
    }
}
