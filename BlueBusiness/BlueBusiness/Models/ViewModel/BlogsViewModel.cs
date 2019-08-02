using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlueBusiness.Models.ViewModel
{
    public class BlogsViewModel
    {
        public Blogs Blogs { get; set; }
        public IEnumerable<Tags> Tags { get; set; }
    }
}
