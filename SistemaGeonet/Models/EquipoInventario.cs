using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace SistemaGeonet.Models
{
    public class EquipoInventario
    {
        
        public IEnumerable<Equipo> equipos { get; set; }
        public IEnumerable<Inventario> inventario { get; set; }


        //Equipo
        [DisplayName("Categoría")]
        public int idCategoria { get; set; }

        [DisplayName("Nombre")]
        public string nombre{ get; set; }

        [DisplayName("Marca")]
        public string  marca { get; set; }

        [DisplayName("Código")]
        public string codigo { get; set; }

        [DisplayName("Descripción")]
        public string descripcion { get; set; }


        [DisplayName("Imagen")]
        public string imagen { get; set; }

        //Inventario

        public int IdEquipo { get; set; }

        [DisplayName("SKU")]
        public string SKU { get; set ; }

        //[DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
       
        //public DateTime fechaEntrada { get { return DateTime.Now; } set { ; } }

        private DateTime? dateCreated;
        public DateTime? fechaEntrada
        {
            get { return dateCreated ?? DateTime.Today; }
            set { dateCreated = value; }
        }

        [DisplayName("Cantidad")]
        public int cantidadReal { get; set; }

        [DisplayName("Inventario Máximo")]
        public int cantidadMaxima { get; set; }

        [DisplayName("Inventario Mínimo")]
        public int cantidadMinima { get; set;  }

        [DisplayName("Precio unitario $")]
        public decimal precioUnit { get; set; }

        public Categoria categoria { get; set; }
    }
}
