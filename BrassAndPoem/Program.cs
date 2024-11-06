using System;
using System.Collections.Generic;

public partial class Program
    {
        static void Main(string[] args)
        {
//create a "products" variable here to include at least five Product instances. Give them appropriate ProductTypeIds.
            List<Product> products = new List<Product>
            {
                new Product { Name = "Brass Lamp", Price = 150.00m, ProductTypeId = 1 },
                new Product { Name = "Brass Sculpture", Price = 200.00m, ProductTypeId = 1 },
                new Product { Name = "Haiku", Price = 10.00m, ProductTypeId = 2 },
                new Product { Name = "Sonnet", Price = 15.00m, ProductTypeId = 2 },
                new Product { Name = "Epic Poem", Price = 25.00m, ProductTypeId = 2 }
            };

//create a "productTypes" variable here with a List of ProductTypes, and add "Brass" and "Poem" types to the List.
            List<ProductType> productTypes = new List<ProductType>
            {
                new ProductType { Id = 1, Title = "Brass" },
                new ProductType { Id = 2, Title = "Poem" }
            };

//put your greeting here
            Console.WriteLine("Welcome to the Brass and Poem!");

//implement your loop here
           int choice = 0;
            while (choice != 5)
            {
                DisplayMenu();

                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    switch (choice)
                    {
                        case 1:
                            DisplayAllProducts(products, productTypes);
                            break;
                        case 2:
                            DeleteProduct(products, productTypes);
                            break;
                        case 3:
                            AddProduct(products, productTypes);
                            break;
                        case 4:
                            UpdateProduct(products, productTypes);
                            break;
                        case 5:
                            Console.WriteLine("Exiting the application. Goodbye!");
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Please enter a valid number.");
                }
            }
        }
// Display Menu
        static void DisplayMenu()
        {
            Console.WriteLine("\nPlease choose an option:");
            Console.WriteLine("1. Display all products ");
            Console.WriteLine("2. Delete a product");
            Console.WriteLine("3. Add a new product");
            Console.WriteLine("4. Update product properties");
            Console.WriteLine("5. Exit");
        }

// display all products with their product method
        static void DisplayAllProducts(List<Product> products, List<ProductType> productTypes)
        {
            Console.WriteLine("\nProducts:");
            foreach (var product in products)
            {
                var productType = productTypes.Find(pt => pt.Id == product.ProductTypeId);
                Console.WriteLine($"Name: {product.Name}, Price: ${product.Price}, Type: {productType?.Title}");
            }
        }

// delete a product method
        static void DeleteProduct(List<Product> products, List<ProductType> productTypes)
        {
            Console.Write("Enter the name of the product to delete: ");
            string productName = Console.ReadLine();

            var product = products.Find(p => p.Name == productName);
            if (product != null)
            {
                products.Remove(product);
                Console.WriteLine("Product deleted successfully!");
            }
            else
            {
                Console.WriteLine("Product not found.");
            }
        }

// add a new product method
        static void AddProduct(List<Product> products, List<ProductType> productTypes)
        {
            Console.Write("Enter product name: ");
            string productName = Console.ReadLine();

            Console.Write("Enter product price: ");
            decimal productPrice = decimal.Parse(Console.ReadLine());

            Console.Write("Enter product type ID: ");
            int productTypeId = int.Parse(Console.ReadLine());

            products.Add(new Product { Name = productName, Price = productPrice, ProductTypeId = productTypeId });
            Console.WriteLine("Product added successfully!");
        }

 // update an existing product method
        static void UpdateProduct(List<Product> products, List<ProductType> productTypes)
        {
            Console.Write("Enter the name of the product to update: ");
            string productName = Console.ReadLine();

            var product = products.Find(p => p.Name == productName);
            if (product != null)
            {
                Console.Write("Enter new product name: ");
                product.Name = Console.ReadLine();

                Console.Write("Enter new product price: ");
                product.Price = decimal.Parse(Console.ReadLine());

                Console.Write("Enter new product type ID: ");
                product.ProductTypeId = int.Parse(Console.ReadLine());

                Console.WriteLine("Product updated successfully!");
            }
            else
            {
                Console.WriteLine("Product not found.");
            }
        }
    }

// don't move or change this!
public partial class Program { }