using Microsoft.EntityFrameworkCore;
using WpfAppDemo.Models;

namespace WpfAppDemo.Data
{
    // inherit from DbContext to create a database context for Entity Framework Core.
    public class AppDBContext : DbContext
    {
        public DbSet<User> Users { get; set; } // Represents the "Users" table in the database.
        public AppDBContext() // Constructor for the AppDBContext class.
        {
            Database.EnsureCreated(); // Ensure the database is created when the context is initialized.
                                      // Create a new database if it does not exist
            // Database is a sub-class of DbContext that provides methods for managing the database
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured) // check if the options builder
                                             // has already been configured to avoid
                                             // redundant configuration.
                optionsBuilder.UseSqlite("Data Source=WPFappLearnDB.db");
            // Configure the context to use a SQLite database named "WPFappLearnDB.db".     
        }
    }
}
