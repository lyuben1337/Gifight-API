using Domain.Entities;

namespace Application.Shared.Services;

public interface IJwtProvider
{
    string Generate(User user);
}