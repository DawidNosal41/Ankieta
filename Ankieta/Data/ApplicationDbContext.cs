using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Ankieta.Models;

namespace Ankieta.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Ankieta.Models.AnkietaSzkolna>? AnkietaSzkolna { get; set; }
        public DbSet<Ankieta.Models.Odpowiedz>? Odpowiedz { get; set; }
        public DbSet<Ankieta.Models.OdpowiedzUzytkownika>? OdpowiedzUzytkownika { get; set; }
        public DbSet<Ankieta.Models.Pytanie>? Pytanie { get; set; }
        public DbSet<Ankieta.Models.Uzytkownik>? Uzytkownik { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<OdpowiedzUzytkownika>().HasOne(e=>e.Pytanie).WithMany(e=>e.OdpowiedzUzytkownika).Metadata.DeleteBehavior=DeleteBehavior.Restrict;
            //builder.Entity<OdpowiedzUzytkownika>().HasOne(e => e.Pytanie).WithMany(e => e.OdpowiedzUzytkownika).Metadata.DeleteBehavior = DeleteBehavior.Restrict;
        }
    }
}