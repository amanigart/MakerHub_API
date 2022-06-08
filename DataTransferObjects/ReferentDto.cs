using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObjects
{
    public sealed class ReferentDto
    {
        public int? Id { get; set; }
        public Personne? Personne { get; set; }
        public Adresse? Adresse { get; set; }
        public string? LienAvecMembre { get; set; }
    }
}
