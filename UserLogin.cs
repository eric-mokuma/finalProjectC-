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

    // Authenticates user by comparing entered credentials against saved users
    public static void Login(List<UserLogin> users)
    {
        bool isAuthenticated = false;

        do
        {
            Console.WriteLine();
            Console.WriteLine("|          Customer Login          |");
            Console.WriteLine("====================================");
            Console.WriteLine();
            Console.Write("Enter your Username: ");
            string user = Convert.ToString(Console.ReadLine() ?? "string");

            Console.Write("Enter your Password: ");
            string pass = Convert.ToString(Console.ReadLine() ?? "string");

            foreach (UserLogin existingUser in users)
            {
                if (existingUser.Username == user && existingUser.Password == pass)
                {
                    Console.WriteLine();
                    Console.WriteLine("Customer login successful!");
                    isAuthenticated = true;
                    break;
                }
            }

            if (!isAuthenticated)
            {
                Console.WriteLine();
                Console.WriteLine("Invalid login, please try again.");
            }
        } while (!isAuthenticated);
    }

    // Authenticates staff members with hardcoded admin credentials and allows retry
    public static void StaffLogin()
    {
        bool isAuthenticated = false;

        do
        {
            Console.Write("Enter Staff Username: ");
            string staffUser = Convert.ToString(Console.ReadLine() ?? "string");

            Console.Write("Enter Staff Password: ");
            string staffPass = Convert.ToString(Console.ReadLine() ?? "string");

            if (staffUser == "admin" && staffPass == "admin")
            {
                Console.WriteLine("Staff login successful!");
                isAuthenticated = true;
            }
            else
            {
                Console.WriteLine("Invalid login, please try again.");
            }
        } while (!isAuthenticated);
    }

    // Allows new users to create an account and returns the new user object
    public static UserLogin Signup()
    {
        Console.WriteLine();
        Console.WriteLine("|          Create Account          |");
        Console.WriteLine("====================================");
        Console.WriteLine();
        // Get new username from user
        Console.Write("Please create a Username: ");
        string newUser = Convert.ToString(Console.ReadLine() ?? "string");

        // Get new password from user
        Console.Write("Please create a Password: ");
        string newPass = Convert.ToString(Console.ReadLine() ?? "string");
        Console.WriteLine();
        Console.WriteLine("Signup successful!");
        return new UserLogin(newUser, newPass);
    }
}
