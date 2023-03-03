using finalProject.Entities.Concretes.Categories;
using finalProject.Entities.Concretes.Users;
using Microsoft.EntityFrameworkCore;

namespace finalProject.DataAccess.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<CategoryType> CategoryTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            const string connectionString = "Data Source=DESKTOP-LES9OTM; Initial Catalog=FinalProject_Ecommerce_Db; Trusted_Connection=true; MultipleActiveResultSets=true; TrustServerCertificate=True";
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().Property(u => u.Role).HasDefaultValue("user");
        }
    }
}
