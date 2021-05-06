using System.Collections.Generic;
using System.Threading.Tasks;
using ERP.Domain.Core.Models;
using ERP.Services.DTO.Creation;

namespace ERP.Services.Services.Abstractions
{
    public interface IPartnerService : IFetch<Partner>, ICreation<Partner, PartnerCreateDto>
    {
        public Task<Partner> AddCounterparties(IEnumerable<long> counterpartiesTins, object id);
    }
}