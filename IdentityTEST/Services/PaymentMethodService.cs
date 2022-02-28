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
    public class PaymentMethodService : IPaymentMethodService
    {
        private readonly HttpClient _httpClient;

        public PaymentMethodService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task DeletePaymentMethod(int id)
        {
            await _httpClient.DeleteAsync($"api/paymentmethod/{id}");
        }

        public async Task<IEnumerable<PaymentMethod>> GetAllPaymentMethods()
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<PaymentMethod>>(
                await _httpClient.GetStreamAsync($"api/paymentmethod"),
                new JsonSerializerOptions() { PropertyNameCaseInsensitive = true }
                );
        }

        public async Task<PaymentMethod> GetPaymentMethodDetails(int id)
        {
            return await JsonSerializer.DeserializeAsync<PaymentMethod>(
              await _httpClient.GetStreamAsync($"api/paymentmethod/{id}"),
              new JsonSerializerOptions() { PropertyNameCaseInsensitive = true }
              );
        }

        public async Task SavePaymentMethod(PaymentMethod method)
        {
            var clientJson = new StringContent(JsonSerializer.Serialize(method),
              Encoding.UTF8, "application/json");

            if (method.id_medio_pago== 0)
                await _httpClient.PostAsync("api/paymentmethod", clientJson);
            else
                await _httpClient.PutAsync("api/paymentmethod", clientJson);
        }
    }
}
