using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
namespace SistemaGeonet.Models

{
    public class OrdenPedido
    {

        [Key]
        public int IdOrdenPedido { get; set; }


        [DisplayName("Código")]
        public string codigo { get; set; }

        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [DisplayName("Fecha")]
        
        public DateTime fechapedido { get; set; }

        [DisplayName("Comentario")]
        public string comentario { get; set; }

        [DisplayName("Estado")]
        public string estado { get; set; }

        [DisplayName("Usuario")]
        public string usuario { get; set;  }

     
   
    }
}
