using System.Data;
using Microsoft.VisualBasic.FileIO;
using System.Text.Json;

namespace Inventory_Manager;

public class Utils
{
    static string PATH = "PATH-TO-DATABASE";
    
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