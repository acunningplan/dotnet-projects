﻿using Packt.Shared;
using System.Collections.Generic;

namespace TestMvcProject.Models
{
    public class HomeIndexViewModel
    {
        public int VisitorCount { get; set; }
        public IList<Category> Categories { get; set; }
        public IList<Product> Products { get; set; }
    }
}
