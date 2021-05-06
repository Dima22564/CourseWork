using System.Collections.Generic;
using System.Threading.Tasks;
using ERP.Domain.Core.Abstract;
using ERP.Domain.Core.Models;

namespace ERP.Services.Services.Abstractions
{
    public interface IDataReflectionService<T> where T : BaseEntity
    {
        public Task<T> GetOneAsync(object id);
        public Task<ICollection<T>> GetAllAsync();
        public Task<ICollection<T>> GetAllByFilters();
    }
}