using SocialWelfarre.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SocialWelfarre.Models;


namespace SocialWelfarre.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
          : base(options)
        {

        }

        public DbSet<DisasterKitTransaction> DisasterKitTransactions { get; set; }
  
        public DbSet<CertificateOfIndigency> CertificateOfIndigencies { get; set; }
        public DbSet<Consultation> Consultations { get; set; }
        public DbSet<FoodPackForm> FoodPackForms { get; set; }
        public DbSet<Certificate_Of_Indigency> Certificate_Of_Indigencies { get; set; }
        public DbSet<ApplicationFoodPack> ApplicationFoodPack { get; set; } 
        public DbSet<AuditLog> AuditLogs { get; set; } = default!;
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<ApplicationUser>()
       .HasIndex(u => u.NormalizedEmail)
       .IsUnique();
        }
       

    }
    }
