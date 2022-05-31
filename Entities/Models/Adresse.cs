using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public sealed class Adresse
    {
        public int IdAdresse { get; set; }
        public string Rue { get; set; }
        public string Numero { get; set; }
        public int CodePostal { get; set; }
        public string Ville { get; set; }
    }
}
