using StoreApp.Domain.BusinessEntities.Enums;
using StoreApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApp.Domain.BusinessEntities.Orders
{
    public class Order:AggregateEntity,IEntity
    {
        public Guid? CustomerId { get;private set; }
        public decimal TotalPrice { get;private set; }
        public decimal Price { get;private set; }
        public decimal? Discount { get;private set; }
        public DiscountType? DiscountType { get;private set; }
        public List<OrderItem> OrderItems { get;private set; }

        private Order()
        {
            OrderItems = new List<OrderItem>();
        }

        public static Order CreateInstance()
        {
            return new Order();
        }
        public void AddOrderItem(OrderItem orderItem)
        {
            OrderItems.Add(orderItem);
        }
        public void SetCustomer(Guid? customerId)
        {
            CustomerId = customerId;
        }

        public void CalculateTotalPrice()
        {
            if (DiscountType.HasValue && Discount.HasValue)
            {
                TotalPrice = Price - (DiscountType.Value == Enums.DiscountType.Constant ? Discount.Value : (Price * Discount.Value / 100));
            }
            else
            {
                TotalPrice = Price;
            }
        }
        public void SetPrice(decimal price)
        {
            Price = price;
        }
        public void SetDiscount(DiscountType? discountType,decimal? discount)
        {
            DiscountType = discountType;
            Discount = discount;
        }

        public void CustomerValidate()
        {
            if (CustomerId==null||CustomerId==Guid.Empty)
            {
                throw new Exception("مشتری سفارش باید مشخص شود.");
            }
        }

        public void OrderItemsValidate()
        {
            if (OrderItems.Count == 0)
            {
                throw new Exception("سفارش باید حداقل یک قلم داشته باشد.");
            }
        }

        public void PriceValidate()
        {
            if (TotalPrice < 50000)
            {
                throw new Exception("حداقل مبلغ سفارش باید 50000 تومان باشد");
            }
        }

        public void RegisterTimeValidate()
        {
            TimeSpan start = new TimeSpan(8, 0, 0);
            TimeSpan end = new TimeSpan(19, 0, 0);
            TimeSpan now = DateTime.Now.TimeOfDay;
            if(now<start || now > end)
            {
                throw new Exception("زمان مجاز ثبت سفارش بین ساعت 8 صبح تا 7 بعد از ظهر است");
            }

        }
    }
}
