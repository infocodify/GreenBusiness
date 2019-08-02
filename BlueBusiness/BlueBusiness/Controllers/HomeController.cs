using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BlueBusiness.Models;
using BlueBusiness.Data;

namespace BlueBusiness.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _db;


        public HomeController(ApplicationDbContext db)
        {
            _db = db;

 
        }
        public IActionResult Index()
        {
            return View();
        }

        //public IActionResult JobApplication(string JobTitle, string JobLocation)
        //{
        //    ViewBag.JobTitle = JobTitle;
        //    ViewBag.JobLocation = JobLocation;
        //    return View();
        //}

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
