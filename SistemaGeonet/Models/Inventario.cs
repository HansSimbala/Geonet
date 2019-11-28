using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
namespace SistemaGeonet.Models
{
    public class Inventario

    {
        [Key]
        public int idInventario { get; set; }

        [DisplayName("Equipo")]
        public int idEquipo { get; set; }

        [DisplayName("SKU")]
        public string SKU { get; set; }
        

        [DisplayName("Nombre")]
        public string nombre { get; set; }

        
        [DisplayName("Marca")]
        public string marca { get; set; }

        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [DisplayName("Fecha")]
        public DateTime?fechaEntrada{get; set;}


        [DisplayName("Cantidad Mìnima")]
        public int cantidadMinima { get; set; }


        [DisplayName("Cantidad Real")]
        public int cantidadReal { get; set; }

        [DisplayName("Cantidad Maxima")]
        public int cantidadMaxima { get; set; }

        [DisplayName("Precio unitario")]
        public decimal precioUnit { get; set; }

        [DisplayName("Equipo")]
        public Equipo Equipo { get; set; }

        public ICollection<DetallePedido> detallePedidos { get; set; }
        public ICollection<Item> item  { get; set; }
        public ICollection<Catalogo> catalogo { get; set; }

      
    }
}
