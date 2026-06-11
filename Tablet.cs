namespace eleShoppingApp;

public class Tablet : Product
{
    //Fields
    private double screenSize;
    private double batteryLife;

    //Properties
    public double ScreenSize { get{ return screenSize; } set{screenSize = value;} }
    public double BatteryLife { get{ return batteryLife; } set{batteryLife = value;} }

    //Constructor
    public Tablet(int id, string name, string brand, double price, int inventory, string purchase, double screenSize, double batteryLife)
                : base(id, name, brand, price, inventory, purchase)
    {
        ScreenSize = screenSize;
        BatteryLife = batteryLife;
    }
        
    public override string ProductDescription =>
        $"Screen Size: {ScreenSize} inches, Battery Life: {BatteryLife} hours";

    //Method: Display tablet information
    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine($" Screen Size: \t{ScreenSize} inches \n Battery Life: \t{BatteryLife} hours");
    }
}//End of Tablet class


