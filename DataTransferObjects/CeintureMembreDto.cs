using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObjects
{
    public sealed class CeintureMembreDto
    {
        public int IdDiscipline { get; init; }
        public int IdCeinture { get; init; }
        public DateTime DateObtention { get; init; }
    }
}
