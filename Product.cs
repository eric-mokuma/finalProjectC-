namespace eleShoppingApp;

public class Product
{
    // List of our product fields
    private int productID;
    private string productName;
    private string productBrand;
    private double productPrice;
    private int productInventory;
    private string productType;
    private int numberOfPurchase;

    // List of our product properties
    public int ProductID { get { return productID; } set { productID = value; } }
    public string ProductName { get { return productName; } set { productName = value; } }
    public string ProductBrand { get { return productBrand; } set { productBrand = value; } }
    public double ProductPrice { get { return productPrice; } set { productPrice = value; } }
    public int ProductInventory { get { return productInventory; } set { productInventory = value; } }
    public string ProductType { get { return productType; } set { productType = value; } }
    public int NumberOfPurchase { get { return numberOfPurchase; } set { numberOfPurchase = value; } }

    // List of our product constructors
    public Product(int prodID, string prodName, string prodBrand, double prodPrice, int prodInventory, string prodType)
    {
        ProductID = prodID;
        ProductName = prodName;
        ProductBrand = prodBrand;
        ProductPrice = prodPrice;
        ProductInventory = prodInventory;
        ProductType = prodType;
    }   

    // Method to display product details
    public virtual void DisplayInfo()
    {
        Console.WriteLine($"\n Product ID: \t{ProductID} \n Product Name: \t{ProductName} \n Product Brand: \t{ProductBrand} \n Product Price: \t{ProductPrice} \n Product Inventory: \t{ProductInventory} \n Product Type: \t{ProductType} \n Number of Purchases: \t{NumberOfPurchase}");
    }

    public void UpdateProduct(int newInventory)
    {
        ProductInventory = newInventory;
    }

    public static Product SearchProduct(List<Product> products, string searchTerm)
    {
        Console.WriteLine($"Please enter the product name you want to search for: ");
        searchTerm = Convert.ToString(Console.ReadLine() ?? "string");

        foreach (Product product in products)
        {
            if (product.ProductName.Contains(searchTerm, StringComparison.OrdinalIgnoreCase))
            {
                return product;
            }
        }
        return null;
    }
}
