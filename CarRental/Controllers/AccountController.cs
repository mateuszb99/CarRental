using CarRental.Data;
using CarRental.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _db;


        public AccountController(ApplicationDbContext db)
        {
            _db = db;
        }
        [Authorize]
        public IActionResult Account()
        {
            var userId = HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
            var loggedUser = new Uzytkownik();
            loggedUser = _db.Uzytkownicy.FirstOrDefault(u => u.Nazwa_uzytkownika == userId);
            return View(loggedUser);
        }

        [Authorize]
        [HttpGet("edituser")]
        public IActionResult EditUser()
        {
            var userId = HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
            var loggedUser = new Uzytkownik();
            loggedUser = _db.Uzytkownicy.FirstOrDefault(u => u.Nazwa_uzytkownika == userId);
            return View("EditUser", loggedUser);
        }

        [Authorize]
        [HttpPost("edituser")]
        public async Task<IActionResult> UpdateData(Uzytkownik obj, string password)
        {
            var loggedUsername = HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
            if (obj.Nazwa_uzytkownika == loggedUsername || !_db.Uzytkownicy.Any(x => x.Nazwa_uzytkownika == obj.Nazwa_uzytkownika)) //Jeśli nazwa pozostaje taka sama lub nie istnieje użytkownik o wybranej nazwie
            {
                ModelState.Remove("Potwierdz_Haslo");
                ModelState.Remove("Hasło");
                if (ModelState.IsValid)
                {
                    var userFromDb = _db.Uzytkownicy.FirstOrDefault(x => x.Nazwa_uzytkownika == loggedUsername);
                    userFromDb.Nazwa_uzytkownika = obj.Nazwa_uzytkownika;
                    //Usunięcie ciastek ze starą nazwą i zastąpienie ich nową
                    var newclaims = new List<Claim>();
                    foreach (Claim item in this.HttpContext.User.Claims)
                    {
                        if (item.Type == ClaimTypes.NameIdentifier)
                        {
                            newclaims.Add(new Claim(ClaimTypes.NameIdentifier, obj.Nazwa_uzytkownika));
                        }
                        newclaims.Add(item);
                    }
                    await HttpContext.SignOutAsync();
                    var claimsIdentity = new ClaimsIdentity(newclaims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                    await HttpContext.SignInAsync(claimsPrincipal);

                    userFromDb.Imie = obj.Imie;
                    userFromDb.Nazwisko = obj.Nazwisko;
                    userFromDb.Numer_telefonu = obj.Numer_telefonu;
                    userFromDb.Email = obj.Email;

                    await _db.SaveChangesAsync();
                    return View("Account", userFromDb);
                }

            }
            else
            {
                ViewBag.DuplicateMessage = "Nazwa użytkownika już zajęta!";
                return View("EditUser", obj);
            }
            return View("EditUser", obj);
        }

        [Authorize]
        [HttpGet("edituserpassword")]
        public IActionResult EditUserPassword()
        {
            var userId = HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
            var loggedUser = new Uzytkownik();
            loggedUser = _db.Uzytkownicy.FirstOrDefault(u => u.Nazwa_uzytkownika == userId);
            return View("EditUserPassword", loggedUser);
        }

        [Authorize]
        [HttpPost("edituserpassword")]
        public async Task<IActionResult> EditUserPassword(Uzytkownik obj, string password)
        {
            var loggedUsername = HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
            if (obj.Nazwa_uzytkownika == loggedUsername || !_db.Uzytkownicy.Any(x => x.Nazwa_uzytkownika == obj.Nazwa_uzytkownika)) //Jeśli nazwa pozostaje taka sama lub nie istnieje użytkownik o wybranej nazwie
            {
                ModelState.Remove("PotwierdzHaslo");
                ModelState.Remove("Haslo");
                var auctionFromDb = _db.Uzytkownicy.FirstOrDefault(x => x.Nazwa_uzytkownika == loggedUsername);
                auctionFromDb.Nazwa_uzytkownika = obj.Nazwa_uzytkownika;
                auctionFromDb.Hasło = CreateMD5(obj.Hasło);
                auctionFromDb.Potwierdz_Haslo = obj.Potwierdz_Haslo;

                await _db.SaveChangesAsync();
                return View("Account", auctionFromDb);
            }
            else
            {
                ViewBag.DuplicateMessage = "Nazwa użytkownika już zajęta!";
                return View("EditUserPassword", obj);
            }

        }

        // Get-Create
        [HttpGet("register")]
        public IActionResult Register(string returnUrl)
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Account", "Account");
            }
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        //POST-Create
        [HttpPost("register")]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(Uzytkownik obj)
        {
            if (_db.Uzytkownicy.Any(x => x.Nazwa_uzytkownika == obj.Nazwa_uzytkownika))
            {
                ViewBag.DuplicateMessage = "Nazwa użytkownika już zajęta!";
                return View("Register", obj);
            }
            else
            {
                var temp = obj.Hasło;
                obj.Hasło = CreateMD5(obj.Hasło);
                obj.Rola = "U";
                _db.Uzytkownicy.Add(obj);
                await _db.SaveChangesAsync();
                ViewBag.SuccessMessage = "Rejestracja przebiegła pomyślnie.";

                await Login(obj.Nazwa_uzytkownika, temp);
            }


            return RedirectToAction("Login");
            //return View("Register", new Uzytkownik());
        }

        public static string CreateMD5(string input)
        {
            // Use input string to calculate MD5 hash
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Convert the byte array to hexadecimal string
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }

        [HttpGet("login")]
        public IActionResult Login(string returnUrl)
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Account", "Account");
            }
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(string username, string password)
        {
            IEnumerable<Uzytkownik> objList = _db.Uzytkownicy;

            // ViewData["ReturnUrl"] = returnUrl;// do testu wymagane alternatywne przekierowanie z register
            foreach (var user in objList)
            {
                string md5StringPassword = CreateMD5(password);
                if (user.Nazwa_uzytkownika == username && user.Hasło == md5StringPassword)
                {
                    var claims = new List<Claim>();
                    claims.Add(new Claim(ClaimTypes.NameIdentifier, username));
                    claims.Add(new Claim(ClaimTypes.Role, user.Rola));
                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                    await HttpContext.SignInAsync(claimsPrincipal);

                    if (user.Rola == "A")
                    {
                        return RedirectToAction("Create", "Admin");
                    }
                    else
                    {
                        return RedirectToAction("Account");
                    }
                }
            }
            ViewBag.Error = true;
            TempData["Error"] = "Błąd. Niepoprawny Login lub Hasło.";   //Nieudana próba logowania zwraca widok logowania z adekwatnym błędem
            return View("login");
        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {

            await HttpContext.SignOutAsync();
            return RedirectToAction("Login");

        }
    }
}
