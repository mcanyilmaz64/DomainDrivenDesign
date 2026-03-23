using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainDrivenDesign.Application.Orders.CreateOrder
{
    public sealed record CreateOrderCommand (List<CreateOrderDto> createOrderDtos, CancellationToken cancellationToken) : IRequest;
}
