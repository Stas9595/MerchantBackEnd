using System.Windows.Input;

namespace Domain.Common.Command;

public interface ICommandHandler<in TCommand, TResult> where TCommand : ICommand<TResult>
{
        Task<TResult> Handle(TCommand command, CancellationToken cancellationToken);
}