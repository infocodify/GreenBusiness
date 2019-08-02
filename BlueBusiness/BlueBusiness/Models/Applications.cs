using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BlueBusiness.Models
{
    public class Applications
    {

        public int Id { get; set; }

        public string JobTitle { get; set; }
        public string JobLocation { get; set; }

        public string Name { get; set; }

        public string Lastname { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateApplied { get; set; }

        public Applications()
        {
            DateApplied = DateTime.Now;
        }
        public string Country { get; set; }

        public string PostCode { get; set; }

        public string LinkedinUrl { get; set; }
        public string Resume { get; set; }

        [Display(Name = "Employment Eligibility")]
        public string EmploymentEligibility { get; set; }

        public string Gender { get; set; }

        public string Ethnicity { get; set; }

        public string Race { get; set; }

        public string Disability { get; set; }


        [Display(Name = "Jobs App")]
        public int JobsID { get; set; }

        [ForeignKey("JobsID")]
        public virtual Jobs Jobs { get; set; }
    }
}
