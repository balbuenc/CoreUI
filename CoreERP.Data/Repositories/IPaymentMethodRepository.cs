using CoreERP.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoreERP.Data.Repositories
{
    public interface IPaymentMethodRepository
    {
        Task<IEnumerable<PaymentMethod>> GetAllPaymentMethods();

        Task<PaymentMethod> GetPaymentMethodDetails(int id);

        Task<bool> InsertPaymentMethod(PaymentMethod method);

        Task<bool> UpdatePaymentMethod(PaymentMethod method);

        Task<bool> DeletePaymentMethod(int id);
    }
}
