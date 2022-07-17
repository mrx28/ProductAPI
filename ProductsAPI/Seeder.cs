using ProductsAPI.Entities;
using System.Collections;

namespace ProductsAPI
{
    public class Seeder
    {
        private readonly DatabaseContext _db;
        public Seeder(DatabaseContext db)
        {
            _db = db;

        }
        public void Seed()
        {
            if (_db.Database.CanConnect())
            {
                if (!_db.Products.Any())
                {
                    IEnumerable<Product> defaultProd = GetDefaultProducts();
                    _db.Products.AddRange(defaultProd);
                    _db.SaveChanges();
                }
            }
        }

        private IEnumerable<Product> GetDefaultProducts()
        {
            IList<Product> products = new List<Product>()
            {
                 new Product()
                {
                    Code = "451-258",
                    Name = "Pralka Indesit P45",
                    Price = 1200
                },
                  new Product()
                {
                    Code = "451-2887",
                    Name = "Pralka Amica 874",
                    Price = 987
                }
            };

            return products;
            

        }
    }
}
