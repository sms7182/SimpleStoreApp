using StoreApp.Contracts.Dtos.Base;
using StoreApp.Domain.BusinessEntities.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApp.Contracts.Dtos.Items
{
    public class ItemRequestDto: RequestDto
    {
        public ItemType ItemType { get; set; }
        public decimal Price { get; set; }
        public decimal Profit { get; set; }
        public string Title { get; set; }
    }
}
