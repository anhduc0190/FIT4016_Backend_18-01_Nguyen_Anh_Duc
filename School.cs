using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SchoolManagement
{
    public class School
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "School name is required")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "School name must be between 2 and 100 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Principal name is required")]
        public string Principal { get; set; }

        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        // Navigation property for 1-to-many relationship
        public ICollection<Student> Students { get; set; }
    }
}
