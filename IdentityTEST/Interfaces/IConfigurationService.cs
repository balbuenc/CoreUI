using CoreERP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreERP.UI.Interfaces
{
    public interface IConfigurationService
    {
        Task<IEnumerable<Configuration>> GetAllConfigurations();

        Task<Configuration> GetConfigurationDetails(string param);

        Task SaveConfiguration(Configuration configuration);


        Task DeleteConfiguration(int id);
    }
}
