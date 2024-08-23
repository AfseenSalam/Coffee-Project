using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
/*
 * Write a cash register or self-service terminal.
/*Your solution must include some kind of a product class with a name, category, description, and price for each item.
12 items minimum; stored in a list.
Present a menu to the user and let them choose an item (by number or letter).
Allow the user to choose a quantity for the item ordered.
Give the user a line total (item price * quantity).
Either through the menu or a separate question, allow them to re-display the menu and to complete the purchase.
Give the subtotal, sales tax, and grand total.  (Remember rounding issues the Math library will be handy!)
Ask for payment type—cash, credit, or check
For cash, ask for amount tendered and provide change.
For check, get the check number.
For credit, get the credit card number, expiration, and CVV.
At the end, display a receipt with all items ordered, subtotal, grand total, and appropriate payment info.
Return to the original menu for a new order.  (Hint: you’ll want an array or List to keep track of what’s been ordered!)
Optional enhancements:
(Moderate) Store your list of products in a text file and then include an option to add to the product list, which then outputs to the product file.
(Buff) Do a push up every time you get an exception or error while running your code*/

namespace DAD_s_Coffee_Shop_Lab
{
    internal class Coffee
    {

        //properties
        public string Name { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }

        //constructor

        public Coffee(string _name, string _category, string _description, double _price)
        {
            Name = _name;
            Category = _category;
            Description = _description;
            Price = _price;
        }

        //methods

        public static List<Coffee> products = new List<Coffee> { new Coffee("Espresso", "Coffee", "Strong, black coffee", 2.50),
    new Coffee("Cappuccino", "Coffee", "Espresso with steamed milk and foam", 3.75),
    new Coffee("Latte", "Coffee", "Espresso with steamed milk", 3.50),
    new Coffee("Mocha", "Coffee", "Espresso with chocolate and steamed milk", 4.00),
    new Coffee("Macchiato", "Coffee", "Espresso with a dollop of foam", 3.00),
    new Coffee("Americano", "Coffee", "Espresso with hot water", 2.75),
    new Coffee("Chai Latte", "Tea", "Spiced tea with steamed milk", 3.25),
    new Coffee("Green Tea", "Tea", "Refreshing and healthy green tea", 2.25),
    new Coffee("Herbal Tea", "Tea", "Caffeine-free herbal infusion", 2.50),
    new Coffee("Hot Chocolate", "Beverage", "Rich chocolate with steamed milk", 3.00),
    new Coffee("Iced Coffee", "Cold Beverage", "Chilled coffee with ice", 3.00),
    new Coffee("Iced Tea", "Cold Beverage", "Chilled tea with ice", 2.50)};

        public override string ToString()
        {
            return String.Format("{0,15} {1,20} {2,45} {3,10}", $"{Name}|", $"{Category}|", $"{Description}|", $"{Price}|");
        }


        public static void ListProducts()
        {
            for (int i = 0; i < products.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {products[i]}");
            }
        }


    }
}