namespace Ankieta.Models
{
    public class OdpowiedzUzytkownika
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Tresc { get; set; }

        public int UzytkownikId { get; set; }
        public Uzytkownik? Uzytkownik { get; set; }

        public int OdpowiedzId { get; set; }
        public Odpowiedz? Odpowiedz { get; set; }

        public ICollection<Pytanie> Pytanies { get; } = new List<Pytanie>();



    }
}
