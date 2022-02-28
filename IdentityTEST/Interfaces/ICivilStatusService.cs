using CoreERP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreERP.UI.Interfaces
{
    public interface ICivilStatusService
    {
        Task<IEnumerable<CivilStatus>> GetAllCivilStatus();

        Task<CivilStatus> GetCivilStatusDetails(int id);

        Task SaveCivilStatus(CivilStatus city);


        Task DeleteCivilStatus(int id);
    }
}
