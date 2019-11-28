using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaGeonet.Models
{
    public class DetalleSolicitud
    {
        [Key]
        public int idDetalleSolicitud { get; set; }

        public int idSolicitud { get; set; }

        public int idEquipo { get; set; }

        public int cantidad { get; set; }

        public Equipo equipo { get; set; }
    }
}
