using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SP2.Models
{
    public class Cabin
    {
        [Key]
        public int CabinId { get; set; }
        [Required]
        public string CabinName { get; set; }
        [Required]
        public string CabinColor { get; set; }


        // One-to-Many relationship: One Cabin can have many Campers
        public List<Camper> Campers { get; set; }

        // One-to-One relationship: One Cabin is associated with one Counselor
        public Counselor Counselor { get; set; }

       
    }
}