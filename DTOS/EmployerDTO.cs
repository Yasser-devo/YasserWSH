using System.ComponentModel.DataAnnotations;

namespace YasserWorkShop.DTOS
{
    public class EmployerDTO
    {
        [Required]
        public string Name { get; set; }

        public string? Position { get; set; }
        public string? Descripton { get; set; }

        [EmailAddress(ErrorMessage ="the email should be an email")]
        public string? EMail { get; set; }
    }
}
