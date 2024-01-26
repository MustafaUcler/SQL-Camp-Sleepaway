using Microsoft.EntityFrameworkCore.Migrations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SP2.Models
{
    public class Counselor
    {
        [Key]
        public int CounselorId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public int Age { get; set; }
        public int? YearsExperience { get; set; }


        [ForeignKey("Cabin")]
        public int? CabinId { get; set; }
        public Cabin Cabin { get; set; }

        [Required]
        public DateTime ResponsibilityStartDate { get; set; }
        public DateTime? ResponsibilityEndDate { get; set; }
    }
}
