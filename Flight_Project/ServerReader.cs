
using System.Text;
using NetworkSourceSimulator;


namespace Flight_Project
{
    public class ServerReader : IFileReader,IObservable
    {
        private Thread reader;
        private List<Entity> entities;
        private List<IObserver> observers;
        private NetworkSourceSimulator.NetworkSourceSimulator datasource;
        private bool isUpdating;

        public ServerReader(string path)
        { 
            datasource = new NetworkSourceSimulator.NetworkSourceSimulator(path, 50, 100);
            entities = new List<Entity>();
            observers = new List<IObserver>();
            datasource.OnNewDataReady += NewDataHandler;
            isUpdating = false;
        }

        public void Read()
        {
            reader = new Thread(ReaderWork);
            reader.Start();
        }

        private void ReaderWork()
        {
            try
            {
                Console.WriteLine("\n______________________________\n" +
                                  "Reading from network started\n" +
                                  "______________________________\n");
                datasource.Run();
                Console.WriteLine(
                    "\n_____________________________\n" +
                    "Reading from network complete\n" +
                    "_____________________________\n");
                Console.Write("User Input: ");
            }
            catch (ThreadInterruptedException)
            {
                Console.WriteLine(
                    "_____________________________________\n"+
                    "Reader thread interrupted. Exiting...\n"+
                    "_____________________________________\n");
            }
        }
        public void GetUpdates()
        {
            if (!isUpdating)
            {
                SetToUpdate();
            }
            Read();
        }

        private void SetToUpdate()
        {
            datasource = new NetworkSourceSimulator.NetworkSourceSimulator("example.ftre", 0, 0);
            isUpdating = true;
            datasource.OnContactInfoUpdate += ContactInfoHandler;
            datasource.OnIDUpdate += IDUpdateHandler;
            datasource.OnPositionUpdate += PositionUpdateHandler;

        }

        public void ContactInfoHandler(object Sender, ContactInfoUpdateArgs args)
        {
            NotifyObservers(args);
        }

        public void IDUpdateHandler(object Sender, IDUpdateArgs args)
        {
            NotifyObservers(args);
        }

        public void PositionUpdateHandler(object Sender, PositionUpdateArgs args)
        {
            NotifyObservers(args);
        }

        public void ServerOptions()
        {
            Console.WriteLine("Server Options.\n1. Serialize current data\n2. Exit");
            while (true)
            {
                Console.Write("User Input: ");
                string input = Console.ReadLine();

                if (input == "1")
                {
                    List<Entity> tempEntities = new List<Entity>(entities);
                    Serializer.JsonSerialisationToFile(tempEntities, $"snapshot_{DateTime.Now.Hour}_{DateTime.Now.Minute}_{DateTime.Now.Second}.json");
                }
                else if (input == "2")
                {
                    reader.Interrupt();
                    entities.Clear();
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please try again.");
                }
            }
            reader.Join();
        }
        private void NewDataHandler(object Sender, NewDataReadyArgs args)
        {
            var dataSender = (NetworkSourceSimulator.NetworkSourceSimulator)Sender;
            var messageBytes = dataSender.GetMessageAt(args.MessageIndex).MessageBytes;
            var id = Encoding.UTF8.GetString(messageBytes, 0, 3);
            entities.Add(Constants.BinaryDictionary[id](messageBytes));
        }


        public void AddObserver(IObserver observer)
        {
            observers.Add(observer);
        }

        public void RemoveObserver(IObserver observer)
        {
            observers.Remove(observer);
        }

        public void NotifyObservers(PositionUpdateArgs args)
        {
            foreach (var observer in observers)
            {
                observer.Update(args);
            }
        }
        public void NotifyObservers(ContactInfoUpdateArgs args)
        {
            foreach (var observer in observers)
            {
                observer.Update(args);
            }
        }
        public void NotifyObservers(IDUpdateArgs args)
        {
            foreach (var observer in observers)
            {
                observer.Update(args);
            }
        }
    }
}
