namespace MemberOutReachSystem.Business
{
    public interface ITokenBuilder
    {
        string BuildToken(string userName );

        string Authenticate(string UserName, string Password);
    }
}