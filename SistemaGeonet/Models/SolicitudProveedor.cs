using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaGeonet.Models
{
    public class SolicitudProveedor
    {
        [Key]
        public int idSolicitudProveedor { get; set; }

        public int idSolicitud { get; set; }

        public int idProveedor { get; set; }


        public Solicitud solicitud { get; set; }
    }
}
