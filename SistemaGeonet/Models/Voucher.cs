using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SistemaGeonet.Models
{
    public class Voucher
    {
        [Key]
        public int idVoucher { get; set; }

        public string foto { get; set; }
    }
}
