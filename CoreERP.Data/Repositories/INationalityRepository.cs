using CoreERP.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoreERP.Data.Repositories
{
    public interface INationalityRepository
    {
        Task<IEnumerable<Nationality>> GetAllNationalitys();

        Task<Nationality> GetNationalityDetails(int id);

        Task<bool> InsertNationality(Nationality nationality);

        Task<bool> UpdateNationality(Nationality nationality);

        Task<bool> DeleteNationality(int id);
    }
}
