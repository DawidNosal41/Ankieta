namespace Ankieta.Models
{
    public class AnkietaSzkolna
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartData { get; set; }
        public DateTime EndData { get; set; }

        public ICollection<PytanieAnkieta> PytanieAnkietas { get; } = new List<PytanieAnkieta>();

    }
}
