using Domain.Repositories;
using Domain.Shared;
using FluentValidation;

namespace Application.Shared.Messaging;

public abstract class QueryHandler<TQuery, TResponse> : BaseHandler<TQuery, TResponse>
    where TQuery : IQuery<TResponse>
{
    protected QueryHandler(IUnitOfWork unitOfWork, IValidator<TQuery>? validator = null)
        : base(unitOfWork, validator)
    {
    }

    protected override async Task<Result<TResponse>> HandleRequest(TQuery request,
        CancellationToken cancellationToken)
    {
        return await HandleQuery(request, cancellationToken);
    }

    protected abstract Task<Result<TResponse>> HandleQuery(TQuery request, CancellationToken cancellationToken);
}