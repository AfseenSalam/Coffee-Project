using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DAD_s_Coffee_Shop_Lab
{
    internal class Cart 
    {
        public int Quantity { get; set; }

        public Coffee Product{ get; set; }
        public double Multiple { get; set; }

        public static List<Cart> SCart = new List<Cart>();
        public Cart(Coffee _product,int _quantity,double _multiple)
        {
            Quantity = _quantity;
            Product = _product;
            Multiple = _multiple;
        }
        
    }
}
