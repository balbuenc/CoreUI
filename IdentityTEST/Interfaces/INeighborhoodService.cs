using CoreERP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreERP.UI.Interfaces
{
    public interface INeighborhoodService
    {
        Task<IEnumerable<Neighborhood>> GetAllNeighborhoods();

        Task<Neighborhood> GetNeighborhoodDetails(int id);

        Task SaveNeighborhood(Neighborhood neighborhood);


        Task DeleteNeighborhood(int id);
    }
}

