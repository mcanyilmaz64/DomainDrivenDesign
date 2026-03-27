using DomainDrivenDesign.Domain.Abstraction;
using DomainDrivenDesign.Domain.Products;
using DomainDrivenDesign.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainDrivenDesign.Domain.Categories
{
    public sealed class Category :Entity
    {
        private Category(Guid id) : base(id)
        {

        }
        public Category(Guid id,Name name) : base(id)
        {
            Name = name;
        }

        public Name Name { get; private set; }
        public ICollection<Product> Products { get; set; }

        public void ChangeName(string name)
        {
            Name = new(name);
        }
    }
}
