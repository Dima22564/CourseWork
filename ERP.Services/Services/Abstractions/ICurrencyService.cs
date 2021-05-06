using System.Collections.Generic;
using System.Threading.Tasks;
using ERP.Domain.Core.Models;
using ERP.Services.DTO;
using ERP.Services.DTO.Creation;

namespace ERP.Services.Services.Abstractions
{
    public interface ICurrencyService : IFetch<Currency>, ICreation<Currency, CreateCurrencyDto>
    {
        public float GetExchangeRateForCurrencyFromExternalApi(int currencyNumericCode);
        public Task<Currency> ChangeByCode(CreateCurrencyDto currencyDto);
    }
}