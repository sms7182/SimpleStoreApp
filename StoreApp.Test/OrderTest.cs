using StoreApp.Domain.BusinessEntities.Enums;
using StoreApp.Domain.BusinessEntities.Items;
using StoreApp.Domain.BusinessEntities.Orders;
using System;
using Xunit;

namespace StoreApp.Test
{
    public class OrderTest
    {
        [Fact]
        public void CreateOrderTest()
        {
            var item = Item.CreateInstance();
            item.SetItemType(ItemType.Breakable);
            item.SetPrice(50000);
            item.SetProfit(50);
            item.SetTitle("Test");
            item.PriceValidation();
            item.TitleValidation();
           var order= Order.CreateInstance();
            order.SetCustomer(Guid.NewGuid());
          var orderItem=  OrderItem.CreateInstance();
            orderItem.SetItem(item.Id);
            orderItem.SetQuantity(5);
            orderItem.SetUnitPrice(item.Price);
            orderItem.SetTotalPrice();
            order.AddOrderItem(orderItem);
            order.SetPrice(orderItem.TotalPrice);
            order.CalculateTotalPrice();
            order.CustomerValidate();
            order.OrderItemsValidate();
            order.RegisterTimeValidate();
            order.PriceValidate();
            Assert.Equal(250000, order.TotalPrice);
        }

        [Fact]
        public void PriceNotValidTest()
        {
            var item = Item.CreateInstance();
            item.SetItemType(ItemType.Breakable);
            item.SetPrice(40000);
            item.SetProfit(50);
            item.SetTitle("Test");
            item.PriceValidation();
            item.TitleValidation();
            var order = Order.CreateInstance();
            order.SetCustomer(Guid.NewGuid());
            var orderItem = OrderItem.CreateInstance();
            orderItem.SetItem(item.Id);
            orderItem.SetQuantity(1);
            orderItem.SetUnitPrice(item.Price);
            orderItem.SetTotalPrice();
            order.AddOrderItem(orderItem);
            order.SetPrice(orderItem.TotalPrice);
            order.CalculateTotalPrice();
            order.CustomerValidate();
            order.OrderItemsValidate();
            order.RegisterTimeValidate();
            
            Assert.Throws<Exception>(order.PriceValidate);
        }

        [Fact]
        public void NotValidCustomerOrderTest()
        {
            var item = Item.CreateInstance();
            item.SetItemType(ItemType.Breakable);
            item.SetPrice(50000);
            item.SetProfit(50);
            item.SetTitle("Test");
            item.PriceValidation();
            item.TitleValidation();
            var order = Order.CreateInstance();
            var orderItem = OrderItem.CreateInstance();
            orderItem.SetItem(item.Id);
            orderItem.SetQuantity(5);
            orderItem.SetUnitPrice(item.Price);
            orderItem.SetTotalPrice();
            order.AddOrderItem(orderItem);
            order.SetPrice(orderItem.TotalPrice);
            order.CalculateTotalPrice();
            Assert.Throws<Exception>(order.CustomerValidate);
        }

        [Fact]
        public void OrderItemTest()
        {
            var item = Item.CreateInstance();
            item.SetItemType(ItemType.Breakable);
            item.SetPrice(50000);
            item.SetProfit(50);
            item.SetTitle("Test");
            item.PriceValidation();
            item.TitleValidation();
            var order = Order.CreateInstance();
            order.SetCustomer(Guid.NewGuid());
            Assert.Throws<Exception>(order.OrderItemsValidate);
        }

    }
}
