namespace Ankieta.Models
{
    public class Odpowiedz
    {
        public int Id { get; set; }
        public string Tresc { get; set; }
        public ICollection<OdpowiedzUzytkownika> OdpowiedzUzytkownikas { get; } = new List<OdpowiedzUzytkownika>();

    }
}