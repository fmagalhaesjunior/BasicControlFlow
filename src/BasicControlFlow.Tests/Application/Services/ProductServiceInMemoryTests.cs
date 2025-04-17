using BasicControlFlow.Application.Services;
using BasicControlFlow.Domain.Entities;
using BasicControlFlow.Infrastructure.Data;
using BasicControlFlow.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BasicControlFlow.Tests.Application.Services
{
    public class ProductServiceInMemoryTests
    {
        [Fact]
        public async Task GetPagedAsync_DeveRetornarProdutosPaginadosCorretamente()
        {
            // Arrange: criar opções para o banco em memória
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            // Inserir dados no contexto
            using (var context = new AppDbContext(options))
            {
                context.Products.AddRange(
                    new Product { Id = Guid.NewGuid(), Name = "Mouse", Price = 100 },
                    new Product { Id = Guid.NewGuid(), Name = "Teclado", Price = 200 },
                    new Product { Id = Guid.NewGuid(), Name = "Monitor", Price = 1200 }
                );
                await context.SaveChangesAsync();
            }

            // Act: acessar os dados via serviço
            using (var context = new AppDbContext(options))
            {
                var repository = new ProductRepository(context);
                var service = new ProductService(repository);

                var pagedResult = await service.GetPagedAsync(null, pageNumber: 1, pageSize: 2);

                // Assert
                Assert.Equal(2, pagedResult.Items.Count());
                Assert.Equal(3, pagedResult.TotalItems);
                Assert.Equal(2, pagedResult.PageSize);
                Assert.Equal(1, pagedResult.CurrentPage);
                Assert.Equal(2, pagedResult.TotalPages);
            }
        }
    }
}
