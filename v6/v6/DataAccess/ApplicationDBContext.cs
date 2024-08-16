using System.Collections.Generic;
using System.Data.Entity;

namespace v6.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
       

        public ApplicationDbContext() : base("DefaultConnection")
        {
        }
    }
}
