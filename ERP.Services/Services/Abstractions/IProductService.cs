namespace ERP.Services.Services.Abstractions
{
    public interface IProductService
    {
        public void CreateProduct();
        public void UpdateProduct();

        public void CreateStorageUnit();
        public void UpdateStorageUnit();

        public void CreateProductKind();
        public void UpdateProductKind();
    }
}