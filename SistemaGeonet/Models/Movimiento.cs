using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaGeonet.Models
{
    public class Movimiento
    {
        [Key]
        public int idMovimiento { get; set; }

        public int idEquipo { get; set; }

        public string tipo { get; set; }

        public int cantidad { get; set; }
       
        public DateTime fecha { get; set; }

        public Equipo equipo { get; set; }

    }
}
