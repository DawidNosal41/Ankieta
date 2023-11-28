namespace Ankieta.Models
{
    public class PytanieAnkieta
    {
        public int Id { get; set; }
        public int PytanieId { get; set; }
        public Pytanie? Pytanie { get; set; }

        public int AnkietaId { get; set; }
        public AnkietaSzkolna? Ankieta { get; set; }
    }
}
