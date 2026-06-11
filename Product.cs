namespace eleShoppingApp;


//Represents a generic product in the electronic shopping app.
//Contains inventory, pricing, and purchase-tracking behavior.

public class Product
{
    // Product identity fields
    private int productID;
    private string productName = string.Empty;
    private string productBrand = string.Empty;
    private double productPrice;

    // Inventory tracking fields
    private int productQuantity;
    private string productType = string.Empty;
    private int numberOfPurchase;

    // Exposed properties for each field
    public int ProductID { get { return productID; } set { productID = value; } }
    public string ProductName { get { return productName; } set { productName = value; } }
    public string ProductBrand { get { return productBrand; } set { productBrand = value; } }
    public double ProductPrice { get { return productPrice; } set { productPrice = value; } }
    public int ProductQuantity { get { return productQuantity; } set { productQuantity = value; } }
    public string ProductType { get { return productType; } set { productType = value; } }
    public int NumberOfPurchase { get { return numberOfPurchase; } set { numberOfPurchase = value; } }

    // Constructor initializes required product data.
    public Product(int prodID, string prodName, string prodBrand, double prodPrice, int prodQuantity, string prodType)
    {
        ProductID = prodID;
        ProductName = prodName;
        ProductBrand = prodBrand;
        ProductPrice = prodPrice;
        ProductQuantity = prodQuantity;
        ProductType = prodType;
    }

    // Returns type-specific details; overridden in child product classes.
    public virtual string ProductDescription => string.Empty;

    //Writes all visible product details to the console.
    public virtual void DisplayInfo()
    {
        Console.WriteLine($"\n Product ID: \t{ProductID} \n Product Name: \t{ProductName} \n Product Brand: \t{ProductBrand} \n Product Price: \t{ProductPrice} \n Product Quantity: \t{ProductQuantity}  \n Number of Purchases: \t{NumberOfPurchase}");
    }

   
    //Overwrites the current inventory quantity.

    public void UpdateProduct(int newQuantity)
    {
        ProductQuantity = newQuantity;
    }


    //Adds or removes quantity from inventory.
    //Returns false when the change would make inventory negative.

    public bool ChangeQuantity(int delta)
    {
        if (ProductQuantity + delta < 0)
        {
            return false;
        }

        ProductQuantity += delta;
        return true;
    }

    //Attempts to purchase the specified quantity.
    //Decrements stock and increments the purchase count.
    public bool Purchase(int quantity)
    {
        if (quantity <= 0)
        {
            return false;
        }

        if (ProductQuantity < quantity)
        {
            return false;
        }

        ProductQuantity -= quantity;
        NumberOfPurchase += quantity;
        return true;
    }

    //Searches the product list by name.
    //If searchTerm is null or empty, prompts the user for a value.
    public static Product? SearchProduct(List<Product> products, string? searchTerm = null)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                Console.Write("Please enter the product name you want to search for: ");
                searchTerm = Convert.ToString(Console.ReadLine() ?? string.Empty);
            }

            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                return null;
            }

            foreach (Product product in products)
            {
                if (product.ProductName.Contains(searchTerm, StringComparison.OrdinalIgnoreCase))
                {
                    return product;
                }
            }
            return null;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
            return null;
        }
    }
}
