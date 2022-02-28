using CoreERP.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoreERP.Data.Repositories
{
    public interface IAreaRepository
    {
        Task<IEnumerable<Area>> GetAllAreas();

        Task<Area> GetAreaDetails(int id);

        Task<bool> InsertArea(Area client);

        Task<bool> UpdateArea(Area client);

        Task<bool> DeleteArea(int id);
    }
}
