using BasicControlFlow.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace BasicControlFlow.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ProductService _service;

        public ProductsController(ProductService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] Guid? id, [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            var result = await _service.GetPagedAsync(id, pageNumber, pageSize);
            return Ok(result);
        }
    }
}
