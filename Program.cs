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
        static void Main(string[] args)
        {
            string continueChoice;
            List<UserLogin> customerList = new List<UserLogin>();
            customerList.Add(new UserLogin("customer", "password"));

            // Display welcome banner
            Console.WriteLine("===================================");
            Console.WriteLine(" Welcome to Electronic Shopping App ");
            Console.WriteLine("===================================");
            Console.WriteLine();
            // Main application loop
            do
            {
                //This code is displaying the welcome page and ask
                Console.WriteLine("Please select your option:");
                Console.WriteLine("1. Login as Customer");
                Console.WriteLine("2. Login as Staff");
                Console.WriteLine("3. Exit");
                Console.WriteLine();
                Console.Write("Enter your choice: ");

                int choice = Convert.ToInt32(Console.ReadLine());

                // Handle user menu selection
                switch (choice)
                {
                    // Customer Menu
                    case 1:

                        // Customer submenu options
                        Console.WriteLine("\n1. Login to your account");
                        Console.WriteLine("2. Signup to the App");
                        Console.Write("Please enter your choice: ");
                        int customerChoice = Convert.ToInt32(Console.ReadLine());

                        switch (customerChoice)
                        {
                            // Customer Login
                            case 1:
                                // Process customer login, here we pass the custmerList in the argument to get the existing customer account and his credential
                                UserLogin.Login(customerList);
                                break;

                            // Customer Signup
                            case 2:
                                // Create new object New User which will hold the new user's account information and then add the new user to the customer list, here we call the Signup method to get the new user's account information and then we add it to the customer list, after that we call the Login method to allow the new user to log in immediately after signing up
                                UserLogin newUser = UserLogin.Signup();
                                customerList.Add(newUser);
                                // Log in with the new user after signup, here we pass the customerList to the Login method to allow the new user to log in immediately after signing up
                                UserLogin.Login(customerList);
                                break;
                            default:
                            //This code displays an error message if the user enters an invalid choice in the customer
                                Console.WriteLine("Invalid choice.");
                                break;
                        }
                        break;

                    // Staff Login
                    case 2:
                        Console.WriteLine();
                        // Access staff login menu
                        UserLogin.StaffLogin();

                        break;

                    // Exit application
                    case 3:
                        // Close the application
                        Environment.Exit(0);
                        return;

                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }

                // Ask user if they want to continue using the app
                Console.Write("\nDo you want to continue? (yes/no): ");
                continueChoice = Convert.ToString(Console.ReadLine() ?? "string").ToLower();

            } while (continueChoice == "yes");

            Console.WriteLine("GoodBye! You have a good day!");
        }//End of Main
    }
}

