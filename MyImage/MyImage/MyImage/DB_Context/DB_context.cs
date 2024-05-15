using Microsoft.EntityFrameworkCore;
using MyImage.Models;

namespace MyImage.DB_Context
{
    public class DB_context : DbContext
    {
        public DB_context(DbContextOptions<DB_context> options) : base(options)
        {
        
        }
        public DbSet<class_user_table> user_tables { get; set; }
        public DbSet<class_accounts> Accounts { get; set; }
        public DbSet<class_categeory> categeories { get; set; }
        public DbSet<class_subCategeory> subCategeories { get; set; }
        public DbSet<class_services> services { get; set; }
        public DbSet<class_sizes> sizes { get; set; }
        public DbSet<class_prices> prices { get; set; }
        public DbSet<class_roles> roles  { get; set; }
    }
}
