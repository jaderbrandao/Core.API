using MediatR;

namespace Core.API.Autorizacao.Commands.User
{
    public class UserRequest : IRequest<AutorizacaoResponse> //, IBaseRequest
    {
        public string User { get; set; }
        public string Password { get; set; }
    }
}
