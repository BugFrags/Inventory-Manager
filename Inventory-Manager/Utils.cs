using System.Data;
using Microsoft.VisualBasic.FileIO;
using System.Text.Json;

namespace Inventory_Manager;

public class Utils
{
    static string PATH = "PATH-TO-INVENTORY";
    
    private static DataTable LoadCsv(string path, bool hasHeader = true)
    {
        DataTable dt = new DataTable();
        using (var reader = new TextFieldParser(path))
        {
            reader.TextFieldType = FieldType.Delimited;
            reader.SetDelimiters(",");

            if (hasHeader)
            {
                string[] headers = reader.ReadFields();
                foreach (string header in headers)
                    dt.Columns.Add(header, typeof(string));
            }

            while (!reader.EndOfData)
            {
                string[] fields = reader.ReadFields();
                dt.Rows.Add(fields);
            }
        }

        return dt;
    }
    public static DataTable LoadDataBase()
    {
        DataTable myInventory = new DataTable();
        
        try
        {
            myInventory = LoadCsv(PATH);
        }
        catch (Exception e)
        {
            Console.WriteLine("Could not load database. Please check your configuration.");
            throw;
        }
        
        return myInventory;
    }
    
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
        
        string JSON = JsonSerializer.Serialize(results);
        File.WriteAllText("DiscontinuedItems.json", JSON);
    }
}