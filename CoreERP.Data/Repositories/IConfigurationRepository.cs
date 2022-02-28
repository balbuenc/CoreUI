using CoreERP.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoreERP.Data.Repositories
{
    public interface IConfigurationRepository
    {
        Task<IEnumerable<Configuration>> GetAllConfigurations();

        Task<Configuration> GetConfigurationDetails(string param);

        Task<bool> InsertConfiguration(Configuration configuration);

        Task<bool> UpdateConfiguration(Configuration configuration);

        Task<bool> DeleteConfiguration(int id);
    }
}
