using CoreERP.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoreERP.Data.Repositories
{
    public interface IChildrenRepository
    {
        Task<IEnumerable<Children>> GetAllChildrens();

        Task<Children> GetChildrenDetails(int id);

        Task<bool> InsertChildren(Children children);

        Task<bool> UpdateChildren(Children children);

        Task<bool> DeleteChildren(int id);
    }
}
