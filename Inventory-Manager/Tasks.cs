using System.Data;
using System.Text.Json;

namespace Inventory_Manager;

public class Tasks
{
    /// <summary>
    /// Inputs a datatable of our inventory, creates a JSON of each discontinued item organized by supplier.
    /// </summary>
    /// <param name="dt">Datatable of our Inventory</param>
    public static void ListDiscontinuedItems(DataTable dt)
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
        
        string JSON = JsonSerializer.Serialize(results);
        File.WriteAllText("DiscontinuedItems.json", JSON);
    }
}