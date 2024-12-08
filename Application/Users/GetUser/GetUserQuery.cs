using Application.Shared;

namespace Application.Users.GetUser;

public record GetUserQuery(
    long Id
) : IQuery<GetUserQueryResponse>;