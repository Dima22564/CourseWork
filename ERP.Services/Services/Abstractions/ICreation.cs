using System.Threading.Tasks;
using ERP.Domain.Core.Models;
using ERP.Services.DTO.Abstract;
using ERP.Services.DTO.Return;

namespace ERP.Services.Services.Abstractions
{
    public interface ICreation<T, TDto> where TDto : CreationDto
    {
        public Task<T> Create(TDto dto);
    }
}