
using GreenBusiness.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlueBusiness.Models.ViewModel
{
    public class BlogListViewModel
    {
        public List<Blogs> Posts { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}
