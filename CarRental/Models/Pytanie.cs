using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarRental.Models
{
    public class Pytanie
	{
		[Key]
		public int Id { get; set; }

		[MaxLength(40)]
		[Required(ErrorMessage = "Pole wymagane.")]
		public string Tytulu { get; set; }

		[MaxLength(300)]
		[Required(ErrorMessage = "Pole wymagane.")]
		public string Tresc { get; set; }

		[MaxLength(60)]
		[RegularExpression((@"^[a-zA-Z]+$"), ErrorMessage = "Imię może zawierać tylko litery!")]
		public string Imie { get; set; }

		[MaxLength(60)]
		[RegularExpression((@"^[a-zA-Z]+$"), ErrorMessage = "Nazwisko może zawierać tylko litery!")]
		public string Nazwisko { get; set; }

		[MaxLength(11)]
		[RegularExpression((@"([0-9]{3}\s?){3}"), ErrorMessage = "Podaj numer telefonu w formacie \"000 000 000\".")]
		public string Numer_Kontaktowy { get; set; }
		[MaxLength(60)]
		[RegularExpression((@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"), ErrorMessage = "Wprowadź poprawny adres email")]
		public string Email { get; set; }

	}
}
