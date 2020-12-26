using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aegis.Model
{
    public class ProductFeature
    {
        public ProductFeature()
        {

        }

        public int Id { get; set; }
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
    }
}
