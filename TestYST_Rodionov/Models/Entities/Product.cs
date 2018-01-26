using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace TestYST_Rodionov.Models.Entities
{
    public class Product
    {
        public int Id { get; set; }

        [NotMapped]
        public int Balance {
            get { return StockBalance.Sum(sb=>sb.Count); }

        }


        public string Name { get; set; }

        public string Vendor { get; set; }

        public decimal Price { get; set; }

        public decimal PartnerPrice { get; set; }

        public virtual List<StockBalance> StockBalance { get; set; }

        public virtual List<Order> Orders { get; set; }
    }
}