using Domain.Repositories;
using Domain.Shared;
using FluentValidation;
using MediatR;

namespace Application.Shared;

public abstract class BaseHandler<TRequest, TResponse>
    : IRequestHandler<TRequest, Result<TResponse>>
    where TRequest : IRequest<Result<TResponse>>
{
    private readonly IValidator<TRequest>? _validator;
    protected readonly IUnitOfWork UnitOfWork;

    protected BaseHandler(IUnitOfWork unitOfWork, IValidator<TRequest>? validator = null)
    {
        UnitOfWork = unitOfWork;
        _validator = validator;
    }

    public async Task<Result<TResponse>> Handle(TRequest request, CancellationToken cancellationToken)
    {
        if (_validator != null)
        {
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                return Result.Failure<TResponse>(Error.ValidationFailed(string.Join("; ", errors)));
            }
        }

        return await HandleRequest(request, cancellationToken);
    }

    protected abstract Task<Result<TResponse>> HandleRequest(TRequest request, CancellationToken cancellationToken);
}