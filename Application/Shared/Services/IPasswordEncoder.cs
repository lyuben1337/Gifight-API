namespace Application.Shared.Services;

public interface IPasswordEncoder
{
    string Encode(string password);
    bool Verify(string password, string encodedPassword);
}