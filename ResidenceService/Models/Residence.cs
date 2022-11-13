using System.ComponentModel.DataAnnotations.Schema;

namespace ResidenceService.Models
{
    public class Residence
    {
        [ForeignKey("Resident")]
        public int Id { get; set; }

        public int Flat { get; set; }

        // Foregin keys
        public int ResidentId { get; set; }
        public Resident Resident { get; set; }

        public int HouseId { get; set; }
        public House House { get; set; }
    }
}