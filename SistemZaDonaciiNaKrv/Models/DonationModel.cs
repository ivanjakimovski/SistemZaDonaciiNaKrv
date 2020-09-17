using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SistemZaDonaciiNaKrv.Models
{
    public class DonationModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime DonationTime { get; set; }
        public string City { get; set; }
        public bool isDone { get; set; }
        public string bloodType { get; set; }
        public string  Email { get; set; }
    }
}