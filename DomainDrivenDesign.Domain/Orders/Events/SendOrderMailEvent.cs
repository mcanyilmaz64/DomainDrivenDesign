using MediatR;

namespace DomainDrivenDesign.Domain.Orders.Events
{
    public sealed class SendOrderMailEvent : INotificationHandler<OrderDomainEvent>
    {
        public Task Handle(OrderDomainEvent notification, CancellationToken cancellationToken)
        {
            // Mail sending operations
            return Task.CompletedTask;
        }
    }
}
