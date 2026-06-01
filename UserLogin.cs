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
        try
        {
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
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }

    // Allows new users to create an account and returns the new user object
    public static UserLogin Signup()
    {
        Console.WriteLine();
        Console.WriteLine("-----------------Create an Account------------------");
        Console.WriteLine("----------------------------------------------------");
        Console.WriteLine();
        // Get new username from user
        try
        {
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
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
            return null;
        }
    }

    public static void StaffMenu()
    {
        int adminCh;
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
                    // Code to add new product by type first
                    try
                    {
                    Console.WriteLine();
                    Console.WriteLine("---------------Add New Product---------------");
                    Console.WriteLine("---------------------------------------------");
                    Console.WriteLine();
                    Console.WriteLine("Select product type by entering the corresponding number:");
                    Console.WriteLine();
                    Console.WriteLine("----------------------------------------------");
                    Console.WriteLine("| 1. | TV                                    |");
                    Console.WriteLine("| 2. | Smartphone                            |");
                    Console.WriteLine("| 3. | Laptop                                |");
                    Console.WriteLine("----------------------------------------------");
                    Console.WriteLine();
                    Console.Write("Enter your choice: ");
                    string typeInput = Console.ReadLine() ?? string.Empty;

                    if (!int.TryParse(typeInput, out int typeChoice))
                    {
                        Console.WriteLine("Invalid type selection.");
                        break;
                    }

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

                    Product newProduct;

                    switch (typeChoice)
                    {
                        case 1:
                            Console.Write("Enter screen resolution: ");
                            string screenResolution = Console.ReadLine() ?? string.Empty;
                            Console.Write("Enter screen size (in inches): ");
                            if (!double.TryParse(Console.ReadLine(), out double screenSize))
                            {
                                Console.WriteLine("Invalid screen size.");
                                break;
                            }
                            newProduct = new Tv(productId, productName, productBrand, productPrice, productInventory, "TV", screenResolution, screenSize);
                            productList.Add(newProduct);
                            Console.WriteLine("TV product added successfully!");
                            break;
                        case 2:
                            Console.Write("Enter camera details: ");
                            string cameraMp = Console.ReadLine() ?? string.Empty;
                            Console.Write("Enter operating system version: ");
                            if (!double.TryParse(Console.ReadLine(), out double operatingSystem))
                            {
                                Console.WriteLine("Invalid operating system version.");
                                break;
                            }
                            newProduct = new Smartphone(productId, productName, productBrand, productPrice, productInventory, "Smartphone", cameraMp, operatingSystem);
                            productList.Add(newProduct);
                            Console.WriteLine("Smartphone product added successfully!");
                            break;
                        case 3:
                            Console.Write("Enter RAM (GB): ");
                            if (!int.TryParse(Console.ReadLine(), out int laptopRam))
                            {
                                Console.WriteLine("Invalid RAM value.");
                                break;
                            }
                            Console.Write("Enter storage (GB): ");
                            if (!int.TryParse(Console.ReadLine(), out int storage))
                            {
                                Console.WriteLine("Invalid storage value.");
                                break;
                            }
                            Console.Write("Enter processor model: ");
                            string processor = Console.ReadLine() ?? string.Empty;
                            Console.Write("Enter laptop display size (in inches): ");
                            if (!double.TryParse(Console.ReadLine(), out double size))
                            {
                                Console.WriteLine("Invalid laptop size.");
                                break;
                            }
                            newProduct = new Laptop(productId, productName, productBrand, productPrice, productInventory, "Laptop", laptopRam, storage, processor, size);
                            productList.Add(newProduct);
                            Console.WriteLine("Laptop product added successfully!");
                            break;
                        default:
                            Console.WriteLine("Invalid type selection.");
                            break;
                    }
                        break;
                    }
                    catch (Exception ex)                    {
                        Console.WriteLine($"An error occurred: {ex.Message}");
                        break;
                    }

                case 2:
                    // Code to remove product
                    Console.WriteLine();
                    Console.WriteLine("-------------------Remove Product-------------------");
                    Console.WriteLine("----------------------------------------------------");
                    Console.WriteLine();
                    Console.Write("Enter the product name to remove: ");
                    try
                    {
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
                    }
                    catch (Exception ex)                    {
                        Console.WriteLine($"An error occurred: {ex.Message}");
                        break;
                    }
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
                    Console.WriteLine();
                    Product foundProduct = Product.SearchProduct(productList, "string");
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
