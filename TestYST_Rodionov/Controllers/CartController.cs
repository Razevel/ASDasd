using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TestYST_Rodionov.Models;
using TestYST_Rodionov.Models.Entities;
using TestYST_Rodionov.Models.EntitiessRepos;

namespace TestYST_Rodionov.Controllers
{
    public class CartController : Controller
    {
        public ViewResult Index()
        {
            var vm = new List<OrderViewModel>();
            bool isPartner = false;
            if (User.Identity.IsAuthenticated)
            {
                isPartner = ApplicationDbContext.Create().Users.ToArray()
                    .First(x => x.Id == User.Identity.GetUserId())
                    .IsPartner;
            }
            GetCart().IsPartner = isPartner;
            foreach (var o in GetCart().Orders)
            {
                vm.Add(new OrderViewModel(o.Product, o.Quantity, isPartner ? o.Product.PartnerPrice : o.Product.Price));
            }

            return View(vm);
        }

        public PartialViewResult Menu()
        {
            return PartialView(GetCart());
        }

        public RedirectResult Clear()
        {
            GetCart().Clear();

            //TODO Добавить проверку на null
            return Redirect(HttpContext.Request.UrlReferrer.OriginalString);
        }

        public Cart GetCart()
        {
            var cart = (Cart) Session["Cart"];
            if (cart == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
                bool isPartner = false;
                if (User.Identity.IsAuthenticated)
                {
                    isPartner = ApplicationDbContext.Create().Users.ToArray()
                        .First(x => x.Id == User.Identity.GetUserId())
                        .IsPartner;
                }
                cart.IsPartner = isPartner;
            }
            
            return cart;
        }

        public RedirectResult Add(int id)
        {
            var product = new ProductRepository().Products
                .FirstOrDefault(b => b.Id == id);

            if (product != null)
            {
                GetCart().Add(product);
            }

            //TODO Добавить проверку на null
            return Redirect(HttpContext.Request.UrlReferrer.OriginalString);
        }

        public RedirectResult Remove(int id)
        {
            Product product = new ProductRepository().Products
                .FirstOrDefault(b => b.Id == id);

            if (product != null)
            {
                GetCart().Remove(product);
            }

            //TODO Добавить проверку на null
            return Redirect(HttpContext.Request.UrlReferrer.OriginalString);
        }
    }
}