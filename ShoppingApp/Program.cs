using System.Text.Json;

namespace ShoppingApp

{
    public class Product
    {
        public int id { get; set; }
        public string name { get; set; } = null;
        public decimal? price { get; set; }
    }


    internal class Program

    {
        static string path = "C:\\Users\\Lines Tech\\projects\\PersonalInfo\\ShoppingApp\\Product.json";
        static string json = File.ReadAllText(path);
        static List<Product> Jsondata = JsonSerializer.Deserialize<List<Product>>(json).ToList();
        static List<Product> userCart = new List<Product>();
        static string userInput { get; set; } = null;
        static string userConfirm { get; set; } = null;
        static string productId { get; set; } = null;
        static bool valid { get; set; }
        static int number;

        static void Main(string[] args)
        {
            AskUser();
            if (userInput == "y")
            {
                do
                {
                    askProductId();
                    addProductToCart(Jsondata);
                    AskUser();
                    if (userInput == "n")
                    {
                        var total = userCart.Sum(p => p.price);
                        Console.WriteLine(total);
                    }
                }
                while (userInput == "y");
            }

            else if (userInput == "n")
            {
                do
                {
                    Console.Write("You haven't choose product. Do you want to exit? ");
                    userConfirm = Console.ReadLine();

                }
                while (!(userInput == "y") && !(userInput == "n"));
                
                if (userConfirm == "y")
                {
                    Console.WriteLine("You exit without purchasing the product");
                    return;
                }

                else if (userConfirm == "n")
                {
                    do
                    {
                        askProductId();
                        addProductToCart(Jsondata);
                        AskUser();
                        if (userInput == "n")
                        {
                            var total = userCart.Sum(p => p.price);
                            Console.WriteLine("Your list product: ");
                            foreach (Product product in userCart)
                            {
                                Console.WriteLine(product.name);
                            }
                            Console.WriteLine($"You have to pay for your shopping cart is {total}$" );
                        }
                    }
                    while (userInput == "y");
                }
            }

            Console.ReadKey();
        }

        static void AskUser()
        {
            do
            {
                Console.Write("Do you want to buy? (y or n) : ");
                userInput = Console.ReadLine();
            }
            while (!(userInput == "y") && !(userInput == "n"));
        }

        static void askProductId()
        {
            do
            {
                Console.Write("What your id product? ");
                productId = Console.ReadLine();
                valid = int.TryParse(productId, out number);
            }
            while (!valid);
        }

        static void addProductToCart(List<Product> Carts)
        {
            foreach (var item in Carts)
            {
                if (item.id == number)
                {
                    Product addCart = new Product();
                    addCart.id = item.id;
                    addCart.name = item.name;
                    addCart.price = item.price;
                    userCart.Add(addCart);
                }
            }
        }
    }
}