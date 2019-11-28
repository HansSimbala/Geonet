using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
namespace SistemaGeonet.Models
{
    public class EquipoxOC
    {
        [Key]
        public int idEquipoxOC { get; set; }

        [DisplayName("Equipo")]
        public int idEquipoxProveedor { get; set; }

        [DisplayName("Orden Compra")]
        public int idOrdenCompra { get; set; }

        [DisplayName("Cantidad")]
        public int cantidad { get; set; }

        [DisplayName("Precio Unitario ($)")]
        public decimal? precioUnit { get; set; }

        [DisplayName("Precio Total ($)")]
        public decimal? precioTotal { get; set; }

        public EquipoxProveedor equipoxproveedor { get; set; }

        public OrdenCompra ordenCompra { get; set; }


    }
}
