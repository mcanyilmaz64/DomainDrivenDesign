using DomainDrivenDesign.Domain.Abstraction;
using DomainDrivenDesign.Domain.Categories;
using DomainDrivenDesign.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainDrivenDesign.Domain.Products
{
    public sealed class Product : Entity
    {

        public Product(Guid id,string name, int quantity, Money price, Guid categoryId, Category category) : base(id)
        {
            Name = name;
            Quantity = quantity;
            Price = price;
            CategoryId = categoryId;
            Category = category;
        }

        public Name Name { get; private set; }
        public int Quantity { get;private set; }
        public Money Price { get;private set; }
        public Guid CategoryId { get;private set; }
        public Category Category { get;private set; }

        public void Update(string name ,int quantity, int amount, decimal price,string currency, Guid categorryId)
        {
            Name = new(name);
            Price = new(amount,Currency.FromCode(currency));
            CategoryId = categorryId;
            Quantity = quantity;

        }
    }
}
