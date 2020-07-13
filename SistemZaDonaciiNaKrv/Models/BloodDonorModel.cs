using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemZaDonaciiNaKrv.Models
{
    public class BloodDonorModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public virtual List<DonationModel>  allDonations { get; set; }


        public BloodDonorModel()
        {
            this.allDonations = new List<DonationModel>();
        }
    }
}