using BasicControlFlow.Domain.Entities;

namespace BasicControlFlow.Domain.Interfaces
{
    public interface ICustomerRepository
    {
        IQueryable<Customer> GetQueryable();
        Task<Customer?> GetByIdAsync(Guid id);
        Task AddAsync(Customer customer);
        Task UpdateAsync(Customer customer);
        Task DeleteAsync(Guid id);
    }
}
