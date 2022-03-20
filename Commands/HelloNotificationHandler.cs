using MediatR;

namespace asp_mediatr_example.Commands;
// Regular CommandHandler
public class HelloNotificationHandler
    : INotificationHandler<HelloNotification>
{
    private readonly ILogger<HelloNotificationHandler> _logger;

    // Using DI to inject infrastructure persistence Repositories
    public HelloNotificationHandler(
        ILogger<HelloNotificationHandler> logger)
    {
        _logger = logger;
    }

    Task INotificationHandler<HelloNotification>.Handle(HelloNotification notification, CancellationToken cancellationToken)
    {
        return Task.Run(() => {
            _logger.LogInformation($"received {notification.Name} by HelloNotificationHandler");
        });  
    }
}