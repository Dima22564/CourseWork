using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ERP.Data.Abstractions;
using ERP.Domain.Core.Models;
using ERP.Services.DTO.Creation;
using ERP.Services.Exceptions;
using ERP.Services.Services.Abstractions;

namespace ERP.Services.Services
{
    public class PositionService : IPositionService
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Position> _positionRepo;

        public PositionService(IMapper mapper, IGenericRepository<Position> positionRepo)
        {
            _mapper = mapper;
            _positionRepo = positionRepo;
        }

        public async Task<Position> Create(PositionCreateDto dto)
        {
            var curr = _positionRepo.Get(x => x.Name == dto.Name).FirstOrDefault();
            if (!(curr is null))
            {
                throw new ModelNotFoundException("Должность уже зарегистрированна");
            }
            
            var position = _mapper.Map<PositionCreateDto, Position>(dto);
            await _positionRepo.AddAsync(position);
            await _positionRepo.SaveChangesAsync();

            return position;
        }

        public Task<Position> GetById(object id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<ICollection<Position>> GetAll()
        {
            return await _positionRepo.GetAllListAsync();
        }
    }
}