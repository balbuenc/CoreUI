using CoreERP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreERP.UI.Interfaces
{
    public interface IPaymentMethodService
    {
        Task<IEnumerable<PaymentMethod>> GetAllPaymentMethods();

        Task<PaymentMethod> GetPaymentMethodDetails(int id);

        Task SavePaymentMethod(PaymentMethod method);


        Task DeletePaymentMethod(int id);
    }
}
