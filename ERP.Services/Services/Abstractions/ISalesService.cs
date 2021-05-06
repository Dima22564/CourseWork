namespace ERP.Services.Services.Abstractions
{
    public interface ISalesService
    {
        public void CreateBusinessProposal();
        public void CreateOrderBasedOnBusinessProposal();
        public void CreateAgreement();

        public void ApproveBusinessProposal();
        public void ApproveAgreement();
    }
}