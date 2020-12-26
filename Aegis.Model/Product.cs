using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aegis.Model
{
    public class Product
    {
        public Product()
        {

        }
        public int Id { get; set; }
        public int ProductCategoryId { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public string SeoUrl { get; set; }
        public List<ProductDisplay> ProductDisplays { get; set; }
        public List<ProductFeature> ProductFeatures { get; set; }
        public string ProductCategoryName { get; set; }
    }

    public class ProductList {
        public List<Product> products { get; set; }
    }
}
