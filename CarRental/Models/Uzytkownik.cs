using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CarRental.Models
{
    public class Uzytkownik
    {
        [Key]

        public int Id { get; set; }
        [Required(ErrorMessage = "To pole jest wymagane")]
        [MinLength(6, ErrorMessage = "Nazwa użytkownika musi zawierać minimum 6 znaków")]
        [MaxLength(12, ErrorMessage = "Nazwa użytkownika musi zawierać minimum 6 znaków")]
        [RegularExpression((@"[A-Za-z0-9_]+$"), ErrorMessage = "Nazwa użytkownika nie może zawierać znaków specjalnych")]
        public string Nazwa_uzytkownika { get; set; }
        [RegularExpression((@"^.*(?=.{8,12})(?=.*[\d])(?=.*[a-zA-Z]).*$"), ErrorMessage = "Hasło powinno zawierać minimum 8 znaków, w tym jedną cyfrę i literę")]
        [Required(ErrorMessage = "To pole jest wymagane")]
        [MaxLength(60, ErrorMessage = "Hasło nie może zawierać więcej niż 12 znaków")]
        [DataType(DataType.Password)]
        public string Hasło { get; set; }
        [NotMapped]
        [RegularExpression((@"^.*(?=.{8,12})(?=.*[\d])(?=.*[a-zA-Z]).*$"), ErrorMessage = "Hasła się nie zgadzają")]
        [Required(ErrorMessage = "To pole jest wymagane")]
        [DataType(DataType.Password)]
        [MaxLength(60)]
        [Compare("Hasło",ErrorMessage ="Hasła się nie zgadzają")]
        public string Potwierdz_Haslo { get; set; }

        public string Rola { get; set; }
        [MaxLength(60)]
        [RegularExpression((@"^[a-zA-Z]+$"), ErrorMessage = "Imię może zawierać tylko litery")]
        public string Imie { get; set; }
        [MaxLength(60)]
        [RegularExpression((@"^[a-zA-Z]+$"), ErrorMessage = "Nazwisko może zawierać tylko litery")]
        public string Nazwisko { get; set; }
        public string Numer_telefonu { get; set; }
        [MaxLength(60)]
        [RegularExpression((@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"), ErrorMessage = "Wprowadź poprawny adres email")]
        public string Email { get; set; }
        
    }
}
