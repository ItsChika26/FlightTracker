namespace Flight_Project;

public interface IFileReader
{ 
    public void Read();
}

public class FtrFileReader(string path) : IFileReader
{
    public string FilePath { get;} = path;
    public void Read()
    {
        Console.WriteLine($"Reading file {FilePath}");
        using (Stream stream = File.Open(FilePath, FileMode.Open))
        {
            using (var reader = new StreamReader(stream))
            {
                while (!reader.EndOfStream)
                {
                    var objectParameters = reader.ReadLine()?.Split(',');
                    if (objectParameters != null)
                    {
                        CreateObject(objectParameters);
                    }
                }
            }
        }

        Console.WriteLine("Reading Successful");
        
    }

    private void CreateObject(string[] objectParameters)
    {
        var type = objectParameters[0];
        if (!Constants.FactoryDictionary.TryGetValue(type, out var construction))
            throw new InvalidOperationException("No factory method for object exists.");
        construction(objectParameters);
    }
}