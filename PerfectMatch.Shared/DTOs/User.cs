using PerfectMatch.Shared.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfectMatch.Shared.DTOs
{
    public class User : Usuario
    {
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        [Required(ErrorMessage = "el campo {0} es obligatoio")]
        [StringLength(20, MinimumLength = 8, ErrorMessage = "el campo debe tener entre {2} y {1} caracter")]
        public string Password { get; set; } = null!;

        [Compare("Password", ErrorMessage = "La contrasela es diferente ala confirmacion")]
        [Display(Name = "Confirmacion de contraseñas")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "el campo {0} es obligatorio")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "el campo {0} debe tener entre{2} y {1} caracteres")]
        public string PasswordConfirm { get; set; } = null!;
    }
}
