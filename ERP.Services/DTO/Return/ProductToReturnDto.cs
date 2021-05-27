namespace ERP.Services.DTO.Return
{
    public class ProductToReturnDto
    {
        public int ProductId { get; set; }
        public string Code { get; set; }
        public string WorkName { get; set; }
        public string FullName { get; set; }
        public int Vat { get; set; }
        public float Price { get; set; }
        public int Quantity{ get; set; }
    }
}