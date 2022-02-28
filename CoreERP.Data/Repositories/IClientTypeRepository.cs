using CoreERP.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoreERP.Data.Repositories
{
    public interface IClientTypeRepository
    {
        Task<IEnumerable<ClientType>> GetAllClientTypes();

        Task<ClientType> GetClientTypeDetails(int id);

        Task<bool> InsertClientType(ClientType clientType);

        Task<bool> UpdateClientType(ClientType clientType);

        Task<bool> DeleteClientType(int id);
    }
}
