using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SP2.Models
{
    public class Camper
    {
        [Key]
        public int CamperId { get; set; }
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


        [ForeignKey("Cabin")]
        public int? CabinId { get; set; }
        // Navigation property: Each Camper belongs to one Cabin
        public Cabin Cabin { get; set; }

        // One-to-Many relationship: One Camper can have many NextOfKins
        public ICollection<NextOfKin> NextOfKins { get; set; } = new List<NextOfKin>();


        [Required]
        public DateTime MoveInDate { get; set; }
        public DateTime MoveOutDate { get; set; } // Nullable for historical tracking
    }
}
