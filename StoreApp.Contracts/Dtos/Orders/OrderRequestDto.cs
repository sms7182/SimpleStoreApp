using StoreApp.Contracts.Dtos.Base;
using StoreApp.Domain.BusinessEntities.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApp.Contracts.Dtos.Orders
{
    public class OrderRequestDto : RequestDto
    {
        public Guid? CustomerId { get; set; }
        public decimal? Discount { get; set; }
        public DiscountType? DiscountType { get; set; }
        public IEnumerable<OrderItemReqDto> OrderItems { get; set; }
    }
    public class OrderItemReqDto
    {
        public Guid ItemId { get; set; }
        public decimal Quantity { get; set; }
    }
}
