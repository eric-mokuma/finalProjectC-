namespace eleShoppingApp;

public class CartItem
{
    public Product Product { get; set; }
    public int Quantity { get; set; }

    public CartItem(Product product, int quantity)
    {
        Product = product;
        Quantity = quantity;
    }
}

public class Cart
    {
        //Properties and create a list to hold products in the cart
        public List<CartItem> CartItems { get; set; }
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
        public void AddProduct(Product product, int quantity)
        {
            CartItem? existingItem = CartItems.FirstOrDefault(item =>
                item.Product.ProductID == product.ProductID);

            if (existingItem != null)
            {
                existingItem.Quantity += quantity;
            }
            else
            {
                CartItems.Add(new CartItem(product, quantity));
            }

            Console.WriteLine($"{quantity} x {product.ProductName}, cost ${product.ProductPrice} each added to cart successfully!");
            CalculateTotal();
        }
        //Method: Remove product from cart
        public void RemoveProduct(Product product, int quantity)
        {
            CartItem? existingItem = CartItems.FirstOrDefault(item =>
                item.Product.ProductID == product.ProductID);

            if (existingItem == null)
            {
                Console.WriteLine($"{product.ProductName} not found in cart.");
                return;
            }

            if (quantity >= existingItem.Quantity)
            {
                CartItems.Remove(existingItem);
                Console.WriteLine($"{product.ProductName} removed from cart successfully!");
            }
            else
            {
                existingItem.Quantity -= quantity;
                Console.WriteLine($"{quantity} x {product.ProductName} removed from cart successfully!");
            }

            CalculateTotal();
        }
        //Method: Calculate total price
        public void CalculateTotal()
        {
            TotalPrice = 0;
            foreach (CartItem item in CartItems)
            {
                TotalPrice += item.Product.ProductPrice * item.Quantity;
            }
        }
        //Method: Display cart items and total price
        public void DisplayCart()
    {
            Console.WriteLine("---------------------SHOPPING CART----------------------");
            if(CartItems.Count == 0)
            {
                Console.WriteLine("Your cart is empty.");
                return;
            }
            foreach (CartItem item in CartItems)
            {
                double totalPrice = item.Product.ProductPrice * item.Quantity;
            Console.WriteLine($"| Qt: {item.Quantity} | {item.Product.ProductName} | \tUnit: ${item.Product.ProductPrice} | \tTotal: ${totalPrice} |");
            Console.WriteLine("--------------------------------------------------------");
            }
            double TotalPriceToPay =+ TotalPrice;
            Console.WriteLine($"| Total to pay:                                  ${TotalPriceToPay} |");
            Console.WriteLine("--------------------------------------------------------");
        }
        //Method: Checkout and clear cart
        public void Checkout()
        {
            try
            {
                if (CartItems.Count == 0)
                {
                    Console.WriteLine("Your cart is empty. Add items before checkout.");
                    return;
                }

                foreach (CartItem item in CartItems)
                {
                    if (item.Product.ProductQuantity < item.Quantity)
                    {
                        Console.WriteLine($"{item.Product.ProductName} does not have enough stock. Checkout cancelled.");
                        return;
                    }
                }

                Console.WriteLine("------------Checking out------------");
                DisplayCart();

                foreach (CartItem item in CartItems)
                {
                    item.Product.Purchase(item.Quantity);
                }

                Console.WriteLine("Thank you for your purchase!");
                CartItems.Clear();
                TotalPrice = 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        public void AddProduct()
        {
            try
            {
                Console.Write("Enter the product name to add to cart: ");
                string? productName = Console.ReadLine();
                if (string.IsNullOrEmpty(productName))
                {
                    Console.WriteLine("Invalid product name.");
                    return;
                }

                Product? product = availableProducts.FirstOrDefault(p => p.ProductName.Equals(productName, StringComparison.OrdinalIgnoreCase));
                if (product == null)
                {
                    Console.WriteLine("Product not found.");
                    return;
                }

                if (product.ProductQuantity < 1)
                {
                    Console.WriteLine($"{product.ProductName} is out of stock.");
                    return;
                }

                Console.Write("Enter the quantity you want to purchase: ");
                if (!int.TryParse(Console.ReadLine(), out int quantity) || quantity <= 0)
                {
                    Console.WriteLine("Invalid quantity.");
                    return;
                }

                CartItem? existingItem = CartItems.FirstOrDefault(item =>
                    item.Product.ProductID == product.ProductID);
                int quantityAlreadyInCart = existingItem?.Quantity ?? 0;

                if (quantity + quantityAlreadyInCart > product.ProductQuantity)
                {
                    Console.WriteLine($"Only {product.ProductQuantity - quantityAlreadyInCart} unit(s) of {product.ProductName} available in stock.");
                    return;
                }

                AddProduct(product, quantity);
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
                Console.Write("Enter the product name to remove from cart: ");
                string? productName = Console.ReadLine();
                if (string.IsNullOrEmpty(productName))
                {
                    Console.WriteLine("Invalid product name.");
                    return;
                }

                CartItem? cartItem = CartItems.FirstOrDefault(item =>
                    item.Product.ProductName.Equals(productName, StringComparison.OrdinalIgnoreCase));
                if (cartItem == null)
                {
                    Console.WriteLine("Product not found in cart.");
                    return;
                }

                Console.Write("Enter the quantity to remove: ");
                if (!int.TryParse(Console.ReadLine(), out int quantity) || quantity <= 0)
                {
                    Console.WriteLine("Invalid quantity.");
                    return;
                }

                RemoveProduct(cartItem.Product, quantity);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }//End of Cart class

