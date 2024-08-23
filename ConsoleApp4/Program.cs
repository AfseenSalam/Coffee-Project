
using DAD_s_Coffee_Shop_Lab;
using System.ComponentModel.DataAnnotations;
using StaticLecture;
using System.Xml.Serialization;
string filePath = "../../../coffee.txt";
bool IsValid = true;
Console.WriteLine("Hello, World!");
/*


//if file doesn't exist
if (!File.Exists(filePath))
{
   
    //name|grade|age
    tempWriter.WriteLine("Justin Jones|12|18");
    tempWriter.WriteLine("Ethan Thomas|10|16");
   
}


*/

if (!File.Exists(filePath))
{
    StreamWriter tempCoffee = new StreamWriter(filePath);
    foreach (Coffee item in Coffee.products)
    {
        tempCoffee.WriteLine(item.ToString());
    }
    tempCoffee.Close();
}

while (IsValid)
{
    Coffee.ListProducts();
    Console.WriteLine("Enter the Menu(number /Coffee Name)");
    string?selection = Console.ReadLine();
    int input;
    //input order
    if (int.TryParse(selection, out input))
    {
        while (input > Coffee.products.Count || input < 1)
        {
            Console.WriteLine("Enter the valid input");
            input = int.Parse(Console.ReadLine());
        }
        input--;
        Coffee selected = Coffee.products[input];
        Console.WriteLine($"{selected}");
        ShoppingCart(selected);
    }

    else if ((Coffee.products.Any(p => p.Name.Equals(selection, StringComparison.OrdinalIgnoreCase))))
    {
        Coffee selected = Coffee.products.Find(p => p.Name.Equals(selection, StringComparison.OrdinalIgnoreCase));
        Console.WriteLine($"{selected}");
        ShoppingCart(selected);

    }
    else
    {
        Console.WriteLine("InValid input ");
        continue;
    }
    IsValid = StaticLecture.Validator.GetContinue("Would you like to add more:","Yes","No");
    Console.Clear();
    if (!IsValid)
    {
        DisplayRecipt();
        Console.WriteLine("Thank you for the shopping!!");
    }

}


 static void ShoppingCart(Coffee item)
{
    Console.WriteLine("Enter the quantities you need:");
    if (int.TryParse(Console.ReadLine(), out int quantity) || quantity > 0)
    {
        double rate = item.Price * quantity;
        Cart.SCart.Add(new Cart(item, quantity,rate));
        Console.WriteLine($"Added {item.Name} * {quantity} Rate {rate}");
    }
    else
    {
        Console.WriteLine("Please enter a value");
    }
}
 void DisplayRecipt()
{
    List<string> modeOfPayment = new() { "Cash", "Credit Card", "Check" };
    Console.WriteLine("Final items in Cart:");
    double grandtotal = 0;
    double subtotal = 0;
    int index = 0;
    foreach (Cart item in Cart.SCart)
    {
        Console.WriteLine($"{item.Product.Name}\t{item.Quantity}\t{item.Multiple}");
        subtotal =subtotal + item.Multiple;
    }
    double salestax = subtotal * 0.07;
    grandtotal = subtotal + salestax;
    Console.WriteLine($"Total \t {grandtotal}");
    Console.WriteLine("Select the Mode of Payment:");
   
    foreach (string s in modeOfPayment)
    {
        Console.WriteLine($"{index + 1}\t{s}");
        index++;
    }

    int input = StaticLecture.Validator.GetPositiveInputInt();
    string userSelection = modeOfPayment[input - 1];
    if (userSelection == "Cash")
    {
        Console.WriteLine("Enter the amount tendered:");
        double amount = double.Parse(Console.ReadLine());
        double balance = amount - grandtotal;
        if (balance >=0)
        {
            Console.WriteLine($"Your change:{balance}");
        }
        else if (balance < 0)
        {
            Console.WriteLine("Insufficient amount still need :{balance}");
        }
        else
        {
            Console.WriteLine("Invalid Entry");
        }
    }
    else if (userSelection == "Check")
    {
        Console.WriteLine("Please enter the check number:");
        double checknum = double.Parse(Console.ReadLine());
    }
    else if (userSelection == "Credit Card")
    {
        Console.WriteLine("Please enter the card number:");
        double cardnum = double.Parse(Console.ReadLine());
        Console.WriteLine("Enter the expiration number :");
        double expiration = double.Parse(Console.ReadLine());
        Console.WriteLine("Enter the CVV number :");
        double cvv = double.Parse(Console.ReadLine());

    }
    else
    {
        Console.WriteLine("Invalid selection");
    }


}

