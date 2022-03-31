using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CarRental.Models
{
    public class Samochod
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Marka jest wymagana!")]
        public string Marka { get; set; }
        [Required(ErrorMessage = "Model jest wymagany!")]
        public string Model { get; set; }
        [Required(ErrorMessage = "Rocznik jest wymagany!")]
        public int Rocznik { get; set; }
        public string Opis { get; set; }
        [Required(ErrorMessage = "Rodzaj nadwozia jest wymagany!")]
        public string Rodzaj_Nadwozia { get; set; }
        [Required(ErrorMessage = "Rodzaj skrzyni biegów jest wymagany!")]
        public string Rodzaj_Skrzyni_Biegow { get; set; }
        [Required(ErrorMessage = "Rodzaj paliwa jest wymaganu!")]
        public string Rodzaj_Paliwa { get; set; }
        [Required(ErrorMessage = "Kolor jest wymagany!")]
        public string Kolor { get; set; }
        [Required(ErrorMessage = "Moc jest wymagana!")]
        public int Moc { get; set; }
        public int Liczba_Miejsc { get; set; }
        public int Liczba_Drzwi { get; set; }
        [Required(ErrorMessage = "Cena jest wymagana!")]
        [DataType(DataType.Currency, ErrorMessage = "Podaj cenę za pomocą liczb w formacie 1 000,00")]
        [Column(TypeName = "decimal(18, 2)")]
        [RegularExpression((@"^[0-9]*,[0-9]{2}$"), ErrorMessage = "Podaj cenę w formacie 100 000,00")]
        public decimal? Cena { get; set; }
        [NotMapped]
        public IFormFile Pliki { get; set; }
        public string Zdjecie { get; set; }
        public bool Dostepny { get; set; }
        [NotMapped]
        public DateTime? Data_Wypozyczenia { get; set; }
        [NotMapped]
        public DateTime? Data_Oddania { get; set; }
    }
};
