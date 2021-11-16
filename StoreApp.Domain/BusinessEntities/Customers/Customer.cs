using StoreApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApp.Domain.BusinessEntities.Customers
{
    public class Customer: AggregateEntity, IEntity
    {
        public string Title { get;private set; }
        public string Address { get;private set; }

        private Customer()
        {

        }

        public static Customer CreateInstance()
        {
            return new Customer();
        }

        public void SetTitle(string title)
        {
            Title = title;
        }

        public void SetAddress(string address)
        {
            Address = address;
        }

    }
}
