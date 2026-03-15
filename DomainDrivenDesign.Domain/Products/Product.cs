using DomainDrivenDesign.Domain.Abstraction;
using DomainDrivenDesign.Domain.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainDrivenDesign.Domain.Products
{
    public sealed class Product : Entity
    {
        public Product(Guid id) : base(id)
        {
        }

        public string Name { get; set; }
        public int Quantity { get; set; }
        public Decimal Price { get; set; }
        public string Currency { get; set; }
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
