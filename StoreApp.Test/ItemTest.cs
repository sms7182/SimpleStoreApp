using StoreApp.Domain.BusinessEntities.Enums;
using StoreApp.Domain.BusinessEntities.Items;
using System;
using Xunit;

namespace StoreApp.Test
{
    public class ItemTest
    {
        [Fact]
        public void CreateItemTest()
        {
            var item = Item.CreateInstance();
            Assert.NotNull(item);
            item.SetItemType(ItemType.Breakable);
            item.SetPrice(50000);
            item.SetProfit(50);
            item.SetTitle("Test");
            item.PriceValidation();
            item.TitleValidation();
            Assert.Equal(50000, item.Price);
            Assert.Equal("Test", item.Title);
            Assert.Equal(50, item.Profit);
        }


    }
}
