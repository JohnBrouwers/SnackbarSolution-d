using Microsoft.EntityFrameworkCore;
using Snackbar.Core.Entities;

namespace Snackbar.API.Data
{
    public class SnackbarDbContext : DbContext
    {
        public SnackbarDbContext (DbContextOptions<SnackbarDbContext> options)
            : base(options)
        {
        }

        public DbSet<Snack> Snacks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Snack>(s => {
                s.Property(s => s.Name).IsRequired().HasMaxLength(SnackValidation.NameMaxLength);
                s.Property(s => s.Price).IsRequired().HasPrecision(5, 2);

                s.HasData(new Snack { Id = 1, Name = "Patatje Speciaal", Price = 2.75M });
            });
        }
    }
}
