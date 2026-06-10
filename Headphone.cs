namespace eleShoppingApp;

public class Headphone : Product
{
    // List Fields
    private bool isWireless;
    private bool isNoiseCancelling;

    // List Properties
    public bool IsWireless { get { return isWireless; } set { isWireless = value; } }
    public bool IsNoiseCancelling { get { return isNoiseCancelling; } set { isNoiseCancelling = value; } }

    // List Constructor
    public Headphone(int id, string name, string brand, double price, int inventory, string category, bool isWireless, bool isNoiseCancelling)
        : base(id, name, brand, price, inventory, category)
    {
        IsWireless = isWireless;
        IsNoiseCancelling = isNoiseCancelling;
    }
   
    //Method: Display headphone information
    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine($" Wireless: \t{IsWireless} \n Noise Cancelling: \t{IsNoiseCancelling}");
    }
}//End of Headphone class

