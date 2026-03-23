using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainDrivenDesign.Domain.Products
{
    public interface IProductRepository
    {
        Task CreateAsync(string name, int quantity, decimal amount, string currency, Guid categoryId,CancellationToken cancellationToken);
        Task<List<Product>> GetAllAsync(CancellationToken cancellationToken=default);
    }
}
