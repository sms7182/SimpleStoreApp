using StoreApp.Contracts.Dtos.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApp.Contracts.Dtos.Orders
{
    public class SendOrderReqDto:RequestDto
    {
        public Guid OrderId { get; set; }
    }
}
