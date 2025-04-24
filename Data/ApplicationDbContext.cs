﻿using GovermentSystem.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SocialWelfarre.Models;

namespace SocialWelfarre.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
          : base(options)
        {

        }

        public DbSet<Program1> Programs { get; set; }
        public DbSet<FoodPack> FoodPacks { get; set; }
        public DbSet<DisasterKit> DisasterKits { get; set; }
        public DbSet<CertificateOfIndigency> CertificateOfIndigencies { get; set; }

        public DbSet<Beneficiary> Beneficiaries { get; set; }
        public DbSet<Barangay> Barangays { get; set; }

        public DbSet<Consultation> Consultations { get; set; }
        public DbSet<BeneficiaryType> BeneficiaryTypes { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; } 
        public DbSet<Department> Departments { get; set; }
        public DbSet<Designation> Designations { get; set; }
        public DbSet<User> User { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);


        }

    }
    }
