using CoreERP.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoreERP.Data.Repositories
{
    public interface ICivilStatusRepository
    {
        Task<IEnumerable<CivilStatus>> GetAllCivilStatus();

        Task<CivilStatus> GetCivilStatusDetails(int id);

        Task<bool> InsertCivilStatus(CivilStatus civilStatus);

        Task<bool> UpdateCivilStatus(CivilStatus civilStatus);

        Task<bool> DeleteCivilStatus(int id);
    }
}
