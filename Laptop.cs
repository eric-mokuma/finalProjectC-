namespace eleShoppingApp;

public class Laptop:Product
{
    // List Fiels
    private int laptopRam;
    private int storage;
    private string processor = string.Empty;
    private double size;

    // List Properties
    public int LaptopRAM { get { return laptopRam; } set { laptopRam = value; } }
    public int Storage { get { return storage; } set { storage = value; } }
    public string Processor { get { return processor; } set { processor = value; } }
    public double Size { get { return size; } set { size = value; } }

    // List Constructor
    public Laptop(int prodID,
        string name,
        string brand,
        double price,
        int stock,
        string category,
        int laptopRam,
        int storage,
        string processor,
        double size
    ) : base(prodID, name, brand, price, stock, category)
    {
        LaptopRAM = laptopRam;
        Storage = storage;
        Processor = processor;
        Size = size;
    }

    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine($" RAM: \t{LaptopRAM}GB \n Storage: \t{Storage}GB \n Processor: \t{Processor} \n Size: \t{Size} inches");
    }
}
