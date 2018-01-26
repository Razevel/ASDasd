using System;
using System.Collections.Generic;
using TestYST_Rodionov.Models.Entities;

namespace TestYST_Rodionov.Models
{
    public class ProductsListViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public PaginationInfo PaginationInfo { get; set; }
    }

    public class PaginationInfo
    {
        public int TotalItems { get; set; }
        public int ItemsPerPage { get; set; }
        public int CurrentPage { get; set; }

        public int TotalPages =>
            (int) Math.Ceiling((decimal) TotalItems / ItemsPerPage);
    }
}