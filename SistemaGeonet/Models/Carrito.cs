using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SistemaGeonet.Models
{
    public class Carrito
    {
        [Key]
        public int idCarrito { get; set; }

        public string idUsuario { get; set; }

        public decimal? subtotal { get; set; }

        public string estado { get; set; }
    }
}
