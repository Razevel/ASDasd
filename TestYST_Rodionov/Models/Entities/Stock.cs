using System.Collections.Generic;

namespace TestYST_Rodionov.Models.Entities
{
    public class Stock
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual List<StockBalance> StockBalance { get; set; }

    }
}