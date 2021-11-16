using StoreApp.Contracts.Dtos.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApp.Contracts.Dtos.Items
{
    public class CustomerResponseDto: ResponseDto
    {
        public Guid Id { get; set; }
    }
}
