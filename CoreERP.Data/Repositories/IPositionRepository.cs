using CoreERP.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoreERP.Data.Repositories
{
    public interface IPositionRepository
    {
        Task<IEnumerable<Position>> GetAllPositions();

        Task<Position> GetPositionDetails(int id);

        Task<bool> InsertPosition(Position position);

        Task<bool> UpdatePosition(Position position);

        Task<bool> DeletePosition(int id);
    }
}
