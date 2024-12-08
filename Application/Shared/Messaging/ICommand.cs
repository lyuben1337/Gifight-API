using Domain.Shared;
using MediatR;

namespace Application.Shared.Messaging;

public interface ICommand : IRequest<Result>
{
}

public interface ICommand<T> : IRequest<Result<T>>
{
}