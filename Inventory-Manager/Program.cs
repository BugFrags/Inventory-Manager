using static Inventory_Manager.Utils;
using static Inventory_Manager.Tasks;

var LOGO = @"
----------------------------------------------------------------------------------------------------------------------------------
 ▄██████ █████████ ██████▄  ██████▄   ▄██████      ███ ██████▄  ███  ███  ▄██████ ██████▄  █████████ ██████▄  ██████▄  ███  ███
▒▒▒▒     ▀▀ ▒▒▒ ▀▀ ▄▄▄  ▒▒▒ ▄▄▄  ▒▒▀ ▒▒▒  ▀▀▀      ▒▒▒ ▄▄▄  ▒▒▒ ▒▒▒  ▒▒▒ ▒▒▒  ▀▀▀ ▄▄▄  ▒▒▒ ▀▀ ▒▒▒ ▀▀ ▄▄▄  ▒▒▒ ▄▄▄  ▒▒▀ ▒▒▒▄ ▒▒▒
▀██████▄    ███    ███  ███ ██████▄  █████▀        ███ ███  ███ ███  ███ █████▀   ███  ███    ███    ███  ███ ██████▄   ▀██████
     ▒▒▒    ▒▒▒    ▒▒▒  ▒▒▒ ▒▒▒  ▒▒▒ ▒▒▒  ▄▄▄      ▒▒▒ ▒▒▒  ▒▒▒ ▀▒▒▄ ▒▒▀ ▒▒▒  ▄▄▄ ▒▒▒  ▒▒▒    ▒▒▒    ▒▒▒  ▒▒▒ ▒▒▒  ▒▒▒     ▄▒▒▒
██████▀     ███     ▀████▀  ███  ███  ▀██████      ███ ███  ███   ▀██▀    ▀██████ ███  ███    ███     ▀████▀  ███  ███ ██████▀ 

                                                    CREATED BY BUGFRAGS
----------------------------------------------------------------------------------------------------------------------------------
";

var MENU = @"
[A] Query active products
[D] Query discontinued products
[L] List low stock products
[T] Top Selling products
[S] Sales by Category
[E] Exit
";

var running = true;

Console.WriteLine("Loading database...");
var inventory = LoadDataBase();
Console.WriteLine("Load successful!");
Console.WriteLine(LOGO);

while (running)
{
    Console.WriteLine("What would you like to do?");
    Console.WriteLine(MENU);
    Console.Write("> ");
    
    var command = Console.ReadLine();
    
    switch (command?.ToUpper().Trim())
    {
        case "D": 
            await ListDiscontinuedProducts(inventory);
            break;
        case "A":
            await ListActiveProducts(inventory);
            break;
        case "L":
            await LowStockProducts(inventory);
            break;
        case "T":
            await TopSellingProducts(inventory);
            break;
        case "S":
            await SalesByCategory(inventory);
            break;
        case "E": 
            Console.WriteLine("Have a nice day!"); 
            running = false; 
            break;
    }
}
