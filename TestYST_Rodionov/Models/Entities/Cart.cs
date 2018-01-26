using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace TestYST_Rodionov.Models.Entities
{
    public class Cart
    {
        public Cart()
        {
            Orders = new List<Order>();
        }

        public int Id { get; set; }

        public int SessionId { get; set; }

        public List<Order> Orders { get; set; }

        [NotMapped]
        public bool IsPartner { get; set; }

        public void Add(Product product)
        {
            Order order = Orders
                .FirstOrDefault(o => o.Product.Id == product.Id);

            if (order == null)
            {
                Orders.Add(new Order {Product = product, Quantity = 1});
            }
            else
            {
                order.Quantity++;
            }
        }

        public void Remove(Product product)
            => Orders.RemoveAll(o => o.Product.Id == product.Id);

        public decimal TotalCost()
        {
            if (IsPartner)
                return Orders.Sum(o => o.Product.PartnerPrice * o.Quantity);
            return Orders.Sum(o => o.Product.Price * o.Quantity);
        }

        public int TotalItems() => Orders.Sum(o => o.Quantity);

        public void Clear() => Orders.Clear();
    }
}