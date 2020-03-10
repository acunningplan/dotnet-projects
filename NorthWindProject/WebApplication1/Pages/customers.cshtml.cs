
using NorthwindContextLib;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Packt.Shared;
using System.Collections.Generic;
using System.Linq;

namespace NorthwindWeb.Pages
{
    public class CustomersModel : PageModel
    {
        private readonly Northwind _injectedContext;
        public CustomersModel(Northwind injectedContext)
        {
            _injectedContext = injectedContext;
        }

        public class CustomerItem
        {
            public string CustomerID;
            public string CompanyName;
            public string Country;
        }

        public IEnumerable<CustomerItem> Customers { get; set; }
        public void OnGet()
        {
            ViewData["Title"] = "Northwind Web Site - Customers";
            Customers = _injectedContext.Customers
                .Select(s => new CustomerItem { CompanyName = s.CompanyName, Country = s.Country, CustomerID = s.CustomerID })
                .OrderBy(s => s.Country);
        }
    }
}