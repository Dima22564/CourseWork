using ERP.Domain.Core.Models;

namespace ERP.Domain.Core.Abstract
{
    public interface IDocumentProduct
    {
        public int Quantity { get; set; }
        public float Price { get; set; }
        public float Amount { get; set; }
        public int PositionNumber { get; set; }
        public float Sale { get; set; }
    }
}