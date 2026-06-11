namespace eleShoppingApp;

public class Smartphone:Product
{
        // List Fiels  
    private string cameraMp = string.Empty;
    private double operatingSystem;

    // List Properties
    public string CameraMp1 { get { return cameraMp; } set { cameraMp = value; } }
    public double OperatingSystem1 { get { return operatingSystem; } set { operatingSystem = value; } }

    // List Constructor
    public Smartphone(
        int prodID,
        string name,
        string brand,
        double price,
        int stock,
        string category,
        string cameraMp,
        double operatingSystem
    ) : base(prodID, name, brand, price, stock, category)
    {
        CameraMp1 = cameraMp;
        OperatingSystem1 = operatingSystem;
    }

    public override string ProductDescription =>
        $"Camera: {CameraMp1}, Operating System: {OperatingSystem1}";

    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine($" Camera: \t{CameraMp1} \n Operating System: \t{OperatingSystem1}");
    }
}
