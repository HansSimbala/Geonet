using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using SistemaGeonet.Data;

namespace SistemaGeonet.Models
{
    public class Equipo
    {
        [Key]
        public int idEquipo { get; set; }
        //////////////////////////////////////////////////////////////////////
        public int idCategoria { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        //[RegularExpression("", ErrorMessage = "Campo solo admite letras")]
        //Nombre admite solo letras
        [DisplayName("Nombre")]
        public string nombre { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        [DisplayName("Marca")]
        //Marca admite solo letras
        public string marca { get; set; }

 

        [Required(ErrorMessage = "Campo requerido")]
           //[RegularExpression("", ErrorMessage = "Campo solo permite datos alfanuméricos")]
        //Campo alfanumerico
        [DisplayName("Código")]
        public string codigo { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        [DisplayName("Descripción")]
        public string descripcion { get; set; }


        [DisplayName("Foto")]
        public string imagen { get; set; }
        
        public Categoria categoria { get; set; }
        
        public ICollection<Inventario> inventarios { get; set; }

        public ICollection<EquipoxProveedor> equiposxproveedor { get; set; }

      

        public ICollection<EquipoxCombo> equiposxcombo { get; set; }

     



    }

    
}
