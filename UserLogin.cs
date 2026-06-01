namespace eleShoppingApp;


public class UserLogin
{
    static readonly List<Product> productList = new List<Product>();
    // Private fields to store user credentials
    private string username = "";
    private string password = "";

    // Property for username with validation
    public string Username
    {
        get { return username; }
        set
        {
            if (!string.IsNullOrEmpty(value))
            {
                username = value;
            }
            else
            {
                Console.WriteLine("Username cannot be empty!");
            }
        }
    }

    // Property for password with validation
    public string Password
    {
        get { return password; }
        set
        {
            if (!string.IsNullOrEmpty(value))
            {
                password = value;
            }
            else
            {
                Console.WriteLine("Password cannot be empty!");
            }
        }
    }

    // Constructor to initialize a user with username and password
    public UserLogin(string username, string password)
    {
        Username = username;
        Password = password;
    }

    // Authenticates user by comparing entered credentials against saved users
    public static void Login(List<UserLogin> users)
    {
        bool isAuthenticated = false;

        do
        {
            Console.WriteLine();
            Console.WriteLine("|          Customer Login          |");
            Console.WriteLine("====================================");
            Console.WriteLine();
            Console.Write("Enter your Username: ");
            string user = Convert.ToString(Console.ReadLine() ?? "string");

            Console.Write("Enter your Password: ");
            string pass = Convert.ToString(Console.ReadLine() ?? "string");

            foreach (UserLogin existingUser in users)
            {
                if (existingUser.Username == user && existingUser.Password == pass)
                {
                    Console.WriteLine();
                    Console.WriteLine("Customer login successful!");
                    isAuthenticated = true;
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

    // Authenticates staff members with hardcoded admin credentials and allows retry
    public static void StaffLogin()
    {
        bool isAuthenticated = false;

        do
        {
            Console.WriteLine("-------------------Staff Login------------------");
            Console.WriteLine("------------------------------------------------");
            Console.Write("Enter Staff Username: ");
            string staffUser = Convert.ToString(Console.ReadLine() ?? "string");

            Console.Write("Enter Staff Password: ");
            string staffPass = Convert.ToString(Console.ReadLine() ?? "string");

            if (staffUser == "admin" && staffPass == "admin")
            {
                StaffMenu();
                isAuthenticated = true;
            }
            else
            {
                Console.WriteLine("Invalid login, please try again.");
            }
        } while (!isAuthenticated);
    }

    // Allows new users to create an account and returns the new user object
    public static UserLogin Signup()
    {
        Console.WriteLine();
        Console.WriteLine("-----------------Create an Account------------------");
        Console.WriteLine("----------------------------------------------------");
        Console.WriteLine();
        // Get new username from user
        Console.Write("Please create a Username: ");
        string newUser = Convert.ToString(Console.ReadLine() ?? "string");
        Console.WriteLine();
        // Get new password from user
        Console.Write("Please create a Password: ");
        string newPass = Convert.ToString(Console.ReadLine() ?? "string");
        Console.WriteLine();
        Console.WriteLine("Your account has been created successfully!");
        return new UserLogin(newUser, newPass);
    }

    public static void StaffMenu()
    {
        int adminCh = 0;
        do
        {
            // This method can be implemented in the future to handle staff-related tasks
            Console.WriteLine();
            Console.WriteLine("-----------Admin stock for Inventory Menu-----------");
            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine("| 1. | Add New product                             |");
            Console.WriteLine("| 2. | Remove product                              |");
            Console.WriteLine("| 3. | Display Products                            |");
            Console.WriteLine("| 4. | Search Product                              |");
            Console.WriteLine("|____|_____________________________________________|");
            Console.WriteLine();
            Console.WriteLine("Enter your choice or press 'n' to go back to the main menu...");

            string input = Console.ReadLine() ?? string.Empty;
            if (input.Trim().ToLower() == "n")
            {
                Console.WriteLine("Returning to the main menu...");
                break;
            }

            if (!int.TryParse(input, out adminCh))
            {
                Console.WriteLine("Invalid input.");
                continue;
            }

            switch (adminCh)
            {
                case 1:
                    // Code to add new product
                    Console.Write("Enter product ID: ");
                    string productIdInput = Console.ReadLine() ?? string.Empty;
                    if (!int.TryParse(productIdInput, out int productId))
                    {
                        Console.WriteLine("Invalid product ID.");
                        break;
                    }

                    Console.Write("Enter product name: ");
                    string productName = Console.ReadLine() ?? string.Empty;
                    Console.Write("Enter product brand: ");
                    string productBrand = Console.ReadLine() ?? string.Empty;

                    Console.Write("Enter product price: ");
                    if (!double.TryParse(Console.ReadLine(), out double productPrice))
                    {
                        Console.WriteLine("Invalid price.");
                        break;
                    }

                    Console.Write("Enter product inventory: ");
                    if (!int.TryParse(Console.ReadLine(), out int productInventory))
                    {
                        Console.WriteLine("Invalid inventory count.");
                        break;
                    }

                    Console.Write("Enter product type: ");
                    string productType = Console.ReadLine() ?? string.Empty;

                    Product newProduct = new(productId, productName, productBrand, productPrice, productInventory, productType);

                    productList.Add(newProduct);
                    Console.WriteLine("Product added successfully!");
                    break;

                case 2:
                    // Code to remove product
                    Console.WriteLine();
                    Console.WriteLine("-------------------Remove Product-------------------");
                    Console.WriteLine("----------------------------------------------------");
                    Console.Write("Enter the product name to remove: ");
                    string productNameToRemove = Console.ReadLine() ?? string.Empty;
                    Product prodToRemove = productList.Find(p => string.Equals(p.ProductName, productNameToRemove, StringComparison.OrdinalIgnoreCase));

                    if (!string.IsNullOrWhiteSpace(productNameToRemove) && prodToRemove != null)
                    {
                        Console.WriteLine($"{productNameToRemove} found in the list and {productNameToRemove} has been removed");
                        productList.Remove(prodToRemove);
                    }
                    else
                    {
                        Console.WriteLine("Product not found.");
                    }
                    break;
                case 3:
                    // Code to display products
                    foreach (Product product in productList)
                    {
                        product.DisplayInfo();
                    }
                    break;
                case 4:
                    // Code to search product
                    Console.WriteLine();
                    Console.WriteLine("-------------------Search Product-------------------");
                    Console.WriteLine("----------------------------------------------------");
                    Console.Write("Please enter the product name you want to search for: ");
                    string searchTerm = Console.ReadLine() ?? string.Empty;
                    Product foundProduct = Product.SearchProduct(productList, searchTerm);
                    if (foundProduct != null)
                    {
                        foundProduct.DisplayInfo();
                    }
                    else
                    {
                        Console.WriteLine("Product not found.");
                    }
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
        while (true);
    }
}
