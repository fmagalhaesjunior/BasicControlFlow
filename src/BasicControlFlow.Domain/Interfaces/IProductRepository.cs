using BasicControlFlow.Domain.Entities;

namespace BasicControlFlow.Domain.Interfaces
{
    public interface IProductRepository
    {
        IQueryable<Product> GetQueryable();
    }
}
