using System.ComponentModel.DataAnnotations;

namespace YasserWorkShop.Models
{
    public class Employer
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        
        public string? Position { get; set; }
        public string? Descripton { get; set; }
        public decimal? Salary { get; set; }
        public string? NationalId { get; set; }
        public string? EMail { get; set; }

    }
}
