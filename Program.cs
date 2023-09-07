using System.Text.Json;

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

            myData.ForEach(data =>
            {
                Console.WriteLine($"Name: {data.Name} Age: {data.Age}");
            });
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}
