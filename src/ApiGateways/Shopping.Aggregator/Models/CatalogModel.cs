using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping.Aggregator.Models
{
    public class CatalogModel
    {
        public string ProductName { get; set; }
        public string Category { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }
        public string ImageFile { get; set; }
    }
}
