using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SistemaGeonet.Models
{
    public class DetallePedido
    {
        [Key]
        public int idDetallePedido { get; set; }

        public int idOrdenPedido { get; set; }

        public int idInventario { get; set; }

        public int cantidad { get; set; }

        public  Inventario inventario { get; set; }

      


    }
}
