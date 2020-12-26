using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aegis.Model
{
    public class ProductCategory
    {
        public ProductCategory()
        {
                
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int ProductTypeId { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public string SeoUrl { get; set; }
        public string ProductTypeName { get; set; }
        public bool Selected { get; set; }
    }
}
