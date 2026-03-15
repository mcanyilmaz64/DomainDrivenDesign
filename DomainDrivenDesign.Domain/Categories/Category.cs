using DomainDrivenDesign.Domain.Abstraction;
using DomainDrivenDesign.Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainDrivenDesign.Domain.Categories
{
    public sealed class Category :Entity
    {
        public Category(Guid id) : base(id)
        {

        }

        public string Name { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
