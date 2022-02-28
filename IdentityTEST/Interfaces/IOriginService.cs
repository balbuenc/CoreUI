using CoreERP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreERP.UI.Interfaces
{
    public interface IOriginService
    {
        Task<IEnumerable<Origin>> GetAllOrigins();

        Task<Origin> GetOriginDetails(int id);

        Task SaveOrigin(Origin origin);


        Task DeleteOrigin(int id);
    }
}
