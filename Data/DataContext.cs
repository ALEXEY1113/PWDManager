using Microsoft.EntityFrameworkCore;
using PWDManager.Shared.Entities;

namespace PWDManager_BE.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Credential>? Credentials { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Credential>(m => m.HasKey(k => k.Id));
            //modelBuilder.Entity<Credential>().HasData(
            //    new Credential
            //    {
            //        Id = 1,
            //        Url = "www.nike.com",
            //        Name = "Nike",
            //        Username = "nikeUser",
            //        Password = "P4s$w0rd1!"
            //    },
            //    new Credential
            //    {
            //        Id = 2,
            //        Url = "www.adidas.com",
            //        Name = "Adi",
            //        Username = "adidasUser",
            //        Password = "P4s$w0rd2!"
            //    },
            //    new Credential
            //    {
            //        Id = 3,
            //        Url = "www.puma.com",
            //        Name = "Puma",
            //        Username = "pumaUser",
            //        Password = "P4s$w0rd3!"
            //    },
            //    new Credential
            //    {
            //        Id = 4,
            //        Url = "www.reebok.com",
            //        Name = "R-Bok",
            //        Username = "reebokUser",
            //        Password = "P4s$w0rd4!"
            //    },
            //    new Credential
            //    {
            //        Id = 5,
            //        Url = "www.joma.com",
            //        Name = "Joma",
            //        Username = "jomaUser",
            //        Password = "P4s$w0rd5!"
            //    },
            //    new Credential
            //    {
            //        Id = 6,
            //        Url = "www.asics.com",
            //        Name = "Siks",
            //        Username = "asicsUser",
            //        Password = "P4s$w0rd6!"
            //    },
            //    new Credential
            //    {
            //        Id = 7,
            //        Url = "www.underarmnor.com",
            //        Name = "U-Armor",
            //        Username = "underArmorUser",
            //        Password = "P4s$w0rd7!"
            //    }
            //);

            base.OnModelCreating(modelBuilder);
        }
    }
}
