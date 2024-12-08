using Application.Shared.Messaging;
using Application.Users.DTOs;
using Domain.Entities;
using Domain.Repositories;
using Domain.Shared;
using Mapster;

namespace Application.Users.GetUser;

public class GetUserQueryHandler : QueryHandler<GetUserQuery, GetUserQueryResponse>
{
    public GetUserQueryHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
    }

    protected override async Task<Result<GetUserQueryResponse>> HandleQuery(GetUserQuery request,
        CancellationToken cancellationToken)
    {
        var user = await UnitOfWork.UserRepository.GetByIdAsync(request.Id, cancellationToken);

        return user == null
            ? Result.Failure<GetUserQueryResponse>(EntityError<User>.NotFound(request.Id))
            : Result.Success(new GetUserQueryResponse(user.Adapt<UserDto>()));
    }
}