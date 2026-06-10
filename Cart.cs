namespace eleShoppingApp;

public class Cart
    {
        //Properties and create a list to hold products in the cart
        public List<Product> CartItems { get; set; }
        public double TotalPrice { get; set; }
        //Constructor
        public Cart()
        {
            CartItems = [];
            TotalPrice = 0;
        }
        //Method: Add product to cart
        public void AddProduct(Product product)
        {
            CartItems.Add(product);
            Console.WriteLine($"{product.ProductName}, cost ${product.ProductPrice} added to cart successfully!");
            CalculateTotal();
        }
        //Method: Remove product from cart
        public void RemoveProduct(Product product)
        {
            if (CartItems.Remove(product))
            {
                Console.WriteLine($"{product.ProductName}, cost ${product.ProductPrice} removed from cart successfully!");
                CalculateTotal();
            }
            else
            {
                Console.WriteLine($"{product.ProductName}, cost ${product.ProductPrice} not found in cart.");
            }
        }
        //Method: Calculate total price
        public void CalculateTotal()
        {
            TotalPrice = 0;
            foreach (Product product in CartItems)
            {
                TotalPrice += product.ProductPrice;
            }
        }
        //Method: Display cart items and total price
        public void DisplayCart()
        {
            Console.WriteLine("\n======SHOPPING CART======");
            if(CartItems.Count == 0)
            {
                Console.WriteLine("Your cart is empty.");
                return;
            }
            foreach (Product product in CartItems)
            {
                Console.WriteLine($"{product.ProductName} - ${product.ProductPrice}");
            }
            Console.WriteLine($"Total Price: ${TotalPrice}");
        }
        //Method: Checkout and clear cart
        public void Checkout()
        {
            if (CartItems.Count == 0)
            {
                Console.WriteLine("Your cart is empty. Add items before checkout.");
                return;
            }
            Console.WriteLine("\n=====Checking out=====");
            DisplayCart();
            
            Console.WriteLine("Thank you for your purchase!");
            CartItems.Clear();
            TotalPrice = 0;
        }

        internal void AddProduct()
        {
            throw new NotImplementedException();
        }

        internal void RemoveProduct()
        {
            throw new NotImplementedException();
        }
    }//End of Cart class


