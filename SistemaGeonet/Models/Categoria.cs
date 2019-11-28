using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SistemaGeonet.Models
{
    public class Categoria
    {
        [Key]
        public int IdCategoria { get; set; }

        public string nombre { get; set; }

        public  string descripcion { get; set; }

        public ICollection<Equipo> equipos { get; set; }

    }
}
