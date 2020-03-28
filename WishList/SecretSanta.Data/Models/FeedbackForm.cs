using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecretSanta.Data.Models
{
    public class FeedbackForm
    {
        public Int64 Id { get; set; }
        public String FullName { get; set; }
        public String Email { get; set; }
        public String Subject { get; set; }
        public String Message { get; set; }
        public Int64 UserId { get; set; }
        public User User { get; set; }
    }
}
