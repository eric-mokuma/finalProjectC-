namespace eleShoppingApp;


public class UserLogin
{
    // Shared inventory list for all products managed by staff.
    static readonly List<Product> productList = new List<Product>();
    public static List<Product> Products => productList;

    // Private fields to store user credentials.
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

    // Authenticates a customer by username and password.
    // Returns true once the user is successfully authenticated.
    public static bool Login(List<UserLogin> users)
    {
        bool isAuthenticated = false;

        do
        {
            Console.WriteLine();
            Console.WriteLine("|          Customer Login          |");
            Console.WriteLine("====================================");
            Console.WriteLine();
            Console.Write("Enter your Username: ");
            string user = Convert.ToString(Console.ReadLine() ?? string.Empty);

            Console.Write("Enter your Password: ");
            string pass = Convert.ToString(Console.ReadLine() ?? string.Empty);

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

        return true;
    }

    // Authenticates staff members using hardcoded admin credentials.
    // On success it enters the staff inventory menu.
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

    // Allows new users to create an account and returns the new user object.
    // Returns null if account creation fails.
    public static UserLogin? Signup()
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
            // Inventory menu loop for staff.
            // Allows staff to add, remove, display, or search products.
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
                return;
            }

            if (!int.TryParse(input, out adminCh))
            {
                Console.WriteLine("Invalid input.");
                continue;
            }

            switch (adminCh)
            {
                case 1:
                    // Add or restock a product.
                    // If the product already exists, update only the quantity.
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
                            Product? existingTv = productList.Find(p => string.Equals(p.ProductName, productName, StringComparison.OrdinalIgnoreCase) && string.Equals(p.ProductType, "TV", StringComparison.OrdinalIgnoreCase));
                            if (existingTv != null)
                            {
                                existingTv.ChangeQuantity(productInventory);
                                Console.WriteLine($"TV product already exists. Updated quantity to {existingTv.ProductQuantity}.");
                            }
                            else
                            {
                                newProduct = new Tv(productId, productName, productBrand, productPrice, productInventory, "TV", screenResolution, screenSize);
                                productList.Add(newProduct);
                                Console.WriteLine("TV product added successfully!");
                            }
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
                            Product? existingPhone = productList.Find(p => string.Equals(p.ProductName, productName, StringComparison.OrdinalIgnoreCase) && string.Equals(p.ProductType, "Smartphone", StringComparison.OrdinalIgnoreCase));
                            if (existingPhone != null)
                            {
                                existingPhone.ChangeQuantity(productInventory);
                                Console.WriteLine($"Smartphone product already exists. Updated quantity to {existingPhone.ProductQuantity}.");
                            }
                            else
                            {
                                newProduct = new Smartphone(productId, productName, productBrand, productPrice, productInventory, "Smartphone", cameraMp, operatingSystem);
                                productList.Add(newProduct);
                                Console.WriteLine("Smartphone product added successfully!");
                            }
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
                            Product? existingLaptop = productList.Find(p => string.Equals(p.ProductName, productName, StringComparison.OrdinalIgnoreCase) && string.Equals(p.ProductType, "Laptop", StringComparison.OrdinalIgnoreCase));
                            if (existingLaptop != null)
                            {
                                existingLaptop.ChangeQuantity(productInventory);
                                Console.WriteLine($"Laptop product already exists. Updated quantity to {existingLaptop.ProductQuantity}.");
                            }
                            else
                            {
                                newProduct = new Laptop(productId, productName, productBrand, productPrice, productInventory, "Laptop", laptopRam, storage, processor, size);
                                productList.Add(newProduct);
                                Console.WriteLine("Laptop product added successfully!");
                            }
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
                    // Remove inventory quantity from an existing product.
                    // If quantity reaches zero, the product is removed entirely.
                    Console.WriteLine();
                    Console.WriteLine("-------------------Remove Product-------------------");
                    Console.WriteLine("----------------------------------------------------");
                    Console.WriteLine();
                    Console.Write("Enter the product name to remove: ");
                    try
                    {
                    string productNameToRemove = Console.ReadLine() ?? string.Empty;
                    Product? prodToRemove = productList.Find(p => string.Equals(p.ProductName, productNameToRemove, StringComparison.OrdinalIgnoreCase));

                    if (!string.IsNullOrWhiteSpace(productNameToRemove) && prodToRemove != null)
                    {
                        Console.Write("Enter quantity to remove: ");
                        if (!int.TryParse(Console.ReadLine(), out int removeQuantity) || removeQuantity <= 0)
                        {
                            Console.WriteLine("Invalid quantity.");
                            break;
                        }

                        if (prodToRemove.ChangeQuantity(-removeQuantity))
                        {
                            if (prodToRemove.ProductQuantity == 0)
                            {
                                productList.Remove(prodToRemove);
                                Console.WriteLine($"{productNameToRemove} removed from inventory.");
                            }
                            else
                            {
                                Console.WriteLine($"Removed {removeQuantity} from {productNameToRemove}. Remaining quantity: {prodToRemove.ProductQuantity}.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Not enough quantity to remove.");
                        }
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
                    // Display all products currently in inventory.
                    foreach (Product product in productList)
                    {
                        product.DisplayInfo();
                    }
                    break;
                case 4:
                    // Search for a product by name in the current inventory.
                    Console.WriteLine();
                    Console.WriteLine("-------------------Search Product-------------------");
                    Console.WriteLine("----------------------------------------------------");
                    Console.WriteLine();
                    Product? foundProduct = Product.SearchProduct(productList, "string");
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
