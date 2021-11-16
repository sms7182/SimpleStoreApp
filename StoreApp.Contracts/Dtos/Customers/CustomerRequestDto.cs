using StoreApp.Contracts.Dtos.Base;
using StoreApp.Domain.BusinessEntities.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApp.Contracts.Dtos.Items
{
    public class CustomerRequestDto: RequestDto
    {
        public string Title { get; set; }
        public string Address { get; set; }
    }
}
