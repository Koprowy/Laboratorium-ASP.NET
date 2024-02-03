using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<ContactEntity> Contacts { get; set; }
        public DbSet<PhotoEntity> Photos { get; set; }
        private string DbPath { get; set; }
        public AppDbContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "contacts.db");
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite($"Data Source={DbPath}", b => b.MigrationsAssembly("Laboratorium 3 - App-ns"));
        }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<ContactEntity>().HasData(
                //new ContactEntity() { Id = 1, Name = "Adam", Email = "adam@wsei.edu.pl", Phone = 127813268, Birth = new DateTime(2000, 10, 10) },
               // new ContactEntity() { Id = 2, Name = "Ewa", Email = "ewa@wsei.edu.pl", Phone = 293443829, Birth = new DateTime(1999, 8, 10) });

            modelBuilder.Entity<PhotoEntity>().HasData(
            new PhotoEntity() { Id = 1, Title = "Kraków nocą", DateTaken = new DateTime(2018, 8, 8), Description = "Panorama Krakowa Nocą", Camera = "Sony", Location = "Kraków", Author= "Kamil Kowalski", Format = "4:3", Resolution = "1920x1080" },
            new PhotoEntity() { Id = 2, Title = "Wawel", DateTaken = new DateTime(2020, 9, 11), Description = "Zdjęcie Wawelu", Camera = "Sony", Location = "Kraków", Author = "Krystian Kozłowski", Format = "4:3", Resolution = "1920x1080" });

       
        }
    }
}
