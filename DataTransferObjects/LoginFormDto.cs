using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObjects
{
    public class LoginFormDto
    {
        [Required(ErrorMessage = "Le champ login est manquant.")]
        public string Login { get; init; }

        [Required(ErrorMessage = "Le champ password est manquant.")]
        public string Password { get; init; }
    }
}
