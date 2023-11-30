namespace Ankieta.Models
{
    public class OdpowiedzUzytkownika
    {
        public int Id { get; set; }
        public int PytanieId { get; set; }
        public Pytanie? Pytanie { get; set; }

        public int OdpowiedzId { get; set; }
        public Odpowiedz? Odpowiedz { get; set; }

        public int UzytkownikId { get; set; }
        public Uzytkownik? Uzytkownik { get; set; }


     



    }
}
