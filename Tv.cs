namespace eleShoppingApp;

public class TV:Product
{
    // List Fields 
    private string screenResolution;
    private double screenSize;

    // List Properties
    public string ScreenResolution1 { get { return screenResolution; } set { screenResolution = value; } }
    public double ScreenSize1 { get { return screenSize; } set { screenSize = value; } }

    // List Constructor
    // List Constructor
    public TV(int prodID,
        string name,
        string brand,
        double price,
        int stock,
        string category,
        string screenRes,
        double screenSz
    ) : base(prodID, name, brand, price, stock, category)
    {
        screenResolution = screenRes;
        screenSize = screenSz;
    }

    //Display TV information
    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine($" Screen Resolution: \t{ScreenResolution1} \n Screen Size: \t{ScreenSize1} inches");
    }

}