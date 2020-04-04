using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecretSanta.Data.Models
{
    public class Recipient
    {
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
        public DateTime DateOfBirth { get; set; }

        public String PathToPicture { get; set; }
        //[Key]
        //[ForeignKey("User")]
        //public Int64 UserId { get; set; }
        //public User User { get; set; }
        
    }
}
