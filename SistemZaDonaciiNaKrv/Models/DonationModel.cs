using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemZaDonaciiNaKrv.Models
{
    public class DonationModel
    {
        public int Id { get; set; }
        public DateTime DonationTime { get; set; }
        public string City { get; set; }
        public bool isDone { get; set; }
    }
}