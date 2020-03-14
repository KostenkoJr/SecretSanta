using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SecretSanta.Data.Models
{
    public class User
    {
        [Key]
        public Int64 Id { get; set; }

        [MaxLength(255)]
        [Required]
        public String FirstName { get; set; }

        [MaxLength(255)]
        [Required]
        public String LastName { get; set; }

        [MaxLength(255)]
        [Index(IsUnique = true)]
        [Required]
        public String Email { get; set; }

        [MaxLength(255)]
        [Required]
        public String Password { get; set; }

        public String PathToPicture { get; set; }

        public Boolean IsAdmin { get; set; }
        public DateTime DateOfBirth { get; set; } 
        public Recipient Recipient { get; set; }
    }
}