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
        // Main entry point for the application
        static void Main(string[] args)
        {
            string continueChoice = "yes";
            string backChoice = "";
             int choice;
            List<UserLogin> customerList = new();

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

                    // Handle user menu selection
                    try
                    {
                        switch (choice)
                        {
                            // Customer Menu
                            case 1:
                                ShowCustomerMenu(customerList);
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

                        // This code is asking the user to press 'n' to go back to the main menu in case they want to go back to the main menu.
                        Console.WriteLine("Please press 'n' to go back to the main menu...");
                        backChoice = Console.ReadKey().KeyChar.ToString().ToLower();
                        if (backChoice == "n")
                        {
                            Console.WriteLine();
                            Console.WriteLine("Returning to the main menu...");
                        }
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


        // This method handles all customer-related options
        static void ShowCustomerMenu(List<UserLogin> customerList)
        {
            // Loop until user chooses to go back
            while (true)
            {
                int choice;
                // Display customer menu options
                Console.WriteLine("\nCustomer Menu:");
                Console.WriteLine("1. Login");
                Console.WriteLine("2. Signup");
                Console.WriteLine("Press 'n' to go back to Main Menu");
                Console.Write("Enter your choice: ");

                // Read user input
                string input = Convert.ToString(Console.ReadLine() ?? "string").ToLower();
                try
                {
                    // If user presses 'n', return to main menu
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
                            UserLogin newUser = UserLogin.Signup();

                            // Add new user to list
                            customerList.Add(newUser);

                            Console.WriteLine("Signup successful! Please login.");

                            // Automatically prompt login after signup
                            UserLogin.Login(customerList);
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
    }

}


