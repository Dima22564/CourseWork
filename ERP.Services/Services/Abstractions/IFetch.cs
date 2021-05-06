using System.Collections.Generic;
using System.Threading.Tasks;
using ERP.Domain.Core.Models;

namespace ERP.Services.Services.Abstractions
{
    public interface IFetch<T> where T : BaseEntity
    {
        public abstract Task<T> GetById(object id);
        public abstract Task<ICollection<T>> GetAll();
    }
}