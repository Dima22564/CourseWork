using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ERP.Data.Abstractions;
using ERP.Domain.Core.Models;
using ERP.Services.DTO;
using ERP.Services.DTO.Creation;
using ERP.Services.DTO.Return;
using ERP.Services.Services.Abstractions;

namespace ERP.Services.Services
{
    public class CountryService : ICountryService
    {
        private readonly IGenericRepository<Country> _countryRepo;
        private readonly IMapper _mapper;

        public CountryService(IGenericRepository<Country> countryRepo, IMapper mapper)
        {
            _countryRepo = countryRepo;
            _mapper = mapper;
        }

        public async Task<Country> UpdateByCode(CreateCountryDto countryDto)
        {
            var c = await _countryRepo.GetAsync(countryDto.Code);
            if (c is null)
            {
                throw new ApplicationException("Страна не найдена");
            };
            var country = await _countryRepo.GetAsync(countryDto.Code);
            
            country.Code2 = countryDto.Code2;
            country.Code3 = countryDto.Code3;
            country.Name = countryDto.Name;
            country.FullName = countryDto.FullName;

            await _countryRepo.SaveChangesAsync();

            return country;
        }

        public async Task<Country> Create(CreateCountryDto dto)
        {
            var country = await _countryRepo.GetAsync(dto.Code);
            if (!(country is null))
            {
                throw new ApplicationException("Страна уже зарегистрированна");
            }
            
            var newCountry = _mapper.Map<CreateCountryDto, Country>(dto);
            
            await _countryRepo.AddAsync(newCountry);
            await _countryRepo.SaveChangesAsync();

            return newCountry;
        }

        public async Task<Country> GetById(object id)
        {
            return await _countryRepo.GetAsync(id);
        }

        public async Task<ICollection<Country>> GetAll()
        {
            return await _countryRepo.GetAllListAsync();
        }
    }
}