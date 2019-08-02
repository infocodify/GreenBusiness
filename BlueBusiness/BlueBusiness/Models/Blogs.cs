using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BlueBusiness.Models
{
    public class Blogs
    {
        public int Id { get; set; }

        //[Required(ErrorMessage ="Please Enter Product Name")]
        public string Title { get; set; }

        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateCreated { get; set; }

        public Blogs()
        {
            DateCreated = DateTime.Now;
        }

        public string Image { get; set; }

        public string ViewTitle { get; set; }

        [Display(Name = "Post Tag")]
        public int TagsID { get; set; }

        [ForeignKey("TagsID")]
        public virtual Tags Tags { get; set; }
    }
}
