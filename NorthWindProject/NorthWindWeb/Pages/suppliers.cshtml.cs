using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using Packt.Shared;
using System.Linq;

namespace NorthWindWeb.Pages
{
    public class SuppliersModel : PageModel
    {
        //private Northwind db;
        //public SuppliersModel(Northwind injectedContext)
        //{
        //    db = injectedContext;
        //}
        public IEnumerable<string> Suppliers { get; set; }
        public void OnGet()
        {
            ViewData["Title"] = "Northwind Web Site - Suppliers";
            Suppliers = new[]
            {
                "Alpha Co", "Beta Limited", "Gamma Corp"
            };
            //Suppliers = db.Suppliers.Select(s => s.CompanyName);
        }
    }
}