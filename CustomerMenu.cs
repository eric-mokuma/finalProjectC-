namespace eleShoppingApp;

public class CustomerMenu
{
    private List<Product> allProducts; //The list should match with the products list from admin
    private Cart cart;

    public CustomerMenu(List<Product> products)
    {
        allProducts = products;
        cart = new Cart();
    }

    // Authenticates customer by comparing entered credentials against saved users
    public static void Login(List<UserLogin> users)
    {
        bool isAuthenticated = false;

        do
        {
            Console.WriteLine();
            Console.WriteLine("|          Customer Login          |");
            Console.WriteLine("====================================");
            Console.WriteLine("| n. | To go back to previous menu           |");
            Console.WriteLine("====================================");
            Console.WriteLine();
            Console.Write("Enter your Username (or n to go back): ");
            string user = Console.ReadLine() ?? string.Empty;
            if (user.Trim().ToLower() == "n")
            {
                Console.WriteLine("Returning to the previous menu...");
                return;
            }

            Console.Write("Enter your Password: ");
            string pass = Console.ReadLine() ?? string.Empty;

            foreach (UserLogin existingUser in users)
            {
                if (existingUser.Username == user && existingUser.Password == pass)
                {
                    Console.WriteLine();
                    Console.WriteLine("Customer login successful!");
                    isAuthenticated = true;
                    //after the customer successfully login, show the Customer menu
                    List<Product> products = Program.ProductInventory;//Refers to Products entered in the list from admin (staff side)

                    CustomerMenu menu = new CustomerMenu(products);
                    menu.ShowMenu();

                    break;
                }
            }

            if (!isAuthenticated)
            {
                Console.WriteLine();
                Console.WriteLine("Invalid login, please try again.");
            }
        } while (!isAuthenticated);
    }

        public void ShowMenu()
        {
            int choice;
            do
            {
            Console.WriteLine("|              CUSTOMER MENU.           |");
            Console.WriteLine("|---------------------------------------|");
            Console.WriteLine("| 1. | View the list of the Products    |");//List the products by category, then the user can choose which category of the products they want to view.
            Console.WriteLine("| 2. | Add the product to Cart          |");//The user can add the product to the cart by entering the product ID, then the system will check if the product ID is valid and if it is, it will add the product to the cart.
            Console.WriteLine("| 3. | Remove the product from the Cart |");//The user can remove the product from the cart by entering the product ID, then the system will check if the product ID is valid and if it is, it will remove the product from the cart.
            Console.WriteLine("| 4. | Search the product(s)            |");//The user can search the product by entering the keyword, then the system will search the product from the list and display the search result to the user.
            Console.WriteLine("| 5. | Go to Cart                       |");//The user can view the items in their cart and manage them.
            Console.WriteLine("| 6. | Exit                             |");
            Console.WriteLine("| n. | To go back to previous menu      |");
            Console.WriteLine("|---------------------------------------|");
            Console.WriteLine();
            Console.Write("Please enter your choice: ");
            string menuInput = Console.ReadLine() ?? string.Empty;
            if (menuInput.Trim().ToLower() == "n")
            {
                Console.WriteLine("Returning to the previous menu...");
                return;
            }

            if (!int.TryParse(menuInput.Trim(), out choice))
            {
                Console.WriteLine("Invalid choice, please try again.");
                continue;
            }

            switch (choice)
            {
                case 1:
                    ViewProductsMenu();
                    break;
                case 2:
                    cart.AddProduct();
                    break;
                case 3:
                    cart.RemoveProduct();
                    break;
                case 4:
                    SearchProducts();
                    break;
                case 5:
                    cart.DisplayCart();
                    break;
                case 6:
                        Console.WriteLine("Thank you for shopping with us. See you next time!");
                    break;
                default:
                    Console.WriteLine("Invalid choice, please try again.");
                    break;
                }//End of switch
            } while (choice != 6); 
        }
        //Method: View products by category, the user can choose which category of the products they want to view.
        private void ViewProductsMenu()
        {
            do
            {
                Console.WriteLine("|          PRODUCTS CATEGORIES       |");
                Console.WriteLine(" -------------------------------------");
                Console.WriteLine(" |  1. | Laptop                      |");
                Console.WriteLine(" |  2. | Headphone                   |");
                Console.WriteLine(" |  3. | TV                          |");
                Console.WriteLine(" |  4. | Tablet                      |");
                Console.WriteLine(" |  5. | Smartphone                  |");
                Console.WriteLine(" |  6. | Smartwatch                  |");
                Console.WriteLine(" |  n. | To go back to previous menu |");
                Console.WriteLine(" |-----------------------------------|");
                Console.Write("Please choose what type of the products would you like to view: ");
                string categoryInput = Console.ReadLine() ?? string.Empty;
                if (categoryInput.Trim().ToLower() == "n")
                {
                    Console.WriteLine("Returning to the previous menu...");
                    return;
                }

                if (!int.TryParse(categoryInput.Trim(), out int option))
                {
                    Console.WriteLine("Invalid choice.");
                    continue;
                }

                Console.WriteLine();

                string category = "";
                switch (option)
                {
                    case 1:
                        category = "Laptop";
                        break;
                    case 2:
                        category = "Headphone";
                        break;
                    case 3:
                        category = "TV";
                        break;
                    case 4:
                        category = "Tablet";
                        break;
                    case 5:
                        category = "Smartphone";
                        break;
                    case 6:
                        category = "Smartwatch";
                        break;
                    default:
                        Console.WriteLine("Invalid choice.");
                        continue;
                }//End of switch
                var categoryProducts = allProducts
                .Where(p => p.ProductType.Equals(category, StringComparison.OrdinalIgnoreCase))
                .ToList();

                Console.WriteLine($"\n--- {category} Products ---");

                foreach (var product in categoryProducts)
                {
                    Console.WriteLine($"ID: {product.ProductID}, Name: {product.ProductName}, Price: ${product.ProductPrice}");//May neeed to change the property name to match with the products class
                }

            } while (true);
        }//End of ViewProductsMenu method
       
         //Method: Search product, the user can search the product by entering the keyword, then the system will search the product from the list and display the search result to the user.
        private void SearchProducts()
        {
            Console.Write("Enter the keyword of the product that you would like to search: ");
            string keyword = Convert.ToString(Console.ReadLine() ?? "string");

            List<Product> result = allProducts.Where(p => p.ProductName.Contains(keyword, StringComparison.OrdinalIgnoreCase)).ToList();

            if (result.Count > 0)
            {
                Console.WriteLine("\nSearch Results:");

                foreach (var product in result)
                {
                    Console.WriteLine(
                        $"ID: {product.ProductID}, Name: {product.ProductName}, Price: ${product.ProductPrice}");
                }
            }
            else
            {
                Console.WriteLine("No products found.");
            }
        }//End of SearchProducts method

    }//End of class
