namespace Formation.Domain.Events;

public class AuthorCreatedEvent : DomainEvent
{
    public AuthorCreatedEvent(AuthorDTO item)
    {
        Item = item;
    }

    public AuthorDTO Item { get; }
}
