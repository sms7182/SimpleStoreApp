using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.ApplicationService.CommandQueryHandlers.Orders.ServiceBuilder
{
    public interface ICalculatePrice
    {
        Task<IValidateAndBuildOrder> CalculatePrice();
    }
}
