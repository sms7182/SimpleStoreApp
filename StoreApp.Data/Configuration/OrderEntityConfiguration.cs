using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StoreApp.Domain.BusinessEntities.Orders;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApp.Data.Configuration
{
    public class OrderEntityConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            if (builder == null)
            {
                return;
            }

            builder.HasKey(d => d.Id);
        }
    }
}
