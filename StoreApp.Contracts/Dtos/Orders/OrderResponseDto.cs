using StoreApp.Contracts.Dtos.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApp.Contracts.Dtos.Orders
{
    public class OrderResponseDto: ResponseDto
    {
        public Guid Id { get; set; }
    }
}
