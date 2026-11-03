using System.Data;
using Microsoft.VisualBasic.FileIO;
using System.Text.Json;

namespace Inventory_Manager;

public class Utils
{
    static string PATH = "DIRECTORY";

    public static async Task DownloadManager(string results)
    {
        Console.WriteLine();
        Console.WriteLine("Do you want to download the results? Y/n");
        string answer = Console.ReadLine()?.Trim().ToUpper() ?? "";

        if (answer == "Y") await DownloadResults(results);
    }
    
    public static async Task DownloadResults(string json)
    {
        Console.WriteLine("Downloading results...");
        
        await Task.Delay(2000);
        Console.WriteLine("What would you like to name the downloaded file?");
        Console.Write("> ");
        var fileName = Console.ReadLine();
        
        await File.WriteAllTextAsync($"{fileName}.json", json);
        
        Console.WriteLine("Download completed!");
        Console.WriteLine($"The file was saved as {fileName}.json");
        await Task.Delay(2000);
        
        Console.WriteLine();
    }
    
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
    
}