using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace SistemaGeonet.Models
{
    public class Reseña
    {
        [Key]
        public int idReseña { get; set; }
        [DisplayName("Catalogo")]
        public int idCatalogo { get; set; }
        [DisplayName("Comentario")]
        public string comentario { get; set; }
        [DisplayName("Calificacion")]
        public int calificacion { get; set; }

        [DisplayName("Usuario")]
        public string usuario { get; set; }

        public Catalogo catalogo { get; set; }


    }
}
