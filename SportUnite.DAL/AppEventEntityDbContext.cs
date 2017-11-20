using Microsoft.EntityFrameworkCore;
using SportUnite.Domain.Models;

namespace SportUnite.DAL
{
    public class AppEventEntityDbContext : DbContext
    {
        public AppEventEntityDbContext() { }

        public AppEventEntityDbContext(DbContextOptions<AppEventEntityDbContext> options)
            : base(options) { }

        public virtual DbSet<Invoice> Invoice { get; set; }
        public virtual DbSet<Sport> Sport { get; set; }
        public virtual DbSet<SportAttribute> SportAttribute { get; set; }
        public virtual DbSet<SportComplex> SportComplex { get; set; }
        public virtual DbSet<SportEvent> SportEvent { get; set; }
        public virtual DbSet<SportHall> SportHall { get; set; }
        public virtual DbSet<SportSportAttribute> SportSportAttribute { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SportSportAttribute>()
                .HasKey(t => new { t.SportId, t.SportAttributeId });

            modelBuilder.Entity<SportSportAttribute>()
                .HasOne(pt => pt.SportAttribute)
                .WithMany(p => p.SportSportAttributes)
                .HasForeignKey(pt => pt.SportAttributeId);

            modelBuilder.Entity<SportSportAttribute>()
                .HasOne(pt => pt.Sport)
                .WithMany(t => t.SportSportAttributes)
                .HasForeignKey(pt => pt.SportId);

            modelBuilder.Entity<Sport>()
                .Property(b => b.Availability)
                .HasDefaultValue(true);

            modelBuilder.Entity<SportAttribute>()
                .Property(b => b.Availability)
                .HasDefaultValue(true);

            modelBuilder.Entity<SportComplex>()
                .Property(b => b.Availability)
                .HasDefaultValue(true);

            modelBuilder.Entity<SportEvent>()
                .Property(b => b.Availability)
                .HasDefaultValue(true);

            modelBuilder.Entity<SportHall>()
                .Property(b => b.Availability)
                .HasDefaultValue(true);

            modelBuilder.Entity<Invoice>()
                .Property(b => b.Availability)
                .HasDefaultValue(true);
        } 
    }
}