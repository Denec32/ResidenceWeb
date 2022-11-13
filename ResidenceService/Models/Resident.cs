using System.ComponentModel.DataAnnotations;

namespace ResidenceService.Models
{
    public class Resident
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string SecondName { get; set; } = string.Empty;
        public string FatherName { get; set; } = string.Empty;
        public string PassportCode { get; set; } = string.Empty;
        public string Sex { get; set; } = string.Empty;
        public int Age { get; set; }
        public Residence Residence { get; set; }
    }
}
