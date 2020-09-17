using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SistemZaDonaciiNaKrv.Models
{
    public class BloodTypeModel
    {
        [Key]
        public int Id { get; set; }
        public long APositive { get; set; }
        public long ANegative { get; set; }
        public long BPositive { get; set; }
        public long BNegative { get; set; }
        public long ABPositive { get; set; }
        public long ABNegative { get; set; }
        public long OPositive { get; set; }
        public long ONegative { get; set; }

    }
}