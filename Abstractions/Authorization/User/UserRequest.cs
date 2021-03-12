using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Abstractions.Authorization.User
{
    public class UserRequest : IRequest<AutorizacaoResponse> //, IBaseRequest
    {
        public string User { get; set; }
        public string Password { get; set; }
    }
}
