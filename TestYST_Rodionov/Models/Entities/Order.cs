using System.ComponentModel.DataAnnotations.Schema;

namespace TestYST_Rodionov.Models.Entities
{
    public class Order
    {
        public int Id { get; set; }

        public Cart OwnerBag { get; set; }

        public Product Product { get; set; }

        public int Quantity { get; set; }

        [NotMapped]
        public decimal TotalCost => Quantity * Product.Price;
    }
}