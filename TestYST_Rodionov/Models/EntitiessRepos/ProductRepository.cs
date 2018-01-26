using System.Collections.Generic;
using TestYST_Rodionov.Models.Entities;

namespace TestYST_Rodionov.Models.EntitiessRepos
{
    public class ProductRepository 
    {
        private readonly ShopDbContext _context = new ShopDbContext();

        public IEnumerable<Product> Products => _context.Products;
    }
}