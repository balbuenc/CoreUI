using CoreERP.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace CoreERP.Data.Repositories
{
    public interface ICollectionRepository
    {
        Task<IEnumerable<Collection>> GetAllCollections();

        Task<Collection> GetCollectionDetails(int id);

        Task<bool> InsertCollection(Collection collection);

        Task<bool> UpdateCollection(Collection collection);

        Task<bool> DeleteCollection(int id);
    }
}
