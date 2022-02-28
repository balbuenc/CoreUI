using CoreERP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreERP.UI.Interfaces
{
    public interface ICurrencyService
    {
        Task<IEnumerable<Currency>> GetAllCurrencies();

        Task<Currency> GetCurrencyDetails(int id);

        Task SaveCurrency(Currency currency);


        Task DeleteCurrency(int id);
    }
}
