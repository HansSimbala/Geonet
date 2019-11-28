
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using SistemaGeonet.Data;


namespace SistemaGeonet.Models
{
    public class Catalogo
    {
        [Key]


        public int idCatalogo { get; set; }

        [DisplayName("Nombre")]
        public int idInventario { get; set; }

        [DisplayName("Cantidad")]
        public int cantidadVirtual { get; set; }

        [DisplayName("Titulo")]
        public string titulo { get; set; }

        [DisplayName("Descripcion")]
        public string descripcion { get; set; }

        [DisplayName("Imagen 1")]
        public string foto1 { get; set; }

        [DisplayName("Imagen 2")]
        public string foto2 {get;set;}

        [DisplayName("Imagen 3")]
        public string foto3 { get; set; }

        [DisplayName("Imagen 4")]
        public string foto4 { get; set; }

        public Inventario inventario { get; set; }

        public ICollection<Reseña>reseñas { get; set; }

    }
}
