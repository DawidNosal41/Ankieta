namespace Ankieta.Models
{
    public class Odpowiedz
    {
        public int Id { get; set; }
        public string Tresc { get; set; }

        public int PytanieId { get; set; }
        public Pytanie? Pytanie { get; set; }
        public ICollection<OdpowiedzUzytkownika> OdpowiedzUzytkownikas { get; } = new List<OdpowiedzUzytkownika>();

    }
}