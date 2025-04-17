using System.ComponentModel.DataAnnotations;

namespace BasicControlFlow.Domain.Entities
{
    public class Customer
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório")]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "O email é obrigatório")]
        [EmailAddress(ErrorMessage = "Email inválido")]
        public string Email { get; set; } = string.Empty;

        public DateTime Createdate { get; set; }
    }
}
