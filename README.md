# Electronic Shopping App

A C# console application for managing an electronics inventory and providing a customer shopping experience. The app uses object-oriented design with a shared `Product` base class and specialized product types.

### Customer
- Sign up for a new account or log in with existing credentials
- Browse products by category
- Search products by keyword
- Add and remove items from a shopping cart
- View cart contents and total price

### Staff (Admin)
- Add new products or restock existing ones
- Remove inventory quantity (products are deleted when quantity reaches zero)
- Display all products in inventory
- Search products by name

## Product types

All products share: ID, name, brand, price, quantity, and type. Each type adds its own details:

| Type         | Extra fields                                              |
|--------------|-----------------------------------------------------------|
| TV           | Screen resolution, screen size (inches)                   |
| Smartphone   | Camera details, operating system version                  |
| Laptop       | RAM (GB), storage (GB), processor, display size (inches)  |
| Tablet       | Screen size (inches), battery life (hours)                |
| Headphones   | Wireless, noise cancelling                                |
| Smartwatch   | Waterproof, heart rate monitor                            |


From the main menu:
- `1` — Customer login / signup
- `2` — Staff login
- `3` — Exit

### Default credentials

| Role      | Username  | Password  |
|-----------|-----------|-----------|
| Customer  | `customer`| `password`|
| Staff     | `admin`   | `admin`   |

New customer accounts can be created through the signup flow.

## Navigation

Most menus support going back to the previous screen by entering `n`:

- Main menu → Customer or Staff submenu
- Customer login, signup, and shopping menus
- Product category browser
- Staff login and inventory menus
- Add-product type selection

## Staff product flow

1. Select **Add New product** from the inventory menu
2. Choose a product type (TV, Smartphone, Laptop, Tablet, Headphones, or Smartwatch)
3. Enter shared details: ID, name, brand, price, and quantity
4. Enter type-specific fields for the selected product

If a product with the same name and type already exists, only the quantity is updated.

## Project structure

| File                                                                                 | Purpose                                             |
|--------------------------------------------------------------------------------------|-----------------------------------------------------|
| `Program.cs`                                                                         | Application entry point and shared inventory        |
| `Product.cs`                                                                         | Base product class with inventory and search logic  |
| `Tv.cs`, `Smartphone.cs`, `Laptop.cs`, `Tablet.cs`, `Headphone.cs`, `Smartwatch.cs`  | Product subclasses                                  |
| `UserLogin.cs`                                                                       | Customer account creation and credentials           |
| `CustomerMenu.cs`                                                                    | Customer login and shopping menus                   |
| `StaffMenu.cs`                                                                       | Staff login and inventory management                |
| `Cart.cs`                                                                            | Shopping cart                                       |

## Notes

- Product and customer data is stored in memory while the app is running
- There is no persistent storage (database or file) in this version
- Staff-managed inventory is shared with the customer shopping experience through `Program.ProductInventory`
