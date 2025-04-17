using BasicControlFlow.Domain.Entities;
using BasicControlFlow.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BasicControlFlow.Web.Pages.Customers
{
    public class CreateModel : PageModel
    {
        private readonly ICustomerRepository _repository;

        public CreateModel(ICustomerRepository repository)
        {
            _repository = repository;
        }

        [BindProperty]
        public Customer Customer { get; set; } = new();

        public void OnGet() { }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            Customer.Id = Guid.NewGuid();
            await _repository.AddAsync(Customer);

            return RedirectToPage("/Customers/Index");
        }
    }
}
