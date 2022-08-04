using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Product
{
    public class ProductDTO
    {
        public string Description { get; set; }
        public bool Situation { get; set; }
        public DateTimeOffset ManufacturingAt { get; set; }
        public DateTimeOffset ValidUntil { get; set; }
        public long SupplierId { get; set; }
        public string DescriptionSupplier { get; set; }
        public string SupplierCnpj { get; set; }
    }
}
