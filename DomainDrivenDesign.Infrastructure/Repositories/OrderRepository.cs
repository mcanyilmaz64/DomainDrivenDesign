using DomainDrivenDesign.Domain.Orders;
using DomainDrivenDesign.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainDrivenDesign.Infrastructure.Repositories
{
    internal sealed class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _context;

        public OrderRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Order> CreateAsync(List<CreateOrderDto> createOrderDtos, CancellationToken cancellationToken = default)
        {
            Order order = new(
                Guid.NewGuid(),
                "1",
                DateTime.Now,
                OrderStatusEnum.AwaitingApproval   
                 );

            order.CreateOrder(createOrderDtos);
            await _context.Orders.AddAsync(order, cancellationToken);
            return order;
        }
       

        public Task<List<Order>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return _context.Orders.ToListAsync(cancellationToken);
        }
    }
}
