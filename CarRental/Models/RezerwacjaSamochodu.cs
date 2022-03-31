using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CarRental.Models
{
    public class RezerwacjaSamochodu
    {
        public int Id { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Samochod RelSamochod { get; set; }
        public int Samochod { get; set; }
        public string Uzytkownik { get; set; }
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime? Data_Wypozyczenia { get; set; }
        public decimal? Koszt { get; set; }
        public string Zdjecie { get; set; }
        public string Nazwa { get; set; }
        public bool Oplacona { get; set; }
    }
}
