using CarRental.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRental.Data
{
    public class ApplicationDbContext :DbContext
    {
        public IWebHostEnvironment WebHostEnv { get; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IWebHostEnvironment webHostEnv) : base(options)
        {
            WebHostEnv = webHostEnv;
        }
        public DbSet<Uzytkownik> Uzytkownicy{ get; set; }
        public DbSet<Samochod> Samochody { get; set; }
        public DbSet<Pytanie> Pytania { get; set; }
        public DbSet<RezerwacjaSamochodu> RezerwacjeSamochodów { get; set; }


    }
}
