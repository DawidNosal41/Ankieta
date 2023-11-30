using Microsoft.AspNetCore.Identity;

namespace Ankieta.Models
{
    public class Uzytkownik
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string UzytkownikUserId { get; set; }
        public IdentityUser? UzytkownikUser { get; set; }

        public ICollection<OdpowiedzUzytkownika> OdpowiedzUzytkownikas { get; } = new List<OdpowiedzUzytkownika>();

    }
}