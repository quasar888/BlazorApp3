using Microsoft.EntityFrameworkCore;

namespace BlazorApp3.Data
{
    public class DataBaseContext:DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options)
            : base(options)
        {
            DbContextOptionsBuilder optionsBuilder = new DbContextOptionsBuilder();
            OnConfiguring( optionsBuilder);
            OnModelCreating(new ModelBuilder());
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Master;Trusted_Connection=True;MultipleActiveResultSets=true");

            }
        }
       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {               
            
            modelBuilder
        .Entity<Database>(
            eb =>
            {
                eb.HasNoKey();
            });
        }
        public DbSet<Database> databases { get; set; }
    }
}
