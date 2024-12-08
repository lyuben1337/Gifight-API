using Domain.Entities;

namespace Application.Shared.Services.Security;

public interface IJwtProvider
{
    string Generate(User user);
}