using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlueBusiness.Data;
using BlueBusiness.Models;
using BlueBusiness.Models.ViewModel;
using GreenBusiness.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlueBusiness.Controllers
{
    [Route("/Blog")]
    public class BlogController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly int PageSize = 3;

        public BlogController(ApplicationDbContext db)
        {
            _db = db;

        }
        public IActionResult Index(int blogPage = 1)
        {
            BlogListViewModel blogsVM = new BlogListViewModel()
            {
                Posts = new List<Blogs>()
            };
            StringBuilder param = new StringBuilder();

            param.Append("/Blog/?blogPage=:");
            //param.Append("&searchName=");

            blogsVM.Posts = _db.Blogs.Include(a => a.Tags).ToList();

            var count = blogsVM.Posts.Count;

            blogsVM.Posts = blogsVM.Posts.OrderByDescending(p => p.DateCreated)
                .Skip((blogPage - 1) * PageSize)
                .Take(PageSize).ToList();


            blogsVM.PagingInfo = new PagingInfo
            {
                CurrentPage = blogPage,
                ItemsPerPage = PageSize,
                TotalItems = count,
                urlParam = param.ToString()
            };

            return View(blogsVM);
        }
    }
}