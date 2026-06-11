namespace eleShoppingApp;

public class CustomerMenu
{
    private List<Product> allProducts; //The list should match with the products list from admin
    private Cart cart;

    public CustomerMenu(List<Product> products)
    {
        allProducts = products;
        cart = new Cart(products);
    }

    // Authenticates customer by comparing entered credentials against saved users
    public static void Login(List<UserLogin> users)
    {
        bool isAuthenticated = false;

        do
        {
            try
            {
                Console.WriteLine();
                Console.WriteLine("|                Customer Login            |");
                Console.WriteLine("--------------------------------------------");
                Console.WriteLine("| p. | To go back to previous menu         |");
                Console.WriteLine("---------------------------------------------");
                Console.WriteLine();
                Console.Write("Enter your Username: ");
                string user = Console.ReadLine() ?? string.Empty;
                if (user.Trim().ToLower() == "p")
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
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        } while (!isAuthenticated);
    }

    public void ShowMenu()
    {
        int choice = 0;
        do
        {
            try
            {
                Console.WriteLine();
                Console.WriteLine("|                CUSTOMER MENU.            |");
                Console.WriteLine("|------------------------------------------|");
                Console.WriteLine("| 1. | View All Products                   |");
                Console.WriteLine("| 2. | View Products by Category           |");//List the products by category, then the user can choose which category of the products they want to view.
                Console.WriteLine("| 3. | Add the product to Cart             |");//The user can add the product to the cart by entering the product ID, then the system will check if the product ID is valid and if it is, it will add the product to the cart.
                Console.WriteLine("| 4. | Remove the product from the Cart    |");//The user can remove the product from the cart by entering the product ID, then the system will check if the product ID is valid and if it is, it will remove the product from the cart.
                Console.WriteLine("| 5. | Search the product(s)               |");//The user can search the product by entering the keyword, then the system will search the product from the list and display the search result to the user.
                Console.WriteLine("| 6. | Go to Cart                          |");//The user can view the items in their cart and manage them.
                Console.WriteLine("| 7. | Checkout                            |");//Complete purchase and reduce stock quantity.
                Console.WriteLine("| 8. | Exit                                |");
                Console.WriteLine("| p. | To go back to previous menu         |");
                Console.WriteLine("|------------------------------------------|");
                Console.WriteLine();
                Console.Write("Please enter your choice: ");
                Console.WriteLine();
                string menuInput = Console.ReadLine() ?? string.Empty;
                if (menuInput.Trim().ToLower() == "p")
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
                        ViewAllProducts();
                        break;
                    case 2:
                        ViewProductsMenu();
                        break;
                    case 3:
                        cart.AddProduct();
                        break;
                    case 4:
                        cart.RemoveProduct();
                        break;
                    case 5:
                        SearchProducts();
                        break;
                    case 6:
                        cart.DisplayCart();
                        break;
                    case 7:
                        cart.Checkout();
                        break;
                    case 8:
                        Console.WriteLine("Thank you for shopping with us. See you next time!");
                        break;
                    default:
                        Console.WriteLine("Invalid choice, please try again.");
                        break;
                }//End of switch
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        } while (choice != 7);
    }
        //Method: View products by category, the user can choose which category of the products they want to view.
        
        public void ViewAllProducts()
        {
            Console.WriteLine("------------ All Products ------------");
            foreach (var product in allProducts)
            {
                if (product.ProductQuantity > 0)
                {
                    Console.WriteLine($"ID: {product.ProductID}, Name: {product.ProductName}, Price: ${product.ProductPrice}");
                    Console.WriteLine($"Product Description: {product.ProductDescription}");
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine($"{product.ProductName} is out of stock.");
                    Console.WriteLine();
                }
            }
        }
        private void ViewProductsMenu()
        {
            do
        {
            try
            {
                Console.WriteLine("Please select the category of the products \nyou want to view.");
                Console.WriteLine();
                Console.WriteLine("|             PRODUCTS CATEGORIES          |");
                Console.WriteLine(" -------------------------------------------");
                Console.WriteLine(" |  1. | Laptop                            |");
                Console.WriteLine(" |  2. | Headphone                         |");
                Console.WriteLine(" |  3. | TV                                |");
                Console.WriteLine(" |  4. | Tablet                            |");
                Console.WriteLine(" |  5. | Smartphone                        |");
                Console.WriteLine(" |  6. | Smartwatch                        |");
                Console.WriteLine(" |  p. | To go back to previous menu       |");
                Console.WriteLine(" |-----------------------------------------|");
                Console.WriteLine();
                Console.Write("Please choose what type of the products would\n you like to view: ");
                Console.WriteLine();
                string categoryInput = Console.ReadLine() ?? string.Empty;
                if (categoryInput.Trim().ToLower() == "p")
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
                        category = "Headphones";
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

                Console.WriteLine($"------------ {category} Products ------------");

                if (categoryProducts.Count == 0)
                {
                    Console.WriteLine($"No {category} products found.");
                    Console.WriteLine();
                    continue;
                }

                foreach (var product in categoryProducts)
                {
                    if (product.ProductQuantity > 0)
                    {
                        Console.WriteLine($"ID: {product.ProductID}, Name: {product.ProductName}, Price: ${product.ProductPrice}");
                        Console.WriteLine($"Product Description: {product.ProductDescription}");
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.WriteLine($"{product.ProductName} is out of stock.");
                        Console.WriteLine();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            } while (true);
        }//End of ViewProductsMenu method
       
         //Method: Search product, the user can search the product by entering the keyword, then the system will search the product from the list and display the search result to the user.
        private void SearchProducts()
        {
            try
            {
                Console.Write("Enter the keyword of the product that\n you would like to search: ");
                string keyword = Convert.ToString(Console.ReadLine() ?? string.Empty);

                List<Product> result = allProducts.Where(p => p.ProductName.Contains(keyword, StringComparison.OrdinalIgnoreCase)).ToList();

                if (result.Count > 0)
                {
                    Console.WriteLine("------------Search Results------------");

                    foreach (var product in result)
                    {
                        if (product.ProductQuantity > 0)
                        {
                            Console.WriteLine($"ID: {product.ProductID}, Name: {product.ProductName}, Price: ${product.ProductPrice}");
                            Console.WriteLine($"Product Description: {product.ProductDescription}");
                            Console.WriteLine();
                        }
                        else
                        {
                            Console.WriteLine($"{product.ProductName} is out of stock.");
                            Console.WriteLine();
                        }
                    }
                }
                else
                {
                    Console.WriteLine("No products found.");
                    Console.WriteLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }//End of SearchProducts method

    }//End of class
