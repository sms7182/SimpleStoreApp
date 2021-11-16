using StoreApp.Domain.BusinessEntities.Customers;
using StoreApp.Domain.BusinessEntities.Enums;
using StoreApp.Domain.BusinessEntities.Items;
using System;
using Xunit;

namespace StoreApp.Test
{
    public class CustomerTest
    {
        [Fact]
        public void CreateCustomerTest()
        {
            var customer = Customer.CreateInstance();
            Assert.NotNull(customer);
            customer.SetAddress("AddressTest");
            customer.SetTitle("CustomerTest");
            Assert.Equal("AddressTest", customer.Address);

            Assert.Equal("CustomerTest", customer.Title);
        }


    }
}
