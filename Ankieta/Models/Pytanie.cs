namespace Ankieta.Models
{
    public class Pytanie
    {
        public int Id { get; set; }
        public string Tresc { get; set; }
        public string TypPytania { get; set; }

        public int AnkietaSzkolnaId { get; set; }
        public AnkietaSzkolna? AnkietaSzkolna { get; set; }

        public ICollection<Odpowiedz> Odpowiedzi { get;  } = new List<Odpowiedz>();
        public ICollection<OdpowiedzUzytkownika> OdpowiedzUzytkownika { get; } = new List<OdpowiedzUzytkownika>();

    }
}