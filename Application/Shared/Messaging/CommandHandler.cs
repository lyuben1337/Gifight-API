using Domain.Repositories;
using Domain.Shared;
using FluentValidation;
using MediatR;

namespace Application.Shared.Messaging;

public abstract class CommandHandler<TCommand, TResponse> : BaseHandler<TCommand, TResponse>
    where TCommand : ICommand<TResponse>
{
    protected CommandHandler(IUnitOfWork unitOfWork, IValidator<TCommand>? validator = null)
        : base(unitOfWork, validator)
    {
    }

    protected override async Task<Result<TResponse>> HandleRequest(TCommand request,
        CancellationToken cancellationToken)
    {
        return await HandleCommand(request, cancellationToken);
    }

    protected abstract Task<Result<TResponse>> HandleCommand(TCommand request, CancellationToken cancellationToken);
}

public abstract class CommandHandler<TCommand> : BaseHandler<TCommand, Unit>
    where TCommand : IRequest<Result<Unit>>
{
    protected CommandHandler(IUnitOfWork unitOfWork, IValidator<TCommand>? validator = null)
        : base(unitOfWork, validator)
    {
    }

    protected override async Task<Result<Unit>> HandleRequest(TCommand request, CancellationToken cancellationToken)
    {
        var result = await HandleCommand(request, cancellationToken);

        return result.IsSuccess
            ? Result.Success(Unit.Value)
            : Result.Failure<Unit>(result.Error);
    }

    protected abstract Task<Result> HandleCommand(TCommand command, CancellationToken cancellationToken);
}