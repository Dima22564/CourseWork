using ERP.Services.DTO.Abstract;

namespace ERP.Services.DTO.Creation
{
    public class ProductCreateDto : CreationDto
    {
        public string Code { get; set; }
        public string WorkName { get; set; }
        public string FullName { get; set; }
        public int Vat { get; set; }
        public float Price { get; set; }
        public int Quantity{ get; set; }
    }
}