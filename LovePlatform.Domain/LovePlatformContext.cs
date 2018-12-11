using LovePlatform.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LovePlatform.Domain
{
   public class LovePlatformContext:DbContext
    {
        public LovePlatformContext(DbContextOptions<LovePlatformContext> options) : base(options)
        { }

        /// <summary>
        /// DbSet属性统一为复数，对应的数据库表不带复数
        /// </summary>
        public DbSet<Administrator> Administrators { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Weight> Weights { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Diagnose> Diagoses { get; set; }
        public DbSet<Treat> Treats { get; set; }
        public DbSet<TreatImage> TreatImages { get; set; }
        public DbSet<BloodPressure> BloodPressures { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Administrator>().ToTable("S_Administrator");
            modelBuilder.Entity<Patient>().ToTable("P_Patient");
            modelBuilder.Entity<Weight>().ToTable("P_Weight");
            modelBuilder.Entity<User>().ToTable("P_User");
            modelBuilder.Entity<Diagnose>().ToTable("P_Diagnose");
            modelBuilder.Entity<Treat>().ToTable("P_Treat");
            modelBuilder.Entity<TreatImage>().ToTable("P_TreatImage");
            modelBuilder.Entity<BloodPressure>().ToTable("P_BloodPressure");
        }
    }
}
