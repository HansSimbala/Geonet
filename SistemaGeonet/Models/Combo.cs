using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaGeonet.Models
{
    public class Combo
    {
        [Key]
        public int idCombo { get; set; }

        public string descripcion { get; set; }

        public decimal precioRegular { get; set; }

        public decimal precioDescuento { get; set; }

        public string estado { get; set; }

        public string imagenCombo { get; set; }

        public ICollection<EquipoxCombo> equipoxCombos { get; set; }
    }
}
