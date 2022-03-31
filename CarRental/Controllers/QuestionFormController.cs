using CarRental.Data;
using CarRental.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRental.Controllers
{
    public class QuestionFormController : Controller
    {
        private readonly ApplicationDbContext _db;

        public QuestionFormController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("createQuestionForm")]
        public IActionResult CreateQuestionForm()
        {
            ViewBag.Success = TempData["Success"] as bool?;
            return View();
        }

        [HttpPost("createQuestionForm")]
        [ValidateAntiForgeryToken]
        public IActionResult CreateQuestionForm(Pytanie obj)
        {
            if (ModelState.IsValid)
            {
                _db.Pytania.Add(obj);
                _db.SaveChanges();
                TempData["Success"] = true;
                System.Threading.Thread.Sleep(1000);
                return RedirectToAction("CreateQuestionForm");
            }
            else
            {
                return View("CreateQuestionForm", obj);
            }
        }
    }
}