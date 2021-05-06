using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ERP.Domain.Core.Abstract;
using ERP.Domain.Core.Enums;

namespace ERP.Domain.Core.Models
{
    [Table("AgreementsWithCustomers")]
    public class AgreementWithCustomer : Document
    {
        public DocumentStatuses Status { get; set; }
        public bool IncludeVat { get; set; }
        public Vat VatRate { get; set; }
        public string Name { get; set; }

        public virtual Partner Partner { get; set; }
        public long PartnerId { get; set; }

        public virtual Currency Currency { get; set; }
        public int CurrencyCode { get; set; }
        
        public virtual ICollection<ClientOrder> ClientOrders { get; set; }

    }
}