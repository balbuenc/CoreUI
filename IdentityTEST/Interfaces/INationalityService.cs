using CoreERP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreERP.UI.Interfaces
{
    public interface INationalityService
    {
        Task<IEnumerable<Nationality>> GetAllNationalitys();

        Task<Nationality> GetNationalityDetails(int id);

        Task SaveNationality(Nationality area);


        Task DeleteNationality(int id);
    }
}
