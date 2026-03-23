using DomainDrivenDesign.Domain.Abstraction;
using DomainDrivenDesign.Domain.Orders;
using DomainDrivenDesign.Domain.Orders.Events;
using MediatR;

namespace DomainDrivenDesign.Application.Orders.CreateOrder
{
    internal sealed class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMediator _mediator;

        public CreateOrderCommandHandler(IMediator mediator, IUnitOfWork unitOfWork, IOrderRepository orderRepository)
        {
            _mediator = mediator;
            _unitOfWork = unitOfWork;
            _orderRepository = orderRepository;
        }

        public async Task Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.CreateAsync(request.createOrderDtos, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            await _mediator.Publish(new OrderDomainEvent(order), cancellationToken);
           
        }
    
        
    }
}
