using DomainDrivenDesign.Domain.Categories;
using DomainDrivenDesign.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainDrivenDesign.Infrastructure.Repositories
{
    internal sealed class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(string name, CancellationToken cancellationToken = default)
        {
            Category category = new(Guid.NewGuid(), new(name));
            await _context.Categories.AddAsync(category, cancellationToken);
            
        }

        public Task<List<Category>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return _context.Categories.ToListAsync(cancellationToken);
        }
    }
}
