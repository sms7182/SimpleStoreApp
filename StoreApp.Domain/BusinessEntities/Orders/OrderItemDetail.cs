using StoreApp.Domain.BusinessEntities.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApp.Domain.BusinessEntities.Orders
{
    
    public class OrderItemDetail
    {
        public string Address { get; set; }
        public ItemType ItemType { get; set; }
        public string Title { get; set; }
        public decimal Quantity { get; set; }
    }
}
