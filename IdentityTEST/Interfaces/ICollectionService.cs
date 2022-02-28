using CoreERP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreERP.UI.Interfaces
{
    public interface ICollectionService
    {
        Task<IEnumerable<Collection>> GetAllCollections();

        Task<Collection> GetCollectionDetails(int id);

        Task SaveCollection(Collection area);


        Task DeleteCollection(int id);
    }
}
