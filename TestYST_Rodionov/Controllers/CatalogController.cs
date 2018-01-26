using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Mvc;
using TestYST_Rodionov.Models;
using TestYST_Rodionov.Models.EntitiessRepos;
using WebGrease.Css.Extensions;

namespace TestYST_Rodionov.Controllers
{
    public class CatalogController : Controller
    {
        private int pageSize = 4;
        public ActionResult List(int page = 1, string nameFilter = null)
        {
            var products = new ProductRepository().Products.ToArray()
                .Where(p => p.Balance>0).ToArray();

            

            if (nameFilter!=null)
            {
                products = products.Where(p => p.Name.Contains(nameFilter) || p.Vendor.Contains(nameFilter)).ToArray();
            }


            bool isPartner = false;
            if (User.Identity.IsAuthenticated)
            {
                isPartner = ApplicationDbContext.Create().Users.ToArray()
                    .First(x => x.Id == User.Identity.GetUserId())
                    .IsPartner;
            }

            if (isPartner)
            {
                products.ForEach(x=>x.Price=x.PartnerPrice);
            }

            var prvm = new ProductsListViewModel
            {
                Products = products
                .OrderBy(p => p.Id)
                .Skip((page-1)*pageSize)
                .Take(pageSize),

                PaginationInfo = new PaginationInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = products.Length,
                }
            };

            return View(prvm);
        }

        [HttpPost]
        public RedirectToRouteResult Filter(string filter = null)
        {
            return RedirectToAction("List", "Catalog", new{ nameFilter = filter });
        }
    }
}