namespace eleShoppingApp;


public class UserLogin
{

    // Private fields to store user credentials
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

    // Allows new users to create an account and returns the new user object
    public static UserLogin? Signup()
    {
        Console.WriteLine();
        Console.WriteLine("|          Create Account          |");
        Console.WriteLine("====================================");
        Console.WriteLine("| n. | To go back to previous menu           |");
        Console.WriteLine("====================================");
        Console.WriteLine();
        Console.Write("Please create a Username (or n to go back): ");
        string newUser = Console.ReadLine() ?? string.Empty;
        if (newUser.Trim().ToLower() == "n")
        {
            Console.WriteLine("Returning to the previous menu...");
            return null;
        }

        Console.Write("Please create a Password: ");
        string newPass = Console.ReadLine() ?? string.Empty;
        Console.WriteLine();
        Console.WriteLine("Signup successful!");
        return new UserLogin(newUser, newPass);
    }
}
