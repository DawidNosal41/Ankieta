using System.ComponentModel.DataAnnotations;

namespace Ankieta.Models
{
    public class AnkietaSzkolna
    {
        public int Id { get; set; }

        [Display (Name = "Temat Ankiety")]
        public string Name { get; set; }
        [Display(Name = "Opis")]
        public string Description { get; set; }
        [Display(Name = "Aktywna od: ")]
        public DateTime StartData { get; set; }
        [Display(Name = "Temat Ankiety")]
        public DateTime EndData { get; set; }




    }
}
