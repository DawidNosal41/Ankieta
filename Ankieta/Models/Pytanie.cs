namespace Ankieta.Models
{
    public class Pytanie
    {
        public int Id { get; set; }
        public string Tresc { get; set; }
        public string TypPytania { get; set; }

        public ICollection<PytanieAnkieta> PytanieAnkietas { get; } = new List<PytanieAnkieta>();
    }
}