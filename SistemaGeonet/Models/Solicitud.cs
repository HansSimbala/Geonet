using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaGeonet.Models
{
    public class Solicitud
    {
        [Key]
        public int idSolicitud { get; set; }

        public int codigo { get; set; }

        public DateTime fecha { get; set; }

        public Equipo equipo { get; set; }
    }
}
