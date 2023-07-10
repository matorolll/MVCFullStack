using Microsoft.EntityFrameworkCore;

namespace MVCFullStack.Data

{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context>options) : base(options)
        {
            
        }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, Name = "Action", DisplayOrder = 1},
                new Category { CategoryId = 2, Name = "SciFi", DisplayOrder = 2},
                new Category { CategoryId = 3, Name = "History", DisplayOrder = 3},
                new Category { CategoryId = 4, Name = "Comedy", DisplayOrder = 4}
                );
        }
    }
}
