namespace Application.Behaviors;

public class ValidationBehavior<TRequest, TResponse>(IEnumerable<IValidator<TRequest>> validators)
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        if (!validators.Any())
        {
            return await next();
        }

        var errors = validators
            .Select(validator => validator.Validate(request))
            .SelectMany(result => result.Errors)
            .Where(error => error != null)
            .Select(error => error.ErrorMessage)
            .Distinct()
            .ToArray();

        if (errors.Length != 0)
        {
            throw new ApplicationException(string.Join("\n", errors));
        }
        
        return await next();
    }
}