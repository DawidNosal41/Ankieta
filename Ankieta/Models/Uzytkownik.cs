using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Ankieta.Models
{
    public class Uzytkownik
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string UzytkownikUserId { get; set; }
        [Display(Name = "Twój e-mail")]
        public IdentityUser? UzytkownikUser { get; set; }

        public ICollection<OdpowiedzUzytkownika> OdpowiedzUzytkownikas { get; } = new List<OdpowiedzUzytkownika>();

    }
}