using System.Threading.Tasks;
using ERP.Domain.Core.Models;
using ERP.Services.DTO;
using ERP.Services.DTO.Creation;

namespace ERP.Services.Services.Abstractions
{
    public interface ICountryService : ICreation<Country, CreateCountryDto>, IFetch<Country>
    {
        public Task<Country> UpdateByCode(CreateCountryDto countryDto);
    }
}