using CarRental.Data;
using CarRental.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CarRental.Controllers
{
    public class ReservationController : Controller
    {
        private readonly ApplicationDbContext _db;

        public Samochod Samochod { get; private set; }

        public ReservationController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Reservation(string AucSearch, string SortOrder, string SecSearch, string DataOrder)
        {
            ViewBag.Sekcja = (from x in _db.Samochody select x.Rodzaj_Nadwozia).Distinct();
            ViewData["SelectionSerach"] = SecSearch;
            ViewData["Getauctiondetails"] = AucSearch;
            ViewData["PriceSortParam"] = SortOrder == "CenaUp" ? "CenaDown" : "CenaUp";
            ViewData["DataSortParam"] = DataOrder == "DataUp" ? "DataDown" : "DataUp";
            var aucquery = _db.Samochody.Where(a => a.Dostepny.Equals(true));// from x in _db.Aukcje select x;

            if (!String.IsNullOrEmpty(AucSearch))
            {
                aucquery = aucquery.Where(x => x.Marka.Contains(AucSearch) || x.Model.Contains(AucSearch) || x.Opis.Contains(AucSearch) || x.Rodzaj_Nadwozia.Contains(AucSearch));

            }
            switch (SortOrder)
            {
                case "CenaDown":
                    aucquery = aucquery.OrderByDescending(x => x.Cena);
                    break;
                case "CenaUp":
                    aucquery = aucquery.OrderBy(x => x.Cena);
                    break;
                default:
                    break;
            }
            if (!String.IsNullOrEmpty(SecSearch))
            {
                aucquery = aucquery.Where(x => x.Rodzaj_Nadwozia.Contains(SecSearch));

            }
            return View(await aucquery.AsNoTracking().ToListAsync());
        }

        [Authorize]
        [HttpGet]
        public IActionResult ReservationDetails(int id)
        {
            Samochod = _db.Samochody.FirstOrDefault(u => u.Id == id);
            if (Samochod == null)
            {
                TempData["Error"] = "Błąd. Aukcja się zakończyła bądź nie istnieje.";
                return RedirectToAction("Index");
            }
            return View(Samochod);
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult> MakeReservation(Samochod obj)
        {
            Samochod = await _db.Samochody.FindAsync(obj.Id);
            var reservations = await _db.RezerwacjeSamochodów.Where(rs => rs.Data_Wypozyczenia == obj.Data_Wypozyczenia && rs.RelSamochod.Id == obj.Id).ToListAsync();
            var todayForComparison = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59);
            if (obj.Data_Wypozyczenia <= todayForComparison)
            {
                TempData["Error"] = "Data nie może być przeszła!";
                return View("ReservationDetails", Samochod);
            }
            else if (reservations.Count <1 )
            {
                var rezerwacja = new RezerwacjaSamochodu()
                {
                    Samochod = obj.Id,
                    RelSamochod = _db.Samochody.Find(obj.Id),
                    Uzytkownik = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value,
                    Data_Wypozyczenia = obj.Data_Wypozyczenia,
                    Koszt = obj.Cena,
                    Zdjecie = obj.Zdjecie,
                    Nazwa = obj.Marka + " " + obj.Model + " " + obj.Rocznik,
                    Oplacona = false
                };
                _db.RezerwacjeSamochodów.Add(rezerwacja);
                await _db.SaveChangesAsync();
                ViewBag.Success = true;
                System.Threading.Thread.Sleep(1000);

                return View("ReservationDetails", Samochod);
            }
            else if (reservations.Count >= 1)
            {
                TempData["Error"] = "Wybrany termin jest już zajęty";
                return View("ReservationDetails", Samochod);
            }
            else 
            {
                TempData["Error"] = "Wystąpił nieoczikowany bład. Spróbuj ponownie";
                return View("ReservationDetails", Samochod);
            }
        }
        [Authorize]
        [HttpPost]
        public async Task<ActionResult> CheckReservation(Samochod obj)
        {
            Samochod = await _db.Samochody.FindAsync(obj.Id);
            var reservations = await _db.RezerwacjeSamochodów.Where(rs => rs.Data_Wypozyczenia == obj.Data_Wypozyczenia && rs.RelSamochod.Id == obj.Id).ToListAsync();
            var todayForComparison = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59);
            if (obj.Data_Wypozyczenia <= todayForComparison)
            {
                TempData["Error"] = "Data nie może być przeszła!";
                return View("ReservationDetails", Samochod);
            }
            else if (reservations.Count < 1)
            {
                ViewBag.InfoSuccess = true;
                System.Threading.Thread.Sleep(1000);

                return View("ReservationDetails", Samochod);
            }
            else if (reservations.Count >= 1)
            {
                TempData["Error"] = "Wybrany termin jest już zajęty";
                return View("ReservationDetails", Samochod);
            }
            else
            {
                TempData["Error"] = "Wystąpił nieoczikowany bład. Spróbuj ponownie";
                return View("ReservationDetails", Samochod);
            }
        }
        [HttpGet("myReservations")]
        [Authorize]
        public IActionResult MyReservations()
        {
            var myAccount = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
            IEnumerable<RezerwacjaSamochodu> objList = _db.RezerwacjeSamochodów.Where(s => s.Uzytkownik == myAccount);
            return View(objList);       
        }
    }
}
