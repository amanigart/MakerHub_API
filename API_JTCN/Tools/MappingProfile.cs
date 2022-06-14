using AutoMapper;
using DataTransferObjects;
using Entities.Models;

namespace API_JTCN.Tools
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AdresseForCreationDto, Adresse>(); 
            CreateMap<PersonneForCreationDto, Personne>();
            CreateMap<MembreInfosForCreationDto, Membre>();
            CreateMap<CeintureMembreDto, CeintureMembre>();
            CreateMap<CotisationForCreationDto, Cotisation>();
            CreateMap<V_Cotisations, CotisationDto>();
        }
    }
}
