using ERP.Domain.Core.Models;

namespace ERP.Domain.Core.Intermediary
{
    public class PartnerContactPeople
    {
        public int ContactPersonId { get; set; }
        public ContactPerson ContactPerson { get; set; }

        public long PartnerId { get; set; }
        public Partner Partner { get; set; }
    }
}