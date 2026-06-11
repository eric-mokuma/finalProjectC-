using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eleShoppingApp;


namespace eleShoppingApp
{
    internal class Program
    {
        // Main entry point for the application
         // Shared inventory list for all products managed by staff.
        static readonly List<Product> productList = new List<Product>();
        public static List<Product> ProductInventory => productList;
            
        static void Main(string[] args)
        {
            string continueChoice = "yes";
            List<UserLogin> customerList = new List<UserLogin>();
            customerList.Add(new UserLogin("customer", "password"));
           


            // Display welcome banner
            Console.WriteLine("============================================");
            Console.WriteLine("|     Welcome to Electronic Shopping App   |");
            Console.WriteLine("============================================");
            Console.WriteLine();
            // Main application loop
            do
            {
                try
                {
                //This code is displaying the welcome page and ask
                Console.WriteLine("--------------------------------------------");
                Console.WriteLine("|  1. | Please Login as Customer           |");
                Console.WriteLine("|  2. | Please Login as Staff              |");
                Console.WriteLine("| 99. | Exit                               |");
                Console.WriteLine("--------------------------------------------");
                Console.WriteLine();
                Console.Write("Enter your choice: ");
                int choice;
                string input = Console.ReadLine() ?? string.Empty;
                while (!int.TryParse(input.Trim(), out choice))
                {
                    Console.WriteLine("Invalid input. Please enter a number:");
                    input = Console.ReadLine() ?? string.Empty;
                }

                // Handle user menu selection
                switch (choice)
                {
                    // Customer Menu
                    case 1:

                        // Customer submenu options
                        Console.WriteLine("Welcome to Customer Login!");
                        Console.WriteLine("Please select option 2 to Create an account if you don't have one yet.");
                        Console.WriteLine();
                        Console.WriteLine("|          Please select your option.      |");
                        Console.WriteLine("--------------------------------------------");
                        Console.WriteLine("| 1. | Login to your account               |");
                        Console.WriteLine("| 2. | Signup to the App                   |");
                        Console.WriteLine("| n. | To go back to previous menu         |");
                        Console.WriteLine("--------------------------------------------");
                        Console.WriteLine();
                        Console.Write("Please enter your choice: ");
                        string custInput = Console.ReadLine() ?? string.Empty;
                        if (custInput.Trim().ToLower() == "n")
                        {
                            break;
                        }

                        if (!int.TryParse(custInput.Trim(), out int customerChoice))
                        {
                            Console.WriteLine("Invalid choice.");
                            break;
                        }

                        switch (customerChoice)
                        {
                            // Customer Login
                            case 1:
                                // Process customer login, here we pass the custmerList in the argument to get the existing customer account and his credential
                                CustomerMenu.Login(customerList);
                                break;

                            // Customer Signup
                            case 2:
                                UserLogin? newUser = UserLogin.Signup();
                                if (newUser == null)
                                {
                                    break;
                                }
                                customerList.Add(newUser);
                                CustomerMenu.Login(customerList);
                                break;
                            default:
                            //This code displays an error message if the user enters an invalid choice in the customer
                                Console.WriteLine("Invalid choice.");
                                break;
                        }
                        break;
                    // =============================================================
                    // >>>>>>>>>>>>>>>>>>>>>>>>> STAFF LOGIN SECTION <<<<<<<<<<<<<<<<<<<<<<<<<
                    // Staff Login section: this branch handles staff access and routes into the admin staff menu
                    // >>>>>>>>>>>>>>>>>>>>>>>>> STAFF LOGIN SECTION <<<<<<<<<<<<<<<<<<<<<<<<<
                    // =============================================================
                    case 2:
                        // Access staff login menu
                        Console.WriteLine();
                        Console.WriteLine("|            Welcome to Staff Login!       |");
                        Console.WriteLine("--------------------------------------------");
                        Console.WriteLine("Please enter your credentials to access the \nAdmin Stock for Inventory Menu.");
                        StaffMenu.StaffLogin();

                        break;

                        // =============================================================
                        // >>>>>>>>>>>>>>>>>>>>>>>>> END OF STAFF LOGIN SECTION <<<<<<<<<<<<<<<<<<<<<<
                        // The staff menu branch stops here and returns to the main menu loop.
                        // =============================================================
                        // Exit application
                        case 99:
                        // Close the application
                        Console.WriteLine("GoodBye! You have a good day!");
                        Environment.Exit(0);
                        return;

                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }

                // Ask user if they want to continue using the app
                Console.Write("\nDo you want to continue? (yes/no): ");
                continueChoice = Convert.ToString(Console.ReadLine() ?? "string").ToLower();

                if (continueChoice == "no")
                {
                    Console.WriteLine("GoodBye! You have a good day!");
                    Environment.Exit(0);
                }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                    continueChoice = "yes";
                }

            } while (continueChoice == "yes");

        }//End of Main
    }

}


