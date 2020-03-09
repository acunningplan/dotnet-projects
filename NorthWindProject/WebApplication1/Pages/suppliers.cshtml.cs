using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using Packt.Shared;
using System.Linq;
using NorthwindContextLib;
using Microsoft.AspNetCore.Mvc;

namespace NorthWindWeb.Pages
{
    public class SuppliersModel : PageModel
    {
        private Northwind db;
        public SuppliersModel(Northwind injectedContext)
        {
            db = injectedContext;
        }
        public IEnumerable<string> Suppliers { get; set; }
        public void OnGet()
        {
            ViewData["Title"] = "Northwind Web Site - Suppliers";
            //Suppliers = new[]
            //{
            //    "Alpha Co", "Beta Limited", "Gamma Corp"
            //};
            Suppliers = db.Suppliers.Select(s => s.CompanyName);
        }

        [BindProperty]
        public Supplier Supplier { get; set; }
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                db.Suppliers.Add(Supplier);
                db.SaveChanges();
                return RedirectToPage("/suppliers");
            }
            return Page();
        }
    }
}