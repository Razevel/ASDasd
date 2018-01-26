using System.Collections.Generic;
using TestYST_Rodionov.Models.Entities;

namespace TestYST_Rodionov.Models.EntitiessRepos
{
    public class StockBalanceRepository
    {
        private readonly ShopDbContext _context = new ShopDbContext();

        public IEnumerable<StockBalance> StockBalances => _context.StockBalances;
    }


}