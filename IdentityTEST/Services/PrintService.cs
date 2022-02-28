using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CoreERP.UI.Interfaces
{
    public class PrintService :IPrintService
    {

        private readonly HttpClient _httpClient;

        public PrintService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<byte[]> GetInvoicePDF(int id)
        {

            var response = await _httpClient.GetByteArrayAsync($"api/InvoicePrint/DownloadInvoice/{id}");
            return response;

        }

        public async Task<byte[]> GetRemissionPDF(int id)
        {

            var response = await _httpClient.GetByteArrayAsync($"api/RemissionPrint/DownloadRemission/{id}");
            return response;

        }

        public async Task<byte[]> GetSpecialRemissionPDF(int id)
        {

            var response = await _httpClient.GetByteArrayAsync($"api/RemissionPrint/DownloadSpecialRemission/{id}");
            return response;

        }
    }
}
