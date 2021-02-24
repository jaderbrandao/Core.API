namespace Swagger_Versioning
{
    public class ApiService : IApiService
    {
        public string Execute()
        {
            return "Hello World";
        }
    }

    public interface IApiService : IService
    {
        string Execute();
    }

}
