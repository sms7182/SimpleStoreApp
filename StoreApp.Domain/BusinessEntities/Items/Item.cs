using StoreApp.Domain.BusinessEntities.Enums;
using StoreApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApp.Domain.BusinessEntities.Items
{
    public class Item:AggregateEntity,IEntity
    {
        public ItemType ItemType { get;private set; }
        public decimal Price { get;private set; }
        public decimal Profit { get;private set; }
        public string Title { get;private set; }

        private Item()
        {

        }
      
        public static Item CreateInstance()
        {
            return new Item();
        }
        public void SetItemType(ItemType itemType)
        {
            ItemType = itemType;
        }
        public void SetTitle(string title)
        {
            Title = title;
        }
        public void SetPrice(decimal price)
        {
            Price = price;
        }
        public void SetProfit(decimal profit)
        {
            Profit = profit;
        }

        public void TitleValidation()
        {
            if (string.IsNullOrWhiteSpace(Title))
            {
                throw new Exception("عنوان کالا باید مشخص شود.");
            }
        }
        public void PriceValidation()
        {

            if (Price<=0)
            {
                throw new Exception("قیمت کالا باید مشخص شود.");
            }
        }

    }
}
