using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using Uber.Model;

namespace Uber.DBContext
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        // Tables
        public DbSet<User> Users { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Ride> Rides { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Rating> Ratings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // =========================
            // User Configuration
            // =========================

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(u => u.Id);

                entity.Property(u => u.FullName)
                      .IsRequired()
                      .HasMaxLength(100);

                entity.Property(u => u.Email)
                      .IsRequired();

                entity.HasIndex(u => u.Email)
                      .IsUnique();

                entity.Property(u => u.Password)
                      .IsRequired();

                entity.Property(u => u.Phone)
                      .IsRequired();

                entity.Property(u => u.Role)
                      .IsRequired()
                      .HasConversion<string>();
            });

            // =========================
            // User - Vehicle (1:1)
            // =========================

            modelBuilder.Entity<User>()
                .HasOne(u => u.Vehicle)
                .WithOne(v => v.Driver)
                .HasForeignKey<Vehicle>(v => v.DriverId)
                .OnDelete(DeleteBehavior.Restrict);

            // =========================
            // Vehicle Configuration
            // =========================

            modelBuilder.Entity<Vehicle>(entity =>
            {
                entity.HasKey(v => v.Id);

                entity.Property(v => v.Model)
                      .IsRequired()
                      .HasMaxLength(50);

                entity.Property(v => v.PlateNumber)
                      .IsRequired()
                      .HasMaxLength(20);

                entity.HasIndex(v => v.PlateNumber)
                      .IsUnique();

                entity.Property(v => v.Color)
                      .IsRequired();

                entity.Property(v => v.DriverId)
                      .IsRequired();
            });

            // =========================
            // Driver - Rides (1:M)
            // =========================

            modelBuilder.Entity<Ride>()
                .HasOne(r => r.Driver)
                .WithMany(u => u.DriverRides)
                .HasForeignKey(r => r.DriverId)
                .OnDelete(DeleteBehavior.Restrict);

            // =========================
            // Rider - Rides (1:M)
            // =========================

            modelBuilder.Entity<Ride>()
                .HasOne(r => r.Rider)
                .WithMany(u => u.RiderRides)
                .HasForeignKey(r => r.RiderId)
                .OnDelete(DeleteBehavior.Restrict);

            // =========================
            // Ride Configuration
            // =========================

            modelBuilder.Entity<Ride>(entity =>
            {
                entity.HasKey(r => r.Id);

                entity.Property(r => r.PickupLocation)
                      .IsRequired()
                      .HasMaxLength(150);

                entity.Property(r => r.DropOffLocation)
                      .IsRequired()
                      .HasMaxLength(150);

                entity.Property(r => r.Fare)
                      .HasPrecision(10, 2);

                entity.Property(r => r.Status)
                      .IsRequired()
                      .HasConversion<string>();

                entity.HasOne(r => r.Payment)
                      .WithOne(p => p.Ride)
                      .HasForeignKey<Payment>(p => p.RideId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(r => r.Rating)
                      .WithOne(rating => rating.Ride)
                      .HasForeignKey<Rating>(rating => rating.RideId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // =========================
            // Payment Configuration
            // =========================

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.HasKey(p => p.Id);

                entity.Property(p => p.Amount)
                      .HasPrecision(10, 2);

                entity.Property(p => p.PaymentMethod)
                      .IsRequired()
                      .HasConversion<string>();

                entity.Property(p => p.PaymentDate)
                      .IsRequired();

                entity.Property(p => p.Status)
                      .IsRequired()
                      .HasConversion<string>();

                entity.HasIndex(p => p.RideId)
                      .IsUnique();
            });

            // =========================
            // Rating Configuration
            // =========================

            modelBuilder.Entity<Rating>(entity =>
            {
                entity.HasKey(r => r.Id);

                entity.Property(r => r.Score)
                      .IsRequired();

                entity.Property(r => r.Comment)
                      .HasMaxLength(250);

                entity.HasIndex(r => r.RideId)
                      .IsUnique();
            });
        }
    }
}
