using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StoreApp.Domain.BusinessEntities.Orders;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApp.Data.Configuration
{
    public class OrderItemEntityConfiguration: IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            if (builder == null)
            {
                return;
            }

            builder.HasKey(d => d.Id);
        }
    }
}
