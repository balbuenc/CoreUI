using CoreERP.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoreERP.Data.Repositories
{
    public interface IOriginRepository
    {
        Task<IEnumerable<Origin>> GetAllOrigins();

        Task<Origin> GetOriginDetails(int id);

        Task<bool> InsertOrigin(Origin origin);

        Task<bool> UpdateOrigin(Origin origin);

        Task<bool> DeleteOrigin(int id);
    }
}
