using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace SistemaGeonet.Models
{
    public class Item
    {
        [Key]
         public int IdItem { get; set; }

        public int IdOrdenCompra { get; set; }

        public int? IdOrdenPedido { get; set; }

        public int IdInventario { get; set; }

        public string Nroserie { get; set; }

        public string detalle { get; set; }


 

        public string estado { get; set; }


        public DateTime? fechaEntrada { get; set; }

        public DateTime? fechaSalida { get; set; }

        public OrdenCompra ordenCompra { get; set; }

        public OrdenPedido ordenPedido { get; set; }
        public Inventario Inventario { get; set; }

    }
}
