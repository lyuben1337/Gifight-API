using Domain.Shared;
using MediatR;

namespace Application.Shared.Messaging;

public interface IQuery<T> : IRequest<Result<T>>
{
}