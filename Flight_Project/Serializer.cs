using System.Text.Json;

namespace Flight_Project;

internal static class Serializer
{
    public static void JsonSerialisationToFile(IEnumerable<Entity> entities, string filename)
    {
        Console.WriteLine("Serialising to " + filename);
        var options = new JsonSerializerOptions { WriteIndented = true };
        var jsonString = JsonSerializer.Serialize(entities, options);
        File.WriteAllText(filename, jsonString);
        Console.WriteLine("Serialisation successful, file in " + Path.GetFullPath(filename));
    }
}