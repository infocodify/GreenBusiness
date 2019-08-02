using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlueBusiness.Data;
using BlueBusiness.Models;
using BlueBusiness.Models.ViewModel;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlueBusiness.Controllers
{
    public class CareersController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly HostingEnvironment _hostingEnvironment;

        [BindProperty]
        public JobsApplicationsViewModel JobsVM { get; set; }
        public CareersController(ApplicationDbContext db, HostingEnvironment hostingEnvironment)
        {
            _db = db;
            _hostingEnvironment = hostingEnvironment;

            ////initialize ProductsViewModel
            //JobsVM = new JobsApplicationsViewModel()
            //{
            //    Jobs = _db.Jobs.ToList(),
            //    Applications = new Applications()
            //};
        }

        // GET: Admin/Jobs
        public async Task<IActionResult> Index()
        {
            return View(await _db.Jobs.ToListAsync());
        }

        // GET: Admin/Jobs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobs = await _db.Jobs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jobs == null)
            {
                return NotFound();
            }

            return View(jobs);
        }

        //public IActionResult JobApply()
        //{
        //    return View(JobsVM);
        //}

        public IActionResult JobApplication(string JobTitle, string JobLocation)
        {
            ViewBag.JobTitle = JobTitle;
            ViewBag.JobLocation = JobLocation;
            return View();
        }

        ////Post message contact form
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> JobApplication(JobApplication jobApplication)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _db.Add(jobApplication);
        //        await _db.SaveChangesAsync();

        //        TempData["message"] = "Message send Successfully.";
        //        return RedirectToAction(nameof(JobApplication));
        //    }

        //    return View(jobApplication);
        //}

        //[HttpPost, ActionName("JobApplication")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> JobApplyPOST()
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View(JobsVM);
        //    }

        //    _db.Applications.Add(JobsVM.Applications);
        //    await _db.SaveChangesAsync();


        //    TempData["message"] = "Data has been Added to Database.";
        //    return RedirectToAction(nameof(Index));

        //}
    }
}