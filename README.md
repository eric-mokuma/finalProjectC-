# Electronic Shopping App

A simple C# console application for managing an electronics inventory and shopping experience.

## What it does

- Allows customers to sign up and log in.
- Allows admin staff to add, remove, display, and search products.
- Supports product types: TV, Smartphone, and Laptop.
- Each product type has its own details and display output.

## How to run

1. Open the project folder in Visual Studio or use the command line.
2. Run `dotnet run` from the project directory.
3. Choose:
   - `1` to log in as a customer
   - `2` to log in as staff (username: `admin`, password: `admin`)
   - `3` to exit

## Staff product flow

- When adding a product, select the type first.
- Then enter the shared details (ID, name, brand, price, inventory).
- Finally enter the type-specific fields for TV, Smartphone, or Laptop.

## Notes

- Product data is stored in memory while the app is running.
- There is no persistent storage in this version.

