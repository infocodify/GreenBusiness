using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BlueBusiness.Data;
using BlueBusiness.Models;
using BlueBusiness.Models.ViewModel;
using Microsoft.AspNetCore.Hosting.Internal;
using System.IO;
using BlueBusiness.Utility;

namespace BlueBusiness.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogsController : Controller
    {
        private readonly ApplicationDbContext _db;

        private readonly HostingEnvironment _hostingEnvironment;

        [BindProperty]
        public BlogsViewModel BlogsVM { get; set; }

        public BlogsController(ApplicationDbContext db, HostingEnvironment hostingEnvironment)
        {
            _db = db;

            _hostingEnvironment = hostingEnvironment;

            //initialize ProductsViewModel
            BlogsVM = new BlogsViewModel()
            {
                Tags = _db.Tags.ToList(),
                Blogs = new Blogs()
            };
        }

        // GET: Admin/Blogs
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _db.Blogs.Include(b => b.Tags);
            return View(await applicationDbContext.ToListAsync());
        }

        //Get : Products Create
        public IActionResult Create()
        {
            return View(BlogsVM);
        }

        //Post : Products Create
        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreatePOST()
        {
            if (!ModelState.IsValid)
            {
                return View(BlogsVM);
            }

            _db.Blogs.Add(BlogsVM.Blogs);
            await _db.SaveChangesAsync();

            //Image Being Saved
            string webRootPath = _hostingEnvironment.WebRootPath;

            var files = HttpContext.Request.Form.Files;

            var productsFromDb = _db.Blogs.Find(BlogsVM.Blogs.Id);

            if (files.Count != 0)
            {
                //Image has been Uploaded

                var uploads = Path.Combine(webRootPath, SD.ImageFolder);
                var extension = Path.GetExtension(files[0].FileName);

                using (var filestream = new FileStream(Path.Combine(uploads, BlogsVM.Blogs.Id + extension), FileMode.Create))
                {
                    files[0].CopyTo(filestream);
                }

                productsFromDb.Image = @"\" + SD.ImageFolder + @"\" + BlogsVM.Blogs.Id + extension;
            }
            //if no file uploaded
            else
            {
                var uploads = Path.Combine(webRootPath, SD.ImageFolder + @"\" + SD.DefaultProducImage);
                System.IO.File.Copy(uploads, webRootPath + @"\" + SD.ImageFolder + @"\" + BlogsVM.Blogs.Id + ".jpg");
                productsFromDb.Image = @"\" + SD.ImageFolder + @"\" + BlogsVM.Blogs.Id + ".jpg";
            }

            await _db.SaveChangesAsync();
            TempData["message"] = "Data has been Added to Database.";
            return RedirectToAction(nameof(Index));
        }


        //GET : Edit
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            BlogsVM.Blogs = await _db.Blogs.Include(m => m.Tags).SingleOrDefaultAsync(m => m.Id == id);

            if (BlogsVM.Blogs == null)
            {
                return NotFound();
            }

            return View(BlogsVM);
        }


        //Post : Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id)
        {
            if (ModelState.IsValid)
            {
                string webRootPath = _hostingEnvironment.WebRootPath;
                var files = HttpContext.Request.Form.Files;

                var productFromDb = _db.Blogs.Where(m => m.Id == BlogsVM.Blogs.Id).FirstOrDefault();

                if (files.Count > 0 && files[0] != null)
                {
                    //if user uploads a new image
                    var uploads = Path.Combine(webRootPath, SD.ImageFolder);
                    var extension_new = Path.GetExtension(files[0].FileName);
                    var extension_old = Path.GetExtension(productFromDb.Image);

                    if (System.IO.File.Exists(Path.Combine(uploads, BlogsVM.Blogs.Id + extension_old)))
                    {
                        System.IO.File.Delete(Path.Combine(uploads, BlogsVM.Blogs.Id + extension_old));
                    }
                    using (var filestream = new FileStream(Path.Combine(uploads, BlogsVM.Blogs.Id + extension_new), FileMode.Create))
                    {
                        files[0].CopyTo(filestream);
                    }
                    BlogsVM.Blogs.Image = @"\" + SD.ImageFolder + @"\" + BlogsVM.Blogs.Id + extension_new;
                }

                if (BlogsVM.Blogs.Image != null)
                {
                    productFromDb.Image = BlogsVM.Blogs.Image;
                }

                productFromDb.Title = BlogsVM.Blogs.Title;
                productFromDb.Image = BlogsVM.Blogs.Image;
                productFromDb.ViewTitle = BlogsVM.Blogs.ViewTitle;
                productFromDb.TagsID = BlogsVM.Blogs.TagsID;
                await _db.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(BlogsVM);
        }

        //GET : Details
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            BlogsVM.Blogs = await _db.Blogs.Include(m => m.Tags).SingleOrDefaultAsync(m => m.Id == id);

            if (BlogsVM.Blogs == null)
            {
                return NotFound();
            }

            return View(BlogsVM);
        }

        //GET : Delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            BlogsVM.Blogs = await _db.Blogs.Include(m => m.Tags).SingleOrDefaultAsync(m => m.Id == id);

            if (BlogsVM.Blogs == null)
            {
                return NotFound();
            }

            return View(BlogsVM);
        }

        //POST : Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            string webRootPath = _hostingEnvironment.WebRootPath;
            Blogs blogs = await _db.Blogs.FindAsync(id);

            if (blogs == null)
            {
                return NotFound();
            }
            else
            {
                var uploads = Path.Combine(webRootPath, SD.ImageFolder);
                var extension = Path.GetExtension(blogs.Image);

                if (System.IO.File.Exists(Path.Combine(uploads, blogs.Id + extension)))
                {
                    System.IO.File.Delete(Path.Combine(uploads, blogs.Id + extension));
                }
                _db.Blogs.Remove(blogs);
                await _db.SaveChangesAsync();
                TempData["message"] = "Data has been Deleted Successfully !!!";
                return RedirectToAction(nameof(Index));
            }
        }

        //// GET: Admin/Blogs/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var blogs = await _context.Blogs
        //        .Include(b => b.Tags)
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (blogs == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(blogs);
        //}

        //// GET: Admin/Blogs/Create
        //public IActionResult Create()
        //{
        //    ViewData["TagsID"] = new SelectList(_context.Set<Tags>(), "Id", "Name");
        //    return View();
        //}

        //// POST: Admin/Blogs/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,Title,DateCreated,Image,ViewTitle,TagsID")] Blogs blogs)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(blogs);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["TagsID"] = new SelectList(_context.Set<Tags>(), "Id", "Name", blogs.TagsID);
        //    return View(blogs);
        //}

        //// GET: Admin/Blogs/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var blogs = await _db.Blogs.FindAsync(id);
        //    if (blogs == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewData["TagsID"] = new SelectList(_db.Set<Tags>(), "Id", "Name", blogs.TagsID);
        //    return View(blogs);
        //}


        //// POST: Admin/Blogs/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,Title,DateCreated,Image,ViewTitle,TagsID")] Blogs blogs)
        //{
        //    if (id != blogs.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(blogs);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!BlogsExists(blogs.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["TagsID"] = new SelectList(_context.Set<Tags>(), "Id", "Name", blogs.TagsID);
        //    return View(blogs);
        //}

        //// GET: Admin/Blogs/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var blogs = await _context.Blogs
        //        .Include(b => b.Tags)
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (blogs == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(blogs);
        //}

        //// POST: Admin/Blogs/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var blogs = await _context.Blogs.FindAsync(id);
        //    _context.Blogs.Remove(blogs);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool BlogsExists(int id)
        //{
        //    return _context.Blogs.Any(e => e.Id == id);
        //}
    }
}
