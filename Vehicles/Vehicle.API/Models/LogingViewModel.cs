using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Vehicle.API.Models
{
    public class LogingViewModel
    {
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Debe introducir email valido")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Username { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        [MinLength(6, ErrorMessage = "El campo {0} debe tener una longitud minima de {1} carácteres.")]        
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Password { get; set; }


        [Display(Name = "Recordarme")]
        public bool Remenberme { get; set; }

    }
}
