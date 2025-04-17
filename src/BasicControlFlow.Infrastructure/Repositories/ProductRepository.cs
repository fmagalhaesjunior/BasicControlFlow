using BasicControlFlow.Domain.Entities;
using BasicControlFlow.Domain.Interfaces;
using BasicControlFlow.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BasicControlFlow.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public IQueryable<Product> GetQueryable() =>
        _context.Products.AsNoTracking();
    }
}
