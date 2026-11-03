using System.Data;
using System.Text.Json;

namespace Inventory_Manager;

public class Tasks
{
    /// <summary>
    /// Inputs a datatable of our inventory, creates a JSON of each discontinued item organized by supplier.
    /// </summary>
    /// <param name="dt">Datatable of our Inventory</param>
    public static async Task ListDiscontinuedItems(DataTable dt)
    {
        var results = dt.AsEnumerable()
            .Where(row => row.Field<String>("Status") == "Discontinued")
            .Select(row => new
            {
                Name = row.Field<string>("Product_Name"),
                Catagory = row.Field<string>("Catagory"),
                Supplier = row.Field<string>("Supplier_Name")
            });

        foreach (var row in results)
        {
            Console.WriteLine($"{row.Name} - {row.Catagory} - {row.Supplier}");
        }
        
        Console.WriteLine("Do you want to download the results? Y/n");
        string answer = Console.ReadLine()?.Trim().ToUpper() ?? "";

        if (answer == "Y")
        {
            string json = JsonSerializer.Serialize(results);
            
            Console.WriteLine("Downloading results...");
            await Task.Delay(2000);
            await File.WriteAllTextAsync("DiscontinuedItems.json", json);
            Console.WriteLine("Download completed!");
        }
    }
}