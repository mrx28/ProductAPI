using AutoMapper;
using ProductsAPI.Dto;
using ProductsAPI.Entities;
using ProductsAPI.Interfaces;

namespace ProductsAPI.Services
{
    public class ProductService : IProductService
    {
        private readonly ICrudOperation<Product> _productRepsitory;
        private readonly IMapper _mapper;

        public ProductService(
            ICrudOperation<Product> productRepository,
            IMapper mapper
            )
        {
            _productRepsitory = productRepository;
            _mapper = mapper;
        }
        public void AddProduct(ProductDto objDto)
        {
            var obj = _mapper.Map<Product>(objDto);
            _productRepsitory.Add(obj);
        }

        public IList<ProductDto> GetProducts()
        {
            var prods = _productRepsitory.GetAll();
            List<ProductDto> res = _mapper.Map<List<ProductDto>>(prods); 
            return res;
        }
    }
}
