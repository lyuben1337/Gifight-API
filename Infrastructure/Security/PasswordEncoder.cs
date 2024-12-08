using System.Security.Cryptography;
using Application.Shared.Services.Security;

namespace Infrastructure.Security;

public class PasswordEncoder : IPasswordEncoder
{
    private const int SaltSize = 16;
    private const int KeySize = 128 / 8;
    private const int Iterations = 10000;
    private const char Separator = ';';

    public string Encode(string password)
    {
        var salt = RandomNumberGenerator.GetBytes(SaltSize);
        var hash = Rfc2898DeriveBytes.Pbkdf2(password, salt, Iterations, HashAlgorithmName.SHA256, KeySize);

        return string.Join(Separator, Convert.ToBase64String(salt), Convert.ToBase64String(hash));
    }

    public bool Verify(string password, string encryptedPassword)
    {
        var elements = encryptedPassword.Split(Separator);

        var salt = Convert.FromBase64String(elements[0]);
        var hash = Convert.FromBase64String(elements[1]);

        var hashInput = Rfc2898DeriveBytes.Pbkdf2(password, salt, Iterations, HashAlgorithmName.SHA256, KeySize);

        return CryptographicOperations.FixedTimeEquals(hash, hashInput);
    }
}