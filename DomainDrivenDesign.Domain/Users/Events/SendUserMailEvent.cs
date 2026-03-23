using MediatR;

namespace DomainDrivenDesign.Domain.Users.Events
{
    public sealed class SendUserMailEvent : INotificationHandler<UserDomainEvent>
    {
        public Task Handle(UserDomainEvent notification, CancellationToken cancellationToken)
        {
            // Sms sending operations
            return Task.CompletedTask;
        }
    }
    
}
