using System.Data;
using static Inventory_Manager.Utils;
using System.Text.Json;

namespace Inventory_Manager;

public class Tasks
{
    
    public static async Task ListDiscontinuedProducts(DataTable dt)
    {
        var results = dt.AsEnumerable()
            .Where(row => row.Field<String>("Status") == "Discontinued")
            .Select(row => new
            {
                Name = row.Field<string>("Product_Name"),
                Category = row.Field<string>("Catagory"),
                Supplier = row.Field<string>("Supplier_Name"),
                Location = row.Field<string>("Warehouse_Location")
            });

        foreach (var row in results)
        {
            Console.WriteLine($"{row.Name} - {row.Category} - {row.Supplier} -  {row.Location}");
        }
        
        await DownloadManager(JsonSerializer.Serialize(results));
    }

    public static async Task ListActiveProducts(DataTable dt)
    {
        var results = dt.AsEnumerable()
            .Where(row => row.Field<String>("Status") == "Active")
            .Select(row => new
            {
                Name = row.Field<string>("Product_Name"),
                Category = row.Field<string>("Catagory"),
                Supplier = row.Field<string>("Supplier_Name"),
                Location = row.Field<string>("Warehouse_Location")
            });
        
        foreach (var row in results)
        {
            Console.WriteLine($"{row.Name} - {row.Category} - {row.Supplier} - {row.Location}");
        }
        
        await DownloadManager(JsonSerializer.Serialize(results));
    }
    
    public static async Task LowStockProducts(DataTable dt)
    {
        var results = dt.AsEnumerable()
            .Where(row => Convert.ToInt32(row.Field<string>("Stock_Quantity")) <= Convert.ToInt32(row.Field<string>("Reorder_Level")))
            .Select(row => new
            {
                Name = row.Field<string>("Product_Name"),
                Location = row.Field<string>("Warehouse_Location"),
                Supplier = row.Field<string>("Supplier_Name"),
                Stock = Convert.ToInt32(row.Field<string>("Stock_Quantity"))
            });
        
        foreach (var row in results)
        {
            Console.WriteLine($"{row.Name} - {row.Location} - {row.Supplier} - {row.Stock}");
        }
        
        await DownloadManager(JsonSerializer.Serialize(results));
    }
}