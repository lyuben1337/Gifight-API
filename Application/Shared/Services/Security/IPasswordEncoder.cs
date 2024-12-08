namespace Application.Shared.Services.Security;

public interface IPasswordEncoder
{
    string Encode(string password);
    bool Verify(string password, string encodedPassword);
}