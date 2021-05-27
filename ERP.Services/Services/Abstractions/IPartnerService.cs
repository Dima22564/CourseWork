using System.Collections.Generic;
using System.Threading.Tasks;
using ERP.Domain.Core.Models;
using ERP.Services.DTO.Creation;

namespace ERP.Services.Services.Abstractions
{
    public interface IPartnerService : ICreation<Partner, PartnerCreateDto>
    {
        public Partner GetById(object id);
        public Task<ICollection<Partner>> GetAll();
        public Task<Partner> AddCounterparties(List<long> counterpartiesTins, object id);
    }
}