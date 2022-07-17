using ProductsAPI.Entities;
using ProductsAPI.Interfaces;

namespace ProductsAPI.Repositories
{
    public class ProductRepository : ICrudOperation<Product>
    {
        private readonly DatabaseContext _db;

        public ProductRepository(DatabaseContext db)
        {
            _db = db;   
        }
        public void Add(Product obj)
        {
            _db.Products.Add(obj);
            _db.SaveChanges();
        }

        public List<Product> GetAll()
        {
            var res = _db.Products.ToList();
            return res;
        }
    }
}
