using CarRental.Data;
using CarRental.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CarRental.Controllers
{
    [Authorize(Roles = "A")]
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _db;

        public AdminController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("create")]
        public IActionResult Create()
        {
            ViewBag.Success = TempData["Success"] as bool?;
            return View();
        }

        [HttpPost("create")]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Samochod obj)
        {
            var samochod = new Samochod()
            {
                Id = obj.Id,
                Marka = obj.Marka,
                Model = obj.Model,
                Rocznik = obj.Rocznik,
                Opis = obj.Opis,
                Rodzaj_Nadwozia = obj.Rodzaj_Nadwozia,
                Rodzaj_Skrzyni_Biegow = obj.Rodzaj_Skrzyni_Biegow,
                Rodzaj_Paliwa = obj.Rodzaj_Paliwa,
                Kolor = obj.Kolor,
                Moc = obj.Moc,
                Liczba_Miejsc = obj.Liczba_Miejsc,
                Liczba_Drzwi = obj.Liczba_Drzwi,
                Cena = obj.Cena,
                Zdjecie = obj.Zdjecie,
                Dostepny = obj.Dostepny
            };

            if (obj.Pliki != null)
            {
                string unique_file_name = (obj.Marka + "_" + obj.Model + "_" + obj.Pliki.FileName);
                samochod.Zdjecie = unique_file_name;
                var path = Path.Combine(_db.WebHostEnv.WebRootPath, "Upload/images", samochod.Zdjecie);
                var stream = new FileStream(path, FileMode.Create);
                obj.Pliki.CopyTo(stream);

            }
            else
            {
                TempData["Error"] = "Błąd. Nie dodano zdjęcia!";
                System.Threading.Thread.Sleep(1000);
                return View("Create", samochod);

            }

            if (ModelState.IsValid)
            {
                obj.Dostepny = true;
                _db.Samochody.Add(samochod);
                _db.SaveChanges();
                TempData["Success"] = true;
                System.Threading.Thread.Sleep(1000);
                return Redirect("Create");
            }
            else
            {
                TempData["Error"] = "Błąd. Dane są nie prawidłowe";
                return View("Create", samochod);
            }
        }

        [BindProperty]
        public Samochod Samochod { get; set; }
        public Pytanie Pytanie { get; set; }

        public RezerwacjaSamochodu Rezerwacje { get; set; }
        public IActionResult Edit()
        {
            IEnumerable<Samochod> objList = _db.Samochody;
            return View(objList);
        }

        [HttpGet("edit")]
        public IActionResult EditDetails(int id)
        {
            Samochod = _db.Samochody.FirstOrDefault(u => u.Id == id);
            if (Samochod == null)
            {
                return NotFound();
            }
            return View(Samochod);
        }

        [HttpPost("edit")]
        public async Task<IActionResult> UpdateData(Samochod obj)
        {


                var samochod = await _db.Samochody.FindAsync(obj.Id);

                samochod.Id = obj.Id;
                samochod.Marka = obj.Marka;
                samochod.Model = obj.Model;
                samochod.Rocznik = obj.Rocznik;
                samochod.Opis = obj.Opis;
                samochod.Rodzaj_Nadwozia = obj.Rodzaj_Nadwozia;
                samochod.Rodzaj_Skrzyni_Biegow = obj.Rodzaj_Skrzyni_Biegow;
                samochod.Rodzaj_Paliwa = obj.Rodzaj_Paliwa;
                samochod.Kolor = obj.Kolor;
                samochod.Moc = obj.Moc;
                samochod.Liczba_Miejsc = obj.Liczba_Miejsc;
                samochod.Liczba_Drzwi = obj.Liczba_Drzwi;
                samochod.Cena = obj.Cena;

                if (obj.Pliki != null)
                {
                    //Usuń aktualne zdjęcie
                    var deletePath = Path.Combine(_db.WebHostEnv.WebRootPath, "Upload/images", samochod.Zdjecie);
                    if (System.IO.File.Exists(deletePath))
                    {
                        System.IO.File.Delete(deletePath);
                    }
                //Dodaj aktualne zdjęcie                  
                    string unique_file_name;
                    unique_file_name = (obj.Marka + "_" + obj.Model + "_" + obj.Pliki.FileName);
                    samochod.Zdjecie = unique_file_name;
                    var addPath = Path.Combine(_db.WebHostEnv.WebRootPath, "Upload/images", samochod.Zdjecie);
                    var stream = new FileStream(addPath, FileMode.Create);
                    obj.Pliki.CopyTo(stream);
                }
            if (ModelState.IsValid)
            {
                await _db.SaveChangesAsync();
                IEnumerable<Samochod> objList = _db.Samochody;
                return View("Edit", objList);
            }
            else
            {
                return View("EditDetails", obj);
            }
        }

        [HttpPost]
        public async Task<IActionResult> DeletePost(int id)
        {
            var auctionDb = await _db.Samochody.FindAsync(id);
            if (auctionDb == null)
            {
                return NotFound();
            }
            _db.Samochody.Remove(auctionDb);
            await _db.SaveChangesAsync();
            IEnumerable<Samochod> objList = _db.Samochody;
            return View("Edit", objList);
        }

        public IActionResult Question()
        {
            IEnumerable<Pytanie> objList = _db.Pytania;
            return View(objList);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteQuestion(int id)
        {
            var questionDb = await _db.Pytania.FindAsync(id);
            if (questionDb == null)
            {
                return NotFound();
            }
            _db.Pytania.Remove(questionDb);
            await _db.SaveChangesAsync();
            IEnumerable<Pytanie> objList = _db.Pytania;
            return View("Question", objList);
        }

        [HttpPost]
        public async Task<IActionResult> ChangeStatus(int id)
        {
            Samochod = await _db.Samochody.FindAsync(id);
            if (Samochod == null)
            {
                return NotFound();
            }
            else if (Samochod.Dostepny == true)
            {
                Samochod.Dostepny = false;
            }
            else if (Samochod.Dostepny == false)
            {
                Samochod.Dostepny = true;
            }
            await _db.SaveChangesAsync();
            IEnumerable<Samochod> objList = _db.Samochody;
            return View("Edit", objList);
        }

        public IActionResult ReservationList()
        {
            IEnumerable<RezerwacjaSamochodu> objList = _db.RezerwacjeSamochodów;
            return View(objList);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteReservation(int id)
        {
            var reservationDb = await _db.RezerwacjeSamochodów.FindAsync(id);
            if (reservationDb == null)
            {
                return NotFound();
            }
            _db.RezerwacjeSamochodów.Remove(reservationDb);
            await _db.SaveChangesAsync();
            IEnumerable<RezerwacjaSamochodu> objList = _db.RezerwacjeSamochodów;
            return View("ReservationList", objList);
        }
        [HttpPost]
        public async Task<IActionResult> ReservationPayment(int id)
        {
            Rezerwacje = await _db.RezerwacjeSamochodów.FindAsync(id);
            if (Rezerwacje == null)
            {
                return NotFound();
            }
            else if (Rezerwacje.Oplacona != true)
            {
                Rezerwacje.Oplacona = true;
            }
            await _db.SaveChangesAsync();
            IEnumerable<RezerwacjaSamochodu> objList = _db.RezerwacjeSamochodów;
            return View("ReservationList", objList);
        }
    }
}
