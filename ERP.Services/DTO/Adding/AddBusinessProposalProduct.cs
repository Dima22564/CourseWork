namespace ERP.Services.DTO.Adding
{
    public class AddBusinessProposalProduct
    {
        public int ProductId { get; set; }
        public float Price { get; set; }
        public int Quantity { get; set; }
        public float Sale { get; set; }
        public string BusinessProposalId { get; set; }
    }
}