using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlueBusiness.Models
{
    public class Jobs
    {
        public int Id { get; set; }

        public string JobId { get; set; }

        public string Location { get; set; }

        public string Department { get; set; }

        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime JobDate { get; set; }

        public Jobs()
        {
            JobDate = DateTime.Now;
        }
        public string Title { get; set; }

        [Display(Name = "Brief Description")]
        public string BriefDescription { get; set; }

        [Display(Name = "Company Description")]
        public string CompanyDescription { get; set; }


        public string ResponsibilityOne { get; set; }
        public string ResponsibilityTwo { get; set; }
        public string ResponsibilityThree { get; set; }
        public string ResponsibilityFour { get; set; }

        public string RequirementOne { get; set; }
        public string RequirementTwo { get; set; }
        public string RequirementThree { get; set; }
        public string RequirementFour { get; set; }

        public string Benefits { get; set; }
    }
}
