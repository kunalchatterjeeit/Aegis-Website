using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aegis.Model
{
    public class ProductDisplay
    {
        public ProductDisplay()
        {

        }

        public int Id { get; set; }
        public int ProductId { get; set; }
        public string Name { get; set; }
        public int ContentTypeId { get; set; }
        public string ContentPath { get; set; }
        public bool IsActive { get; set; }
    }
}
