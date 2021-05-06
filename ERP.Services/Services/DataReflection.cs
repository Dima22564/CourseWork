using System.Collections.Generic;
using System.Threading.Tasks;
using ERP.Data.Abstractions;
using ERP.Domain.Core.Abstract;
using ERP.Domain.Core.Models;
using ERP.Services.Services.Abstractions;

namespace ERP.Services.Services
{
    public class DataReflection<T> : IDataReflectionService<T> where T : BaseEntity
    {
        private readonly IGenericRepository<T> _genericRepository;

        public DataReflection(IGenericRepository<T> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public async Task<T> GetOneAsync(object id)
        {
            return await _genericRepository.GetAsync(id);
        }

        public async Task<ICollection<T>> GetAllAsync()
        {
            return await _genericRepository.GetAllListAsync();
        }

        public Task<ICollection<T>> GetAllByFilters()
        {
            throw new System.NotImplementedException();
        }
    }
}