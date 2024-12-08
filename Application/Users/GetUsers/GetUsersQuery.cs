using Application.Shared.Messaging;

namespace Application.Users.GetUsers;

public record GetUsersQuery(
    int Page = 1,
    int PageSize = 0
) : IQuery<GetUsersQueryResponse>;