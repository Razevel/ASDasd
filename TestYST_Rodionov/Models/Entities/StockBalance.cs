namespace TestYST_Rodionov.Models.Entities
{
    public class StockBalance
    {
        public int Id { get; set; }

        public Stock Stock { get; set; }

        public Product Product { get; set; }

        public int Count { get; set; }
    }
}