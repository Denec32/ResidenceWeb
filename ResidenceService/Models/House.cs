using System.ComponentModel.DataAnnotations;

namespace ResidenceService.Models
{
    public class House
    {
        [Key]
        public int Id { get; set; }
        public string Province { get; set; } = string.Empty;
        public string District { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Street { get; set; } = string.Empty;
        public int Number { get; set; }
        public string PostCode { get; set; } = string.Empty;
        public string FTSI { get; set; } = string.Empty;
        public string ARCPS { get; set; } = string.Empty;

        public List<Residence> Residences { get; set; }
    }
}