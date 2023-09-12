using System.Text.Json;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

#nullable enable

// Define a class that matches the structure of your JSON data
public class MyData
{
    public string? Name { get; set; }
    public int Age { get; set; }
}

class Program
{
    static void Main()
    {
        // Specify the path to your JSON file
        string jsonFilePath = "file.json";
        List<MyData> myData = new List<MyData>();

        try
        {
            IEnumerable<string> jsonLines = File.ReadLines(jsonFilePath);

            foreach (string jsonLine in jsonLines)
            {
                MyData? myObject = JsonSerializer.Deserialize<MyData>(jsonLine);
                if (myObject != null)
                    myData.Add(myObject);
            }

            IOrderedEnumerable<MyData> Records = myData.OrderBy(x => x.Age);
            foreach (var Record in Records)
            {
                Console.WriteLine($"Name: {Record.Name} Age: {Record.Age}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}
