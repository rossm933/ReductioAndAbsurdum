// See https://aka.ms/new-console-template for more information
using System.Numerics;

List<Product> products = new List<Product>()
{
new Product()
{
    
    Name = "Bertie Bott's Beans",
    Price = 13.50M,
    ProductTypeId = 0,
    Sold = false,
    DateStocked = new DateTime(2024, 2, 18)
},
new Product()
{
   
    Name = "Wand",
    Price = 40.35M,
    ProductTypeId = 1,
    Sold = false,
    DateStocked = new DateTime(2023, 5, 19)
},
new Product()
{
    
    Name = "House Robes",
    Price = 55.55M,
    ProductTypeId = 2,
    Sold = false,
    DateStocked = new DateTime(2024, 1, 11)
},
new Product()
{
    
    Name = "Polyjuice Potion",
    Price = 60,
    ProductTypeId = 3,
    Sold = false,
    DateStocked = new DateTime(2023, 12, 6)
},
new Product()
{
   
    Name = "Golden Snitch",
    Price = 70.50M,
    ProductTypeId = 0,
    Sold = false,
    DateStocked = new DateTime(2022, 11, 21)
}
};

List<ProductType> productTypes = new List<ProductType>()
{
    new ProductType()
    {
        Name = "Enchanted Objects",
        Id = 0
    },

    new ProductType()
    {
       Name = "Wands",
       Id = 1
    },

     new ProductType()
    {
       Name = "Apparel",
       Id = 2
    },

      new ProductType()
    {
       Name = "Potions",
       Id = 3
    }
};
string greeting = @"Welcome to Reductio & Absurdum
Providing high-quality magical supplies to the wizarding community for nearly 1000 years";

Console.WriteLine(greeting);

string choice = null;
while (choice != "0")
{
    Console.WriteLine(@"Choose an option: 
                      0. Exit
                      1. View All Products
                      2. Query by Type 
                      3. Add a Product
                      4. Update Product Details
                      5. Delete a Product");

    choice = Console.ReadLine();

    if (choice == "0")
    {
        Console.WriteLine("Goodbye!");
    }
    else if (choice == "1")
    {
        ViewAllProducts();
    }
    else if (choice == "2")
    {
        QueryByType();
    }
    else if (choice == "3")
    {
        AddAProduct();
    }
    else if (choice == "4")
    {
        UpdateProductDetails();
    }
    else if (choice == "5")
    {
        DeleteProduct();
    }
    else
    {
        Console.WriteLine("Please choose an existing option only!");
    }
}

void ViewAllProducts()
{
    {
        decimal totalValue = 0.0M;
        foreach (Product product in products)
        {
            if (!product.Sold)
            {
                totalValue += product.Price;
            }
        }
        Console.WriteLine(" Products: ");

        foreach (Product product in products)
        {
            Console.WriteLine($"{product.Name}   Price: ${product.Price}   In Stock: {product.Sold}   Type ID: {product.ProductTypeId}   DaysOnShelf: {product.DaysOnShelf}");
        }
        Console.WriteLine($"\n\t~Total Inventory Value: ${totalValue}~\n");
        Console.Write("Press Enter to continue...");
        Console.ReadLine();
        }
    }

void AddAProduct()
{

    Console.WriteLine("To add a product, please enter product name");

    string responseName = Console.ReadLine();

    Console.WriteLine("Please enter the product price");

    decimal responsePrice = Convert.ToDecimal(Console.ReadLine());

    Console.WriteLine(@"Please select a product type ID:
    0. Potions
    1. Apparel
    3. Enchanted Objects
    4. Wands");

    int responseID = int.Parse(Console.ReadLine());

    Product newProduct = new Product
    {
        Name = responseName,
        Price = responsePrice,
        Sold = true,
        ProductTypeId = responseID

    };

    products.Add(newProduct);

    Console.WriteLine($"You added: {newProduct.Name}, which costs {newProduct.Price} dollars");
}


void UpdateProductDetails()
{
    Console.WriteLine("Please select product to update:");
    Console.WriteLine("Products:");

    for (int i = 0; i < products.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {products[i].Name}");
    }

    Product chosenProduct = null;

    while (chosenProduct == null)
    {
        Console.WriteLine("Please enter a product number: ");
        try
        {
            int response = int.Parse(Console.ReadLine().Trim());

            chosenProduct = products[response - 1];
        }
        catch (FormatException)
        {
            Console.WriteLine("Please type only integers!");
        }
        catch (ArgumentOutOfRangeException)
        {
            Console.WriteLine("Please choose an existing item only!");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            Console.WriteLine("Do better!");
        }
    }

    Console.WriteLine(@$"You chose:
    {chosenProduct.Name}, which costs {chosenProduct.Price} galleons, and {(chosenProduct.Sold ? "is available" : "is not available")}");

    Console.WriteLine(@"Please choose a field to edit:
        0. Name
        1. Price
        2. Available
        3. Product Type ID");

    int index = products.IndexOf(chosenProduct);

    int choice = int.Parse(Console.ReadLine());
    if (choice == 0)
    {
        Console.WriteLine("Please enter new name");
        string newName = Console.ReadLine();
        products[index].Name = newName;
    }
    else if (choice == 1)
    {
        Console.WriteLine("Please enter new price");
        decimal newPrice = Convert.ToDecimal(Console.ReadLine());
        products[index].Price = newPrice;

    }
    else if (choice == 2)
    {
        Console.WriteLine(@"Please select an option:
        0. Sold
        1. Available");

        int newChoice = int.Parse(Console.ReadLine());

        if (newChoice == 0)
        {
            products[index].Sold = false;
        }
        else if (newChoice == 1)
        {
            products[index].Sold = true;
        }

    }
    else if (choice == 3)
    {
        Console.WriteLine(@"Please enter new Product Type ID:
           0. Potions
           1. Apparel
           2. Enchanted Objects
           3. Wands");

        int newId = int.Parse(Console.ReadLine());
        products[index].ProductTypeId = newId;

    }

}
void DeleteProduct()
{
    string choice = null;

    while (choice != "0")
    {
        try
        {
            // loop through products but create a ReadLine
            Console.WriteLine("0. Goodbye");
            for (int i = 0; i < products.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {products[i].Name}");

            }
            choice = Console.ReadLine();
            products.RemoveAt(Int32.Parse(choice) - 1);
        }
        catch
        {
            break;
        }

    }

}
void QueryByType()
{
    Console.WriteLine(@"Please select a product type ID:
    0. Enchanted Objects
    1. Wands
    2. Apparel
    3. Potions");

    int response = int.Parse(Console.ReadLine());

    List<Product> queryProducts = products.FindAll(x => x.ProductTypeId == response);

    foreach (Product product in queryProducts)
    {
        Console.WriteLine($"{product.Name}");
    }
    queryProducts.Clear();
}