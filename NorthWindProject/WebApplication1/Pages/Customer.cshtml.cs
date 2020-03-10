using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace NorthwindWeb
{
    public class CustomerModel : PageModel
    {
        public string CustomerID { get; set; }
        public void OnGet()
        {
            CustomerID = HttpContext.Request.Path;
        }
    }
}