using Formation.Domain.Events;

namespace Formation.Application.Authors.EventHandlers
{
    public class AuthorCreatedHandler : INotificationHandler<DomainEventNotification<AuthorCreatedEvent>>
    {
        public Task Handle(DomainEventNotification<AuthorCreatedEvent> notification, CancellationToken cancellationToken)
        {
            Console.WriteLine(notification.DomainEvent.Item.FirstName);
            return Task.CompletedTask;
        }
    }
}
