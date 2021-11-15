using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApp.ApplicationService.CommandQueryHandlers.Items.ServiceBuilder
{
    public interface ISetPrice
    {
        ISetPrice SetPrice(decimal profit);
        IValidateAndBuild SetProfit(decimal profit);
    }
}
