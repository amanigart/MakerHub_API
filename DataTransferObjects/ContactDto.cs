using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObjects
{
    public sealed class ContactDto
    {
        public int Id { get; init; }
        public Personne Personne { get; init; }
        public Adresse Adresse { get; init; }
        public string LienAvecMembre { get; init; }
    }
}
