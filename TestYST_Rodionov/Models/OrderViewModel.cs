using TestYST_Rodionov.Models.Entities;

namespace TestYST_Rodionov.Models
{
    public class OrderViewModel
    {
        public OrderViewModel(Product product, int quantity, decimal price)
        {
            Product = product;
            Quantity = quantity;
            Price = price;
        }

        public Product Product { get; set; }

        public int Quantity { get; set; }

        //Итоговая (партнер/нет)
        public decimal Price { get; set; }

        public decimal TotalCost => Quantity * Price;
    }
    
}