using DomainDrivenDesign.Domain.Abstraction;
using DomainDrivenDesign.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace DomainDrivenDesign.Domain.Orders
{
    public sealed class Order : Entity

        {
            public Order(Guid id,string orderNumber, DateTime createDate, OrderStatusEnum status) : base(id)
            {
                OrderNumber = orderNumber;
                CreateDate = createDate;
                Status = status;
            }

            public string OrderNumber { get;private set; }
            public DateTime CreateDate { get; private set; }
            public OrderStatusEnum Status { get; private set; }
            public ICollection<OrderLine> OrderLines { get; private set; } = new List<OrderLine>();

            public void CreateOrder(List<CreateOrderDto> createOrderDtos)
            {
            foreach (var item in createOrderDtos)
            {
                if (item.Quantity<1)
                {
                    throw new ArgumentException("Quantity must be greater than 0");
                }
                OrderLine orderLine = new(
                    Guid.NewGuid(),
                    Id,
                    item.ProductId,
                    item.Quantity,
                    new(item.Amount, Currency.FromCode(item.Currency)));
                OrderLines.Add(orderLine);
            }
            

            }
        public void RemoveOrder(Guid orderlineId)
        {
            var values = OrderLines.FirstOrDefault(x => x.Id == orderlineId);
            if (values is null)
            {
                throw new ArgumentException("OrderLine not found");
            }
            OrderLines.Remove(values);
        }

        }
    }



