using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaGeonet.Models
{
    public class EquipoxCombo
    {
        [Key]
        public int idEquipoxCombo { get; set; }

        public int idEquipo { get; set; }

        public int idCombo { get; set; }

        public Equipo equipo { get; set; }

        public Combo combo { get; set; }

    }
}
