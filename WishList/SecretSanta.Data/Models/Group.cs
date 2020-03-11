using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecretSanta.Data.Models
{
    [Table("Groups")]
    public class Group
    {
        [Key]
        public Int64 Id { get; set; }
        public String Name { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
