using CoreERP.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoreERP.Data.Repositories
{
    public interface INeighborhoodRepository
    {
        Task<IEnumerable<Neighborhood>> GetAllNeighborhoods();

        Task<Neighborhood> GetNeighborhoodDetails(int id);

        Task<bool> InsertNeighborhood(Neighborhood neighborhood);

        Task<bool> UpdateNeighborhood(Neighborhood neighborhood);

        Task<bool> DeleteNeighborhood(int id);
    }
}
