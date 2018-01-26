using System;
using System.Data.Entity;
using System.Linq;
using TestYST_Rodionov.Models.Entities;
using WebGrease.Css.Extensions;

namespace TestYST_Rodionov.Models
{

    public class ShopDbInitializer : CreateDatabaseIfNotExists<ShopDbContext>
    {
        protected override void Seed(ShopDbContext db)
        {

            #region ProductsInitialization

            db.Products.Add(new Product { Name = "Orium Ice", Vendor = "4da4d6464", Price = 3770M, PartnerPrice = 3250M });

            db.Products.Add(new Product { Name = "Nokian Nordman", Vendor = "RS2SUV225", Price = 6420M, PartnerPrice = 6040M });

            db.Products.Add(new Product { Name = "Nokian Hakkapeliitta", Vendor = " 9SUV25550R19", Price = 15970M, PartnerPrice = 15100M });

            db.Products.Add(new Product { Name = "Pirelli Ice Zero Friction", Vendor = "225R17H103", Price = 6530M, PartnerPrice = 6350M });

            db.Products.Add(new Product { Name = "Gislaved Nord Frost", Vendor = "200ID195R15", Price = 3301M, PartnerPrice = 3009.50M });

            db.Products.Add(new Product { Name = "НШЗ Кама-Никола", Vendor = "a195R15H9", Price = 2250M, PartnerPrice = 2150M });

            db.Products.Add(new Product { Name = "Cordiant Snow Cross", Vendor = "21565102", Price = 4000M, PartnerPrice = 3825M });

            
            db.SaveChanges();

            #endregion

            #region StocksInitialization

            db.Stocks.Add(new Stock { Name = "На Ппромышленной" });
            db.Stocks.Add(new Stock { Name = "РРЦ АвтоТранс" });

            db.SaveChanges();

            #endregion

            #region StockBalancesInitialization

            Random r = new Random();

            foreach (var stock in db.Stocks.ToArray())
            {
                foreach (var product in db.Products.ToArray())
                {
                    db.StockBalances.Add(new StockBalance
                    {
                        Product = product,
                        Count = r.Next(0, 100),
                        Stock = stock
                    });
                }                
            }

            db.SaveChanges();
            //Имитируем что эти товары кончились
            db.StockBalances
                .Where(sb=>sb.Product.Id == 2 || sb.Product.Id == 5)
                .ForEach(sb=>sb.Count = 0);

            db.SaveChanges();

            #endregion

            #region SomeOrdersInitialization

            //Cart 1
            {
                var sb = new Cart();
                sb.SessionId = 1010654;

                foreach (var product in db.Products)
                {
                    sb.Orders.Add(new Order { Product = product, Quantity = r.Next(1, 10) });
                }

                db.Carts.Add(sb);
                db.SaveChanges();
            }

            //Cart 2
            {
                var sb = new Cart();
                sb.SessionId = 1177354;

                foreach (var product in db.Products)
                {
                    sb.Orders.Add(new Order { Product = product, Quantity = r.Next(3, 18) });
                }

                db.Carts.Add(sb);
                db.SaveChanges();
            }

            #endregion

            base.Seed(db);
        }
    }

}