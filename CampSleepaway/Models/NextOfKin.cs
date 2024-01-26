using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SP2.Models
{
    public class NextOfKin
    {
        [Key]
        public int NextOfKinId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string PhoneNumber { get; set; }


        [ForeignKey("Camper")]
        public int CamperId { get; set; }
       // Navigation property: Each NextOfKin belongs to one Camper
        public Camper Camper { get; set; }


        public string RelationToCamper { get; set; }
        public DateTime MoveInDate { get; set; }
        public DateTime? MoveOutDate { get; set; } // Nullable for historical tracking
    }
}

