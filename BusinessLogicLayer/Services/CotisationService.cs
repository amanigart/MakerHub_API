﻿using AutoMapper;
using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Interfaces;
using DataTransferObjects;
using Entities.Models;
using LoggerService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public sealed class CotisationService : ICotisationService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public CotisationService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public IEnumerable<CotisationDto> GetAllCotisations()
        {
            IEnumerable<V_Cotisations> cotisations = _repository.V_Cotisations.GetAll();
            IEnumerable<CotisationDto> cotisationsDto = _mapper.Map<IEnumerable<CotisationDto>>(cotisations);

            return cotisationsDto;
        }
    }
}
