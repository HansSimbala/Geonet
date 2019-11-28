using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SistemaGeonet.Models
{
    public class MetodoPago
    {
        [Key]
        public int idMetodoPago { get; set; }

        public string metodoPago { get; set; }

        public string descripcion { get; set; }

        public ICollection<OrdenPedido> ordenPedidos { get; set; }
    }
}
