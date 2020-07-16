using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SistemZaDonaciiNaKrv.Models
{
    public class BloodDonorModel
    {
        public int Id { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "Email")]
        public string email { get; set; }
        public string City { get; set; }
        public virtual List<DonationModel> allDonations { get; set; }


        public BloodDonorModel()
        {
            this.allDonations = new List<DonationModel>();
        }
    }
}