using SecretSanta.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecretSanta.Data.EF
{
    public class SantaContext : DbContext
    {
        public SantaContext() : base("SecretSantaConnection") { }
        static SantaContext()
        {
            Database.SetInitializer<SantaContext>(new MyInitializer());
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Wish> Wishes { get; set; }
        public DbSet<Group> Groups { get; set; }
    }
    
    public class MyInitializer : DropCreateDatabaseIfModelChanges<SantaContext>
    {
        protected override void Seed(SantaContext context)
        {
            User user = new User { 
                FirstName = "Lena", 
                LastName = "Chernaya", 
                Email = "1234@mail.ru", 
                Password = "panda_super_secret_password", 
                PathToPicture = "path to picture", 
                IsAdmin = true 
            };
            base.Seed(context);

        }
    }
}
