using ERP.Domain.Core.Models;

namespace ERP.Domain.Core.Intermediary
{
    public class TypeProduct
    {
        public int ProductKindId { get; set; }
        public ProductKind ProductKind { get; set; }
        
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}