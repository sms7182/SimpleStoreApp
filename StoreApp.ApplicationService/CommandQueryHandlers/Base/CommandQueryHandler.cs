﻿using MediatR;
using StoreApp.Contracts.CommandQueries.Base;
using StoreApp.Contracts.Dtos.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StoreApp.ApplicationService.CommandQueryHandlers.Base
{
    public abstract class CommandQueryHandler<H, T, U> : IRequestHandler<H, U> where H : CommandQuery<T, U>, new() where T : RequestDto where U : ResponseDto
    {
        public async Task<U> Handle(H request, CancellationToken cancellationToken)
        {
            return await Handler(request, cancellationToken);
        }

        public abstract Task<U> Handler(H req, CancellationToken ct);

    }
}
