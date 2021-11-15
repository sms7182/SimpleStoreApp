using MediatR;
using StoreApp.Contracts.Dtos.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApp.Contracts.CommandQueries.Base
{
    public abstract class CommandQuery<T, U> : IRequest<U> where T : RequestDto where U : ResponseDto
    {
        public CommandQuery()
        {
            Take = 10;
            PageNumber = 1;

        }
        public Guid Id { get; set; }
        public T RequestDto { get; set; }
        public int Take { get; set; }
        public int PageNumber { get; set; }
    }

}
