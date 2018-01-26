using System.Collections.Generic;
using TestYST_Rodionov.Models.Entities;

namespace TestYST_Rodionov.Models.EntitiessRepos
{
    public class OrderRepository
    {
        private readonly ShopDbContext _context = new ShopDbContext();

        public IEnumerable<Order> Orders => _context.Orders;
    }


}