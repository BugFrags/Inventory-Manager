using static Inventory_Manager.Utils;
using static Inventory_Manager.Tasks;
using Microsoft.VisualBasic.FileIO;
using System.Data;

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
[D] Query discontinued items
[] TEST
[E] Exit
";

var running = true;

Console.WriteLine("Loading database...");
DataTable inventory = LoadDataBase();
Console.WriteLine("Load successful!");
Console.WriteLine(LOGO);

while (running)
{
    Console.WriteLine("What would you like to do?");
    Console.WriteLine(MENU);
    Console.Write("> ");
    
    var command = Console.ReadLine();
    
    switch (command.ToUpper().Trim())
    {
        case "D": 
            await ListDiscontinuedItems(inventory);
            break;
        case "E": 
            Console.WriteLine("Have a nice day!"); 
            running = false; 
            break;
    }
    
    // Console.Clear();
}
