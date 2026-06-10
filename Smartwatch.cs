namespace eleShoppingApp;

public class Smartwatch : Product
{
//Fields
private bool waterproof;
    private bool hasHeartRateMonitor;

//Properties
public bool Waterproof { get{ return waterproof; } set { waterproof = value; } }
public bool HasHeartRateMonitor { get { return hasHeartRateMonitor; } set { hasHeartRateMonitor = value; } }

    //Constructor     
    public Smartwatch(int id, string name, string brand, double price, int inventory, bool waterproof, bool hasHeartRateMonitor)
    : base(id, name, brand, price, inventory, "Smartwatch")
    {
        Waterproof = waterproof;
        HasHeartRateMonitor = hasHeartRateMonitor;
    }
 
//Method: Display smartwatch information
    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine($" Waterproof: \t{Waterproof} \n Heart Rate Monitor: \t{HasHeartRateMonitor}");
    }
}//End of Smartwatch class
//End of namespace

