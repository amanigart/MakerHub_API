using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObjects
{
    public sealed class CotisationDto
    {
        public int IdCotisation { get; init; }
        public DateTime DateDebut { get; init; }
        public DateTime DateFin { get; init; }
        public bool EstPaye { get; init; }
        public bool EstArchive { get; init; }
        public int IdMembre { get; init; }
        public Tarif Tarif { get; init; }
    }
}
