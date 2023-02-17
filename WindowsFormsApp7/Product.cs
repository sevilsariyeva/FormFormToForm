using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp7
{
    public class Product
    {
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal ProductPrice { get; set; }
        public override string ToString()
        {
            return $"{ProductName} - {Description} - {ProductPrice}";
        }
    }
}
