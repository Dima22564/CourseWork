using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ERP.Domain.Core.Abstract;
using ERP.Domain.Core.Enums;
using JetBrains.Annotations;

namespace ERP.Domain.Core.Models
{
    [Table("ClientOrders")]
    public class ClientOrder : Document
    {
        public ClientOrderStates CurrentState { get; set; }
        public float PercentOfPayment { get; set; } = 0;
        public float PercentOfShipment { get; set; } = 0;
        public float Amount { get; set; }

        [CanBeNull] public virtual Company Company { get; set; }
        [CanBeNull] public long? CompanyId { get; set; }

        public virtual AgreementWithCustomer AgreementWithCustomer { get; set; }
        public string AgreementWithCustomerId { get; set; }

        [CanBeNull] public virtual BusinessProposal BusinessProposal { get; set; }
        [CanBeNull] public string BusinessProposalId { get; set; }

        public virtual ICollection<ClientOrderProduct> ClientOrderProducts { get; set; }
    }
}