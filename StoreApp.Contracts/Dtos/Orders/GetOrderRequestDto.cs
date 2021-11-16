using StoreApp.Contracts.Dtos.Base;
using StoreApp.Domain.BusinessEntities.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApp.Contracts.Dtos.Orders
{
    public class GetOrderRequestDto : RequestDto
    {
        public Guid? CustomerId { get; set; }
        
    }
    
}
