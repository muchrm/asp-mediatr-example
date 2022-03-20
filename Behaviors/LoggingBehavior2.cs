using MediatR;
namespace asp_mediatr_example.Behavior;
public class LoggingBehavior2<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
 where TRequest : IRequest<TResponse>
{
    private readonly ILogger<LoggingBehavior2<TRequest, TResponse>> _logger;
    public LoggingBehavior2(ILogger<LoggingBehavior2<TRequest, TResponse>> logger) => _logger = logger;

    public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
    {
        _logger.LogInformation("Logstamp:----- Handling command {CommandName} ({@Command})", nameof(request), request);
        var response = await next();
        _logger.LogInformation("Logstamp:----- Command {CommandName} handled - response: {@Response}", nameof(request), response);

        return response;
    }
}

