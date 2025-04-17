using BasicControlFlow.Domain.Entities;
using BasicControlFlow.Domain.Interfaces;
using BasicControlFlow.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BasicControlFlow.Infrastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly AppDbContext _context;

        public CustomerRepository(AppDbContext context)
        {
            _context = context;
        }

        public IQueryable<Customer> GetQueryable() =>
            _context.Customers.AsNoTracking();

        public async Task<Customer?> GetByIdAsync(Guid id) =>
            await _context.Customers.FindAsync(id);

        public async Task AddAsync(Customer customer)
        {
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Customer customer)
        {
            _context.Customers.Update(customer);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer is not null)
            {
                _context.Customers.Remove(customer);
                await _context.SaveChangesAsync();
            }
        }
    }
}
