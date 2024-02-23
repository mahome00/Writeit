using Microsoft.EntityFrameworkCore;

namespace Writeit.Models
{
    public class AnvandareContext:DbContext
        
    {
        public DbSet<Anvandare> anvandares { get; set; }
        public DbSet<Bocker> bockers { get; set; }

        public AnvandareContext()
        {

            Database.EnsureCreated();
        }


        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite("DataSource = BockerDb.db"); //Databasfilens namn
        }
    }
}
