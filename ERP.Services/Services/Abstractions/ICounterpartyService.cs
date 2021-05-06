using System.Collections.Generic;
using System.Threading.Tasks;
using ERP.Domain.Core.Models;
using ERP.Services.DTO.Creation;

namespace ERP.Services.Services.Abstractions
{
    public interface ICounterpartyService : ICreation<Counterparty, CreateCounterpartyDto>
    {
        //public void AddAlcoLicenses();
        //public void AddPartners();
        //public void AddBankAccounts();
        public Task<Counterparty> UpdateContacts(CounterpartyContactsCreateDto dto);
        public Counterparty GetById(object id);
        public Task<ICollection<Counterparty>> GetAll();
    }
}