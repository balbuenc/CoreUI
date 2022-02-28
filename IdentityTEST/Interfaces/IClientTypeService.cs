using CoreERP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreERP.UI.Interfaces
{
    public interface IClientTypeService
    {
        Task<IEnumerable<ClientType>> GetAllClientTypes();

        Task<ClientType> GetClientTypeDetails(int id);

        Task SaveClientType(ClientType ClientType);


        Task DeleteClientType(int id);
    }
}
