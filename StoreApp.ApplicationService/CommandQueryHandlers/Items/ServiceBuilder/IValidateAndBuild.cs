using StoreApp.Domain.BusinessEntities.Items;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApp.ApplicationService.CommandQueryHandlers.Items.ServiceBuilder
{
    public interface IValidateAndBuild
    {
        Item ValidateAndBuild();
    }
}
