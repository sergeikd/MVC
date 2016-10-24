using System.Data.Entity;
using Oxagile.Internal.MVC.Entities.Domain;

namespace Oxagile.Internal.MVC.DALCF
{
    public class AppContext : DbContext
    {
        public AppContext()
            : base("MvcTask")
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Title> Titles { get; set; }
    }
}
