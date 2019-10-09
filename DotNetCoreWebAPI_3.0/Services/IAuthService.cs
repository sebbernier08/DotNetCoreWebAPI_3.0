namespace DotNetCoreWebAPI_3._0.Services
{
    public interface IAuthService
    {
        public string Authenticate(string email, string password);
    }
}
