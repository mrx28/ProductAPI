using ProductsAPI.Dto;

namespace ProductsAPI.Interfaces
{
    public interface IProductService
    {
        void AddProduct(ProductDto obj);
        IList<ProductDto> GetProducts();
    }
}
