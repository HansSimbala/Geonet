using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaGeonet.Models.AccountViewModels
{
    public class RegisterViewModel
    {



        [Required(ErrorMessage = "Campo Requerido")]
        [EmailAddress(ErrorMessage = "Ingrese un correo electrónico valido")]
        [StringLength(30, ErrorMessage = "Minimo 10 carácteres - Máximo 30 carácteres.", MinimumLength = 10)]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Campo Requerido")]
        [StringLength(20, ErrorMessage = "Minimo 6 carácteres - Máximo 20 carácteres.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Campo Requerido")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "Las contraseñas no coinciden.")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Campo Requerido")]
        [StringLength(20, ErrorMessage = "Minimo 3 carácteres - Máximo 20 carácteres.", MinimumLength = 3)]
        public string Nombres { get; set; }

        [Required(ErrorMessage = "Campo Requerido")]
        [StringLength(20, ErrorMessage = "Minimo 3 carácteres - Máximo 20 carácteres.", MinimumLength = 3)]

        public string ApellidoMaterno { get; set; }

        [Required(ErrorMessage = "Campo Requerido")]
        [StringLength(20, ErrorMessage = "Minimo 3 carácteres - Máximo 20 carácteres.", MinimumLength = 3)]
        public string ApellidoPaterno { get; set; }

        //[Required(ErrorMessage = "Campo Requerido")]
        public int IdTipoDocumento { get; set; }



        [Required(ErrorMessage = "Campo Requerido")]
        [Range(10000000, 999999999, ErrorMessage = "Ingrese un Documento válido")]
        public long Documento { get; set; }




        [Required(ErrorMessage = "Campo Requerido")]
        [Range(900000000, 999999999, ErrorMessage = "Ingrese un Teléfono válido")]
        public int Telefono { get; set; }

        [Required(ErrorMessage = "Campo Requerido")]
        [StringLength(100, ErrorMessage = "Minimo 3 carácteres - Máximo 100 carácteres.", MinimumLength = 3)]
        public string Direccion { get; set; }


    }
}
