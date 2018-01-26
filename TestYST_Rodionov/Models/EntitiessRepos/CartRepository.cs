using System.Collections.Generic;
using TestYST_Rodionov.Models.Entities;

namespace TestYST_Rodionov.Models.EntitiessRepos
{
    public class CartRepository
    {
        private readonly ShopDbContext _context = new ShopDbContext();

        public IEnumerable<Cart> Carts => _context.Carts;
    }


}