using StoreApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApp.Domain.BusinessEntities.Orders
{
    public class OrderItem:Entity
    {
        public  Guid ItemId{ get;private set; }
        public  decimal UnitPrice { get; private set; }
        public decimal TotalPrice { get; private set; }
        public decimal Quantity { get;private set; }
        public Order Order { get; set; }
        public Guid OrderId { get; set; }

        private  OrderItem()
        {

        }
        public static OrderItem CreateInstance()
        {
            return new OrderItem();
        }
        public void SetItem(Guid itemId)
        {
            ItemId = itemId;
        }
        public void SetQuantity(decimal quantity)
        {

            Quantity = quantity;
        }

        public void SetUnitPrice(decimal price)
        {

            UnitPrice = price;
        }

        public void SetTotalPrice()
        {
            TotalPrice = Quantity * UnitPrice;
        }

    }
}
