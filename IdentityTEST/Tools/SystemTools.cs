using CoreERP.Model;
using CoreERP.UI.Services;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CoreERP.UI.Tools
{
    public class SystemTools
    {
        static IConfiguration conf = (new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build());
        public static string apiurl = conf["api"].ToString();
        public async Task<string> GetSystemParam(string param)
        {



            //Get CoreERP Configuration from database
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(apiurl);
            Configuration configuration;

            ConfigurationService configurationService = new ConfigurationService(httpClient);
            try
            {
                configuration = await configurationService.GetConfigurationDetails(param);

                return configuration.valor;
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }
    }
}
