using Ankieta.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Diagnostics.Metrics;
using System.Drawing.Drawing2D;
using System.Drawing;
using Ankieta.Models;

namespace Rejestr.Data
{
    public class DbInitializer
    {
        public static async Task InitializeAsync(ApplicationDbContext context, UserManager<IdentityUser> _userManager)
        {
            context.Database.EnsureCreated();
            if (context.Odpowiedz.Any())
            {
                return;
            }
            var Pytanie = new Odpowiedz[]
            {
                new Odpowiedz { Tresc = "GTA V" },
                new Odpowiedz { Tresc = "Fortnite" },
                new Odpowiedz { Tresc = "Fifa 23" },
                new Odpowiedz { Tresc = "EA 24" },

            };
            foreach (var odpowiedzs in Pytanie)
            {
                context.Odpowiedz.Add(odpowiedzs);
            }

            context.SaveChanges();
        }
    }
}