using MediatR;

namespace asp_mediatr_example.Commands;
// Regular CommandHandler
public class HelloCommandHandler
    : IRequestHandler<HelloCommand, bool>
{
    private readonly ILogger<HelloCommandHandler> _logger;

    // Using DI to inject infrastructure persistence Repositories
    public HelloCommandHandler(
        ILogger<HelloCommandHandler> logger)
    {
        _logger = logger;
    }

    public Task<bool> Handle(HelloCommand request, CancellationToken cancellationToken)
    {
        return Task.Run(() => {
            _logger.LogInformation($"hello {request.Name}");
        return true;
        });  
    }
}