using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SecretSanta.Data.Models
{
    [Table("Wishes")]
    public class Wish
    {
        [Key]
        public Int64 Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Title { get; set; }
        public string Description { get; set; }

        [MaxLength(200)]
        public string PathToPicture { get; set; }

        [MaxLength(200)]
        public string LinkToShop { get; set; }

        public decimal Price { get; set; }
        [Required]

        public Boolean IsComlete { get; set; }
        [Required]
        public DateTime Date { get; set; } = DateTime.UtcNow;

        public Int64 UserId { get; set; }
        public User User { get; set; }
    }
}