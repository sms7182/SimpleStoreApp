using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace StoreApp.Contracts.Dtos.Base
{
    public class ResponseDto
    {
        public bool IsSuccess { get; set; }
        public IList Data { get; set; }
        
    }
}
