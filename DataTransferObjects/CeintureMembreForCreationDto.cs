using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObjects
{
    public sealed class CeintureMembreForCreationDto
    {
        public int IdMembre { get; init; }
        public int IdCeinture { get; init; }
        public DateTime DateObtention { get; init; }
    }
}
