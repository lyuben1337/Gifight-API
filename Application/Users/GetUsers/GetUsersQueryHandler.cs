using Application.Shared.DTOs;
using Application.Shared.Messaging;
using Application.Users.DTOs;
using Domain.Repositories;
using Domain.Shared;
using FluentValidation;
using Mapster;

namespace Application.Users.GetUsers;

public class GetUsersQueryHandler : QueryHandler<GetUsersQuery, GetUsersQueryResponse>
{
    public GetUsersQueryHandler(IUnitOfWork unitOfWork, IValidator<GetUsersQuery> validator)
        : base(unitOfWork, validator)
    {
    }

    protected override async Task<Result<GetUsersQueryResponse>> HandleQuery(GetUsersQuery request,
        CancellationToken cancellationToken)
    {
        var usersPage = await UnitOfWork.UserRepository.AllAsync(request.Page, request.PageSize, cancellationToken);
        var usersDtoPage = PageDto<UserDto>.FromPage(usersPage, user => user.Adapt<UserShortDto>());

        return Result.Success(new GetUsersQueryResponse(usersDtoPage));
    }
}