namespace eleShoppingApp;

public class StaffMenu
{
    // Staff Login: this part handles staff authentication with hardcoded admin credentials and allows retry
    public static void StaffLogin()
    {
        bool isAuthenticated = false;

        do
        {
            Console.WriteLine();
            Console.WriteLine("------------------Staff Login-----------------");
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("| n. | To go back to previous menu           |");
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine();
            Console.Write("Enter Staff Username (or n to go back): ");
            string staffUser = Console.ReadLine() ?? string.Empty;
            if (staffUser.Trim().ToLower() == "n")
            {
                Console.WriteLine("Returning to the previous menu...");
                return;
            }

            Console.Write("Enter Staff Password: ");
            string staffPass = Console.ReadLine() ?? string.Empty;

            if (staffUser == "admin" && staffPass == "admin")
            {
                ShowMenu();
                isAuthenticated = true;
            }
            else
            {
                Console.WriteLine("Invalid login, please try again.");
            }
        } while (!isAuthenticated);
    }

    // Inventory menu loop for staff.
    // Allows staff to add, remove, display, or search products.
    public static void ShowMenu()
    {
        List<Product> productList = Program.ProductInventory;

        do
        {
            Console.WriteLine();
            Console.WriteLine("-----------Admin stock for Inventory Menu-----------");
            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine("| 1. | Add New product                             |");
            Console.WriteLine("| 2. | Remove product                              |");
            Console.WriteLine("| 3. | Display Products                            |");
            Console.WriteLine("| 4. | Search Product                              |");
            Console.WriteLine("| n. | To go back to previous menu                 |");
            Console.WriteLine("|____|_____________________________________________|");
            Console.WriteLine();
            
            Console.Write("Your choice: ");

            string input = Console.ReadLine() ?? string.Empty;
            if (input.Trim().ToLower() == "n")
            {
                Console.WriteLine("Returning to the previous menu...");
                return;
            }

            if (!int.TryParse(input, out int adminCh))
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
                        Console.WriteLine("| 4. | Tablet                                |");
                        Console.WriteLine("| 5. | Headphones                            |");
                        Console.WriteLine("| 6. | Smartwatch                            |");
                        Console.WriteLine("| n. | To go back to previous menu           |");
                        Console.WriteLine("|____|_______________________________________|");
                        Console.WriteLine();
                        Console.Write("Enter your choice: ");
                        string typeInput = Console.ReadLine() ?? string.Empty;

                        if (typeInput.Trim().ToLower() == "n")
                        {
                            Console.WriteLine("Returning to the previous menu...");
                            break;
                        }

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

                        Console.Write("Enter product quantity: ");
                        if (!int.TryParse(Console.ReadLine(), out int productQuantity))
                        {
                            Console.WriteLine("Invalid quantity.");
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
                                    existingTv.ChangeQuantity(productQuantity);
                                    Console.WriteLine($"TV product already exists. Updated quantity to {existingTv.ProductQuantity}.");
                                }
                                else
                                {
                                    newProduct = new TV(productId, productName, productBrand, productPrice, productQuantity, "TV", screenResolution, screenSize);
                                    productList.Add(newProduct);
                                    Console.WriteLine();
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
                                    existingPhone.ChangeQuantity(productQuantity);
                                    Console.WriteLine($"Smartphone product already exists. Updated quantity to {existingPhone.ProductQuantity}.");
                                }
                                else
                                {
                                    newProduct = new Smartphone(productId, productName, productBrand, productPrice, productQuantity, "Smartphone", cameraMp, operatingSystem);
                                    productList.Add(newProduct);
                                    Console.WriteLine();
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
                                Console.Write("Enter stock quantity: ");
                                if (!int.TryParse(Console.ReadLine(), out int stock))
                                {
                                    Console.WriteLine("Invalid stock value.");
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
                                   
                                    existingLaptop.ChangeQuantity(productQuantity);
                                    Console.WriteLine($"Laptop product already exists. Updated quantity to {existingLaptop.ProductQuantity}.");
                                }
                                else
                                {
                                    newProduct = new Laptop(productId, productName, productBrand, productPrice, productQuantity, "Laptop", laptopRam, storage, processor, size);
                                    productList.Add(newProduct);
                                    Console.WriteLine();
                                    Console.WriteLine("Laptop product added successfully!");
                                }
                                break;
                            case 4:
                                Console.Write("Enter tablet display size (in inches): ");
                                if (!double.TryParse(Console.ReadLine(), out double tabletSize))
                                {
                                    Console.WriteLine("Invalid tablet size.");
                                    break;
                                }
                                Product? existingTablet = productList.Find(p => string.Equals(p.ProductName, productName, StringComparison.OrdinalIgnoreCase) && string.Equals(p.ProductType, "Tablet", StringComparison.OrdinalIgnoreCase));
                                if (existingTablet != null)
                                {
                                    existingTablet.ChangeQuantity(productQuantity);
                                    Console.WriteLine($"Tablet product already exists. Updated quantity to {existingTablet.ProductQuantity}.");
                                }
                                else
                                {
                                    newProduct = new Tablet(productId, productName, productBrand, productPrice, productQuantity, "Tablet", tabletSize, 0);
                                    productList.Add(newProduct);
                                    Console.WriteLine();
                                    Console.WriteLine("Tablet product added successfully!");
                                }
                                break;
                            case 5:
                                Console.Write("Enter headphone type (e.g., over-ear, in-ear): ");
                                string headphoneType = Console.ReadLine() ?? string.Empty;
                                Product? existingHeadphones = productList.Find(p => string.Equals(p.ProductName, productName, StringComparison.OrdinalIgnoreCase) && string.Equals(p.ProductType, "Headphones", StringComparison.OrdinalIgnoreCase));
                                if (existingHeadphones != null)
                                {
                                    existingHeadphones.ChangeQuantity(productQuantity);
                                    Console.WriteLine($"Headphones product already exists. Updated quantity to {existingHeadphones.ProductQuantity}.");
                                }
                                else
                                {
                                    newProduct = new Headphone(productId, productName, productBrand, productPrice, productQuantity, "Headphones",
                                        headphoneType.Equals("wireless", StringComparison.OrdinalIgnoreCase),
                                        headphoneType.Equals("noise-cancelling", StringComparison.OrdinalIgnoreCase));
                                    productList.Add(newProduct);
                                    Console.WriteLine();
                                    Console.WriteLine("Headphones product added successfully!");
                                }
                                break;
                            case 6:
                                Console.Write("Enter smartwatch display size (in inches): ");
                                if (!double.TryParse(Console.ReadLine(), out double watchSize))
                                {
                                    Console.WriteLine("Invalid smartwatch size.");
                                    break;
                                }
                                Console.Write("Enter smartwatch type (e.g., waterproof, heart-rate-monitor): ");
                                string smartwatchType = Console.ReadLine() ?? string.Empty;
                                Product? existingWatch = productList.Find(p => string.Equals(p.ProductName, productName, StringComparison.OrdinalIgnoreCase) && string.Equals(p.ProductType, "Smartwatch", StringComparison.OrdinalIgnoreCase));
                                if (existingWatch != null)
                                {
                                    existingWatch.ChangeQuantity(productQuantity);
                                    Console.WriteLine($"Smartwatch product already exists. Updated quantity to {existingWatch.ProductQuantity}.");
                                }
                                else
                                {
                                    newProduct = new Smartwatch(productId, productName, productBrand, productPrice, productQuantity,
                                        smartwatchType.Equals("waterproof", StringComparison.OrdinalIgnoreCase),
                                        smartwatchType.Equals("heart-rate-monitor", StringComparison.OrdinalIgnoreCase));
                                    productList.Add(newProduct);
                                    Console.WriteLine();
                                    Console.WriteLine("Smartwatch product added successfully!");
                                }
                                break;
                            
                            default:
                                Console.WriteLine("Invalid type selection.");
                                break;
                        }
                        break;
                    }
                    catch (Exception ex)
                    {
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
                    catch (Exception ex)
                    {
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
