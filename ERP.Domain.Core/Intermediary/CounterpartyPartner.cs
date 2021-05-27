using ERP.Domain.Core.Models;

namespace ERP.Domain.Core.Intermediary
{
    public class CounterpartyPartner
    {
        public long CounterpartyId { get; set; }
        public virtual Counterparty Counterparty { get; set; }
        
        public long PartnerId { get; set; }
        public virtual Partner Partner { get; set; }

        public CounterpartyPartner()
        {
        }
    }
}