using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;

namespace SistemaGeonet.Models
{
    public class OrdenCompra
    {
        public OrdenCompra(){
            fecha = DateTime.Today;
        }

        [Key]
         public int idOrdenCompra { get; set; }

        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [DisplayName("Fecha")]
        public DateTime? fecha { get; set; }





        [DisplayName("Proveedor")]
        public int idProveedor { get; set; }

        [DisplayName("Subtotal ($)")]
        public decimal? subtotal { get; set; }


        [DisplayName("IGV ($)")]
        public decimal? igv { get; set; }

        [DisplayName("Total ($)")]
        public decimal? total { get; set; }

        [DisplayName("Estado")]
        public string estado { get; set; }
        [DisplayName("Còdigo")]
        public string codigo { get; set; }


        public Proveedor proveedor { get; set; }


        public ICollection<EquipoxOC> equipoxOCs { get; set; }

       
    }
}
