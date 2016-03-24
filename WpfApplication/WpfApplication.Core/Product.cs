using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication.Core
{
    public class Product
    {
        public Product()
        {
            Name = string.Empty;
            Unit = string.Empty;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Unit { get; set; }
        public double Rate { get; set; }
        public double VatPercent { get; set; }

        public override bool Equals(object obj)
        {
            var product = obj as Product;

            if (product == null)
            {
                return false;
            }

            return product.Name == Name
                && product.Unit == Unit
                && product.Rate == this.Rate
                && product.VatPercent == this.VatPercent;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode() ^ Unit.GetHashCode() ^ Rate.GetHashCode() ^ VatPercent.GetHashCode();
        }
    }
}
