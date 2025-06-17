using Microsoft.Extensions.Logging;

namespace Domain.Common.Command;

public abstract class BaseCommandHandler<TCommand, TResult>: ICommandHandler<TCommand, TResult> where TCommand : ICommand<TResult>
{
    private readonly ILogger _logger;

    protected BaseCommandHandler(ILogger logger)
    {
        _logger = logger;
    }
    
    public Task<TResult> Handle(TCommand command, CancellationToken cancellationToken)
    {
        return Handle(command, cancellationToken);
    }
}