namespace Core.API.Autorizacao.Commands
{
    public class AutorizacaoResponse
    {
        public bool Autorizado { get; private set; }

        public AutorizacaoResponse(bool autorizado)
        {
            Autorizado = autorizado;
        }
    }
}
