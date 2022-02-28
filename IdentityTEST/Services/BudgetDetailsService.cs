using CoreERP.Model;
using CoreERP.UI.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting.Internal;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CoreERP.UI.Services
{
    public class BudgetDetailsService : IBudgetDetailsService
    {

        private readonly HttpClient _httpClient;

        public BudgetDetailsService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task DeleteBudgetDetails(int id)
        {
            await _httpClient.DeleteAsync($"api/BudgetDetail/{id}");
        }

        public async Task<IEnumerable<BudgetDetails>> GetAllBudgetDetails()
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<BudgetDetails>>(
                 await _httpClient.GetStreamAsync($"api/BudgetDetail"),
                 new JsonSerializerOptions() { PropertyNameCaseInsensitive = true }
                 );
        }

        public async Task<IEnumerable<BudgetDetails>> GetBudgetDetails(int id)
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<BudgetDetails>>(
             await _httpClient.GetStreamAsync($"api/budgetDetail/{id}"),
             new JsonSerializerOptions() { PropertyNameCaseInsensitive = true }
             );
        }

        public async Task<byte[]> GetBudgetPDF(int id)
        {

            var response = await _httpClient.GetByteArrayAsync($"api/Report/DownloadReport/{id}");
            return response;

        }

        public async Task<byte[]> GetInvoicePDF(int id)
        {

            var response = await _httpClient.GetByteArrayAsync($"api/InvoicePrint/DownloadInvoice/{id}");
            return response;

        }


        public async Task SaveBudgetDetails(BudgetDetails budgetDetails)
        {
            var clientJson = new StringContent(JsonSerializer.Serialize(budgetDetails),
               Encoding.UTF8, "application/json");

            if (budgetDetails.id_presupuesto_detalle == 0)
                await _httpClient.PostAsync("api/BudgetDetail", clientJson);
            else
                await _httpClient.PutAsync("api/BudgetDetail", clientJson);
        }

        public async Task SaveBudgetDetails(BudgetDetails budgetDetails, bool isChecked)
        {
            var clientJson = new StringContent(JsonSerializer.Serialize(budgetDetails),
               Encoding.UTF8, "application/json");

            await _httpClient.PutAsync("api/BudgetDetail/UpdateUnitaryPriceBudgetDetail", clientJson);
        }
    }
}
