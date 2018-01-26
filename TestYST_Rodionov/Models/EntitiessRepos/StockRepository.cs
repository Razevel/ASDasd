using System.Collections.Generic;
using TestYST_Rodionov.Models.Entities;

namespace TestYST_Rodionov.Models.EntitiessRepos
{
    public class StockRepository
    {
        private readonly ShopDbContext _context = new ShopDbContext();

        public IEnumerable<Stock> Stocks => _context.Stocks;
    }


}