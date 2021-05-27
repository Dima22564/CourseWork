using ERP.Domain.Core.Models;
using ERP.Services.DTO.Creation;

namespace ERP.Services.Services.Abstractions
{
    public interface IPositionService : ICreation<Position, PositionCreateDto>, IFetch<Position>
    {
        
    }
}