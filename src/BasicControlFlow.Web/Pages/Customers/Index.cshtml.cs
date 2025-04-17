using BasicControlFlow.Domain.Entities;
using BasicControlFlow.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BasicControlFlow.Web.Pages.Customers
{
    public class IndexModel : PageModel
    {
        private readonly ICustomerRepository _repository;

        public IndexModel(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public IList<Customer> Customers { get; set; } = new List<Customer>();

        public void OnGet()
        {
            Customers = _repository.GetQueryable().ToList();
        }
    }
}
