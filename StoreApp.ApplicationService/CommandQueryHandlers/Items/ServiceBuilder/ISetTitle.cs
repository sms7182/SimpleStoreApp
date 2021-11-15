using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApp.ApplicationService.CommandQueryHandlers.Items.ServiceBuilder
{
    public interface ISetTitle
    {
        ISetPrice SetTitle(string title);
    }
}
