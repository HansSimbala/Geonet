using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SistemaGeonet.Models
{
    public class Tarjeta
    {
        [Key]
        public int idTarjeta { get; set; }

        public string numeroTarjeta { get; set; }

        public int cvv { get; set; }

        public string fechaVencimiento { get; set; }
    }
}
