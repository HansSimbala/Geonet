using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;

namespace SistemaGeonet.Models
{
    public class Usuarios
    {

        [Key]
        public string Id { get; set; }

        [DisplayName("Rol")]

        public string rol { get; set; }


        [DisplayName("Nombres")]


        public string nombres { get; set; }

        [DisplayName("Apellido Parterno")]

        public string apellidomaterno { get; set; }

        [DisplayName("Apellido Materno")]
        public string apellidopaterno { get; set; }
        [DisplayName("Email")]
        public string email { get; set; }
        [DisplayName("Tipo de documento")]
        public int tipodoc { get; set; }

        [DisplayName("Documento")]
        public long documento { get; set; }


        [DisplayName("Teléfono")]
        public int telefono { get; set; }


        [DisplayName("Direccion")]
        public string direccion { get; set; }


    






    }
}
