namespace AutoCreateApiTest
{
    public interface IJwtAuthenticationManager
    {
        string Authenticate(string username, string passsword);
    }
}
