using Domain.Shared;
using MediatR;

namespace Application.Shared;

public interface IQuery<T> : IRequest<Result<T>>
{
}