using BasicControlFlow.Application.Common;
using BasicControlFlow.Domain.Entities;
using BasicControlFlow.Domain.Interfaces;

namespace BasicControlFlow.Application.Services
{
    public class ProductService
    {
        private readonly IProductRepository _repository;

        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }
              
        public async Task<PagedResult<Product>> GetPagedAsync(Guid? id, int pageNumber, int pageSize)
        {
            var query = _repository.GetQueryable();

            if (id.HasValue)
                query = query.Where(p => p.Id == id.Value);

            return await query.ToPagedResultAsync(pageNumber, pageSize);
        }
    }
}
