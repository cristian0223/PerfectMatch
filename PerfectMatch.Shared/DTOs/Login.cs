using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfectMatch.Shared.DTOs
{
    internal class Login
    {
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [EmailAddress(ErrorMessage = "Debes ingresar un correo")]
        public string Email { get; set; } = null!;

        [Display(Name = "Contraseña")]
        [Required(ErrorMessage = "el campo {0} es obligatorio")]
        [MinLength(8, ErrorMessage = "el campo {0} debe tener al menos {1} caracter")]
        public string Password { get; set; } = null!;

    }
}
