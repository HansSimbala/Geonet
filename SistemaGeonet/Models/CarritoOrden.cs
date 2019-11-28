using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace SistemaGeonet.Models
{
    public class CarritoOrden
    {
        [Key]
        public int idCarritoOrden;

        public string idUsuario { get; set; }

        public decimal? preciototal { get; set; }

        public string estado { get; set; }
    }
}
