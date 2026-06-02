using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eleShoppingApp;


namespace eleShoppingApp
{
    internal static class Program
    {
        // Entry point for the console app.
        // Uses a top-level loop to show the main menu until the user exits.
        static void Main(string[] args)
        {
            string continueChoice = "yes";
            int choice;
            List<UserLogin> customerList = new();

            // Seed a default customer account for testing.
            customerList.Add(new UserLogin("customer", "password"));

            // Display welcome banner
            Console.WriteLine("===================================");
            Console.WriteLine(" Welcome to Electronic Shopping App ");
            Console.WriteLine("===================================");
            Console.WriteLine();
            // Main application loop
            try
            {
                do
                {
                    //This code is displaying the welcome or the Main Menupage and ask
                    Console.WriteLine();
                    Console.WriteLine("Please select your option:");
                    Console.WriteLine("1. Login as Customer");
                    Console.WriteLine("2. Login as Staff");
                    Console.WriteLine("3. Exit");
                    Console.WriteLine();
                    Console.Write("Enter your choice: ");

                    try
                    {

                        if (!int.TryParse(Console.ReadLine(), out choice))
                        {
                            Console.WriteLine("Invalid input. Please enter a number.");
                            continue;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"An error occurred: {ex.Message}");
                        continue;
                    }

                    // Handle main menu selection
                    try
                    {
                        switch (choice)
                        {
                            // Customer menu: login, signup, or buy product.
                            case 1:
                                ShowCustomerMenu(customerList);
                                break;

                            // Staff menu: requires admin credentials.
                            case 2:
                                Console.WriteLine();
                                UserLogin.StaffLogin();
                                break;

                            // Exit application.
                            case 3:
                                Environment.Exit(0);
                                return;

                            default:
                                Console.WriteLine("Invalid choice");
                                break;
                        }

                        // Wait for the user to continue before asking if they want to stay in the app
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey(true);
                    } catch (Exception ex)
                    {
                        Console.WriteLine($"An error occurred: {ex.Message}");
                    }


                    // Ask user if they want to continue using the application or exit
                    Console.WriteLine("Do you want to continue? (yes/no): ");
                    continueChoice = Convert.ToString(Console.ReadLine() ?? "string").ToLower();

                }

                while (continueChoice == "yes");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            Console.WriteLine("GoodBye! You have a good day!");
        }//End of Main


        // ShowCustomerMenu handles the customer-facing task menu.
        // It allows login, signup, and product purchase entry.
        static void ShowCustomerMenu(List<UserLogin> customerList)
        {
            // Loop until user chooses to return to the main menu.
            while (true)
            {
                int choice;
                // Display customer menu options.
                Console.WriteLine("\nCustomer Menu:");
                Console.WriteLine("1. Login");
                Console.WriteLine("2. Signup");
                Console.WriteLine("3. Buy Product");
                Console.WriteLine("Press 'n' to go back to Main Menu");
                Console.Write("Enter your choice: ");

                // Read user input
                string input = Convert.ToString(Console.ReadLine() ?? "string").ToLower();
                try
                {
                    // If user presses 'n', return to the main menu
                    if (input == "n")
                    {
                        Console.WriteLine("Returning to main menu...");
                        return;
                    }

                    // Validate numeric input 
                    if (!int.TryParse(input, out choice))
                    {
                        Console.WriteLine("Invalid input.");
                        continue; // Restart loop
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                    continue; // Restart loop on error
                }

                // Handle customer menu options
                try
                {
                    switch (choice)
                    {
                        case 1:
                            // Call login method
                            UserLogin.Login(customerList);
                            break;

                        case 2:
                            // Create new user account
                            UserLogin? newUser = UserLogin.Signup();

                            // Add new user to list if signup succeeded
                            if (newUser != null)
                            {
                                customerList.Add(newUser);
                                Console.WriteLine("Signup successful! Please login.");
                                if (UserLogin.Login(customerList))
                                {
                                    ShowCustomerPurchaseMenu();
                                }
                            }
                            else
                            {
                                Console.WriteLine("Signup failed. Please try again.");
                            }
                            break;
                        case 3:
                            if (UserLogin.Login(customerList))
                            {
                                ShowCustomerPurchaseMenu();
                            }
                            break;

                        default:
                            // Handle invalid choice
                            Console.WriteLine("Invalid choice.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }
            }
        }

        // Displays inventory and handles the customer purchase flow.
        static void ShowCustomerPurchaseMenu()
        {
            if (UserLogin.Products.Count == 0)
            {
                Console.WriteLine("No products are available for purchase at this time.");
                return;
            }

            Console.WriteLine();
            Console.WriteLine("Available Products:");
            foreach (Product product in UserLogin.Products)
            {
                product.DisplayInfo();
            }

            Console.Write("Enter the product name you want to buy, or press 'n' to return: ");
            string searchTerm = Convert.ToString(Console.ReadLine() ?? string.Empty);
            if (searchTerm.Trim().ToLower() == "n")
            {
                return;
            }

            Product? productToBuy = Product.SearchProduct(UserLogin.Products, searchTerm);
            if (productToBuy == null)
            {
                Console.WriteLine("Product not found.");
                return;
            }

            Console.Write("Enter quantity to buy: ");
            if (!int.TryParse(Console.ReadLine(), out int purchaseQuantity) || purchaseQuantity <= 0)
            {
                Console.WriteLine("Invalid quantity.");
                return;
            }

            if (productToBuy.Purchase(purchaseQuantity))
            {
                Console.WriteLine($"You have purchased {purchaseQuantity} x {productToBuy.ProductName} for {productToBuy.ProductPrice * purchaseQuantity:C}.");
                if (productToBuy.ProductQuantity == 0)
                {
                    Console.WriteLine("This product is now out of stock.");
                }
            }
            else
            {
                Console.WriteLine("Purchase failed. Not enough stock.");
            }
        }
    }

}


