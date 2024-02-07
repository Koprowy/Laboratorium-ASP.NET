using Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
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
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<ContactEntity> Contacts { get; set; }
        public DbSet<PhotoEntity> Photos { get; set; }
        public DbSet<OrganizationEntity> Organizations { get; set; }
        private string DbPath { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options)
          : base(options)
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
            base.OnModelCreating(modelBuilder);

            string ADMIN_ID = Guid.NewGuid().ToString();
            string ADMIN_ROLE_ID = Guid.NewGuid().ToString();
            string USER_ID = Guid.NewGuid().ToString();
            string USER_ROLE_ID = Guid.NewGuid().ToString();

            // Dodanie roli administratora i użytkownika
            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole { Name = "admin", NormalizedName = "ADMIN", Id = ADMIN_ROLE_ID, ConcurrencyStamp = ADMIN_ROLE_ID },
                new IdentityRole { Name = "user", NormalizedName = "USER", Id = USER_ROLE_ID, ConcurrencyStamp = USER_ROLE_ID });

            // Utworzenie administratora i użytkownika
            var admin = new IdentityUser
            {
                Id = ADMIN_ID,
                Email = "adam@wsei.edu.pl",
                EmailConfirmed = true,
                UserName = "adam",
                NormalizedUserName = "ADMIN",
                NormalizedEmail = "ADAM@WSEI.EDU.PL"
            };

            var user = new IdentityUser
            {
                Id = USER_ID,
                Email = "kamil@wsei.edu.pl",
                EmailConfirmed = true,
                UserName = "kamil",
                NormalizedUserName = "LOGINTESTOWY",
                NormalizedEmail = "KAMIL@WSEI.EDU.PL"
            };

            // Haszowanie haseł
            PasswordHasher<IdentityUser> ph = new PasswordHasher<IdentityUser>();
            admin.PasswordHash = ph.HashPassword(admin, "1234abcd!@#$ABCD");
            user.PasswordHash = ph.HashPassword(user, "Bezimienny1!");

            // Zapisanie użytkowników
            modelBuilder.Entity<IdentityUser>().HasData(admin, user);

            // Przypisanie roli administratora i użytkownika
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string> { RoleId = ADMIN_ROLE_ID, UserId = ADMIN_ID },
                new IdentityUserRole<string> { RoleId = USER_ROLE_ID, UserId = USER_ID });

            modelBuilder.Entity<OrganizationEntity>().OwnsOne(e => e.Address);

            modelBuilder.Entity<ContactEntity>()
                        .HasOne(e => e.Organization)
                        .WithMany(o => o.Contacts)
                        .HasForeignKey(e => e.OrganizationId);

            modelBuilder.Entity<OrganizationEntity>().HasData(
                new OrganizationEntity() { Id = 1, Title = "WSEI", Nip = "83492384", Regon = "13424234", },
                new OrganizationEntity() { Id = 2, Title = "Firma", Nip = "2498534", Regon = "0873439249", });

            modelBuilder.Entity<ContactEntity>().HasData(
                new ContactEntity() { Id = 1, Name = "Adam", Email = "adam@wsei.edu.pl", Phone = 127813268, Birth = new DateTime(2000, 10, 10), OrganizationId = 1 },
                new ContactEntity() { Id = 2, Name = "Ewa", Email = "ewa@wsei.edu.pl", Phone = 293443829, Birth = new DateTime(1999, 8, 10), OrganizationId = 2 });

            modelBuilder.Entity<PhotoEntity>().HasData(
                new PhotoEntity() { Id = 1, Title = "Kraków nocą", DateTaken = new DateTime(2018, 8, 8), Description = "Panorama Krakowa Nocą", Camera = "Sony", Location = "Kraków", Author = "Kamil Kowalski", Format = "4:3", Resolution = "1920x1080" },
                new PhotoEntity() { Id = 2, Title = "Wawel", DateTaken = new DateTime(2020, 9, 11), Description = "Zdjęcie Wawelu", Camera = "Sony", Location = "Kraków", Author = "Krystian Kozłowski", Format = "4:3", Resolution = "1920x1080" });
            modelBuilder.Entity<OrganizationEntity>()
                                             .OwnsOne(e => e.Address)
                                             .HasData(
                new { OrganizationEntityId = 1, City = "Kraków", Street = "Św. Filipa 17", PostalCode = "31-150", Region = "małopolskie" },
                new { OrganizationEntityId = 2, City = "Kraków", Street = "Krowoderska 45/6", PostalCode = "31-150", Region = "małopolskie" }
       );


        }
    }
}