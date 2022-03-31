//using CarRental.Data.Base;
//using CarRental.Models;
//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace CarRental.Data.Services
//{
//    public class CarsService : EntityBaseRepository<Samochod>, ICarsService, DbContext
//    {
//        private readonly ApplicationDbContext _context;
//        public CarsService(ApplicationDbContext context) : base(context)
//        {
//            _context = context;
//        }

//        public async Task<Samochod> GetMovieByIdAsync(int id)
//        {
//            var movieDetails = await _context.Samochody
//                .FirstOrDefaultAsync(n => n.Id == id);

//            return movieDetails;
//        }

//    }
//}
