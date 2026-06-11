namespace eleShoppingApp;

public class Cart
    {
        //Properties and create a list to hold products in the cart
        public List<Product> CartItems { get; set; }
        public double TotalPrice { get; set; }
        private List<Product> availableProducts;

        //Constructor
        public Cart(List<Product> products)
        {
            CartItems = [];
            TotalPrice = 0;
            availableProducts = products;
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
            Console.WriteLine("------------SHOPPING CART------------");
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
            Console.WriteLine("------------Checking out------------");
            DisplayCart();
            
            Console.WriteLine("Thank you for your purchase!");
            CartItems.Clear();
            TotalPrice = 0;
        }

        public void AddProduct()
        {
            try
            {
                Console.Write("Enter the product ID to add to cart: ");
                if (!int.TryParse(Console.ReadLine(), out int productId))
                {
                    Console.WriteLine("Invalid product ID.");
                    return;
                }

                Product? product = availableProducts.FirstOrDefault(p => p.ProductID == productId);
                if (product == null)
                {
                    Console.WriteLine("Product not found.");
                    return;
                }

                AddProduct(product);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        public void RemoveProduct()
        {
            try
            {
                Console.Write("Enter the product ID to remove from cart: ");
                if (!int.TryParse(Console.ReadLine(), out int productId))
                {
                    Console.WriteLine("Invalid product ID.");
                    return;
                }

                Product? product = CartItems.FirstOrDefault(p => p.ProductID == productId);
                if (product == null)
                {
                    Console.WriteLine("Product not found in cart.");
                    return;
                }

                RemoveProduct(product);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }//End of Cart class

