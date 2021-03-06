﻿using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Abstractions.Authorization.User
{
    public class UserQueryHandler : IRequestHandler<UserRequest, AutorizacaoResponse>
    {
        //TO-DO Injetar Repository
        public Task<AutorizacaoResponse> Handle(UserRequest request, CancellationToken cancellationToken)
        {
            var permissao = request.User == "Jader" && request.Password == "123";
            return Task.FromResult(new AutorizacaoResponse(autorizado: permissao));
        }
    }
}
