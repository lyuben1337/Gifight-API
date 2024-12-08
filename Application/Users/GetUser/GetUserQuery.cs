using Application.Shared.Messaging;

namespace Application.Users.GetUser;

public record GetUserQuery(
    long Id
) : IQuery<GetUserQueryResponse>;