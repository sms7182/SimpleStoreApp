using StoreApp.ApplicationService.CommandQueryHandlers.Items.ServiceBuilder;
using StoreApp.Domain.BusinessEntities.Enums;
using StoreApp.Domain.BusinessEntities.Items;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApp.ApplicationService.CommandQueryHandlers.ServiceBuilder
{
    public class UpdateItemService : IUpdateItemService,ISetTitle,ISetPrice,IValidateAndBuild
    {
        private string title;
        private ItemType itemType;
        private decimal price;
        private decimal profit;
        private Item item;

        public ISetTitle UpdateInit(Item _item,ItemType _itemType)
        {
            itemType = _itemType;
            item = _item;
            return this;
        }

        public ISetPrice SetPrice(decimal _price)
        {
            price = _price;
            return this;
        }

        public IValidateAndBuild SetProfit(decimal _profit)
        {
            profit = _profit;
            return this;
        }

        public ISetPrice SetTitle(string _title)
        {
            title = _title;
            return this;
        }

        public Item ValidateAndBuild()
        {
           
            item.SetItemType(itemType);
            item.SetTitle(title);
            item.SetProfit(profit);
            item.SetPrice(price);
            item.PriceValidation();
            item.TitleValidation();
            return item;

           
        }

      
    }
}
