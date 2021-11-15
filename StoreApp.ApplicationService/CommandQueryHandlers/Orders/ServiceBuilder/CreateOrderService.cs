using StoreApp.ApplicationService.CommandQueryHandlers.Items.ServiceBuilder;
using StoreApp.ApplicationService.CommandQueryHandlers.Orders.ServiceBuilder;
using StoreApp.Domain.BusinessEntities.Enums;
using StoreApp.Domain.BusinessEntities.Items;
using StoreApp.Domain.BusinessEntities.Orders;
using StoreApp.Domain.IDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.ApplicationService.CommandQueryHandlers.ServiceBuilder
{
    public class CreateOrderService : ICreateOrderService,IAddOrderItem,ICalculatePrice,IValidateAndBuildOrder
    {
        
        IItemRepository itemRepository;
     
        Order order;
        List<Guid> itemNotFound;
        public CreateOrderService(IItemRepository _itemRepository)
        {
            itemRepository = _itemRepository;
            itemNotFound = new List<Guid>();
            
        }
        public ICalculatePrice AddOrderItem(Guid itemId,decimal quantity)
        {
           var orderItem= OrderItem.CreateInstance();
            orderItem.SetItem(itemId);
            orderItem.SetQuantity(quantity);
            order.AddOrderItem(orderItem);
            
           
            return this;
        }

       
        public async Task<IValidateAndBuildOrder> CalculatePrice()
        {

            var itemQuerale = await itemRepository.Find(f => order.OrderItems.Select(d=>d.ItemId).Contains(f.Id));
           var items= itemQuerale.ToList();
            decimal price = 0;
           foreach(var orderItem in order.OrderItems)
           {
                var item=  items.FirstOrDefault(d => d.Id == orderItem.ItemId);
                if (item == null) 
                {
                    itemNotFound.Add(orderItem.ItemId);
                    continue;
                }
                orderItem.SetUnitPrice(item.Price+item.Profit);
                orderItem.SetTotalPrice();
                price += orderItem.TotalPrice; 
            }
            order.SetPrice(price);
            order.CalculateTotalPrice();
            return this;
        }

        public IAddOrderItem InitOrder(Guid? customerId,decimal? discount=null, DiscountType? _discountType = null)
        {
            order = Order.CreateInstance();
            order.SetCustomer(customerId);
            order.SetDiscount(_discountType, discount);
            
           
            return this;

        }

      

        public Order ValidateAndBuildOrder()
        {
            order.CustomerValidate();
            order.OrderItemsValidate();
            order.PriceValidate();
            order.RegisterTimeValidate();

            return order;
        }
    }
}
