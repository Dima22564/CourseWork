using System.ComponentModel.DataAnnotations.Schema;
using ERP.Domain.Core.Abstract;
using JetBrains.Annotations;

namespace ERP.Domain.Core.Models
{
    public class ClientOrderProduct : BaseEntity, IDocumentProduct
    {
        public int Quantity { get; set; }
        public float Price { get; set; }
        public float Amount { get; set; }
        public int PositionNumber { get; set; }
        public float Sale { get; set; }

        public string Action { get; set; }
        public bool Cancelled { get; set; } = false;
        [CanBeNull] public string ReasonForCancel { get; set; }

        public string ClientOrderId { get; set; }
        public virtual ClientOrder ClientOrder { get; set; }

        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}