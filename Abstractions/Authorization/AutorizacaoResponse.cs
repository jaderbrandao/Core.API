namespace Abstractions.Authorization
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
