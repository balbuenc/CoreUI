using CoreERP.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoreERP.Data.Repositories
{
    public interface ICurrencyRepository
    {
        Task<IEnumerable<Currency>> GetAllCurrencies();

        Task<Currency> GetCurrencytDetails(int id);

        Task<bool> InsertCurrency(Currency currency);

        Task<bool> UpdateCurrency(Currency currency);

        Task<bool> DeleteCurrency(int id);
    }
}
