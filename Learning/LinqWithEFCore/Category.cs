using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace LinqWithEFCore
{
    public class Category
    {
        // these properties map to columns in the database  
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        [Column(TypeName = "ntext")]
        public string Description { get; set; }
    }
}