using CoreERP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreERP.UI.Interfaces
{
    public interface IPositionService
    {
        Task<IEnumerable<Position>> GetAllPositions();

        Task<Position> GetPositionDetails(int id);

        Task SavePosition(Position position);


        Task DeletePosition(int id);
    }
}
