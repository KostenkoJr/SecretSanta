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
        public string Title { get; set; }
        public string Description { get; set; }
        public string PathToPicture { get; set; }
        public string LinkToShop { get; set; }
        public decimal Price { get; set; }
        public Boolean IsComlete { get; set; }
        public DateTime Date { get; set; }
        public Int64 UserId { get; set; }
        public User User { get; set; }
    }
}