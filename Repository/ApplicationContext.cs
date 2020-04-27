using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace WebApplication.Repository
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
        }
        public DbSet<Driver> Driver { get; set; }
        public DbSet<Client> Client { get; set; }
        public DbSet<PersonInformation> PersonInformation { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<RoleUser> RoleUser { get; set; }
        public DbSet<Role> Role { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=blacklistV2;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Client>().HasOne(p => p.PersonInformation).WithMany(t => t.Clients).HasForeignKey(p => p.PersonInformationId);


            /*
            modelBuilder.Entity<Driver>().HasOne(p => p.PersonInformation).WithMany(t => t.Drivers).HasForeignKey(p => p.PersonInformationId);
            modelBuilder.Entity<Client>().HasOne(p => p.PersonInformation).WithMany(t => t.Clients).HasForeignKey(p => p.PersonInformationId);
            modelBuilder.Entity<Client>().HasOne(p => p.User).WithMany(t => t.Clients).HasForeignKey(p => p.CreateUserId);

            modelBuilder.Entity<Driver>().HasOne(p => p.User).WithMany(t => t.Drivers).HasForeignKey(p => p.CreateUserId);
            modelBuilder.Entity<RoleUser>().HasKey(t => new { t.RoleId, t.UserId });
            modelBuilder.Entity<RoleUser>().HasOne(sc => sc.User).WithMany(s => s.RoleUsers).HasForeignKey(sc => sc.UserId);

            modelBuilder.Entity<RoleUser>().HasOne(sc => sc.Role).WithMany(s => s.RoleUsers).HasForeignKey(sc => sc.RoleId);


            modelBuilder.Entity<User>().Property(b => b.Password).IsRequired();
            modelBuilder.Entity<User>().Property(b => b.Name).IsRequired();
            modelBuilder.Entity<User>().Property(b => b.Email).IsRequired();
            modelBuilder.Entity<User>().HasIndex(u => u.Email).IsUnique();
            */

            modelBuilder.Entity<Role>().HasData(
            new Role[]
            {
                new Role {Id=1, RoleName="Admin"},
                new Role {Id=2, RoleName="Worker"},
            });

        }
    }
}
