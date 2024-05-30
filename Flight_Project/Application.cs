using System.Reactive.Subjects;
using FlightTrackerGUI;


namespace Flight_Project
{
    public class Application
    {
        private static Application? instance;
        private Logger logger;
        private UpdateManager updateManager;
        private ServerReader? server;

        public static Application Instance
        {
            get
            {
                instance ??= new Application();
                return instance;
            }
        }
        private Application()
        {
            logger = new Logger();
            updateManager = new UpdateManager();
        }
        public void Run()
        {
            SourceChoice();
            ActionChoice();
        }

        private void SourceChoice()
        {
            Console.WriteLine("Choose your datasource.\n1. Read from file\n2. Read from server\n");
            string choice;
            do
            {
                Console.Write("User Input: ");
                choice = Console.ReadLine();
                if (choice == "1")
                {
                    var reader = new FtrFileReader("example_data.ftr");
                    reader.Read();
                }
                else if (choice == "2")
                {
                   server = new ServerReader("example_data.ftr"); 
                   server.Read();
                   server.AddObserver(logger);
                   server.AddObserver(updateManager);
                   server.ServerOptions();
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please try again.");
                }
            } while (choice != "1" && choice != "2");
        }

        private void ActionChoice()
        {

            Console.WriteLine("\nWhat would you like to do?\n1. Display GUI\n2. Generate all news\n3. GetUpdates\n4. Execute command\n5. Exit\n");
            string choice;
            bool isRunnerRunning = false;
            while(true)
            {
                Console.Write("User Input: ");
                choice = Console.ReadLine();
                if (choice == "1")
                {
                    if (!isRunnerRunning)
                    {
                        DisplayGUI();
                        isRunnerRunning = true;
                    }
                    else
                        Console.WriteLine("GUI is already running!\n");
                }
                else if (choice == "2")
                {
                   DisplayNews();
                }
                else if(choice.ToLower() == "help") 
                    Console.WriteLine("\nWhat would you like to do?\n1. Display GUI\n2. Generate all news\n3. GetUpdates\n4. Exit\n");
                else if (choice == "3")
                {
                    if (server == null)
                    {
                        server = new ServerReader("example_data.ftr"); 
                        server.AddObserver(logger);
                        server.AddObserver(updateManager);
                    }
                    server.GetUpdates();
                }
                else if (choice == "4")
                {
                    Console.WriteLine("Enter command: ");
                    string command = Console.ReadLine();
                    DataFilterer.InterpretCommand(command);
                }
                else if (choice == "5")
                {
                    logger?.Dispose();
                    Environment.Exit(1);
                } 
                else
                {
                    Console.WriteLine("Invalid choice. Please try again.");
                }
            }
        }

        private void DisplayGUI()
        {
            var flightManager = new FightGUIAdapterDecorator();
            Thread runnerThread = new Thread(Runner.Run);
            runnerThread.Start();
            Thread updaterThread = new Thread(flightManager.UpdateFlights);
            updaterThread.Start();
        }

        private void DisplayNews()
        {
            var providers = HelperMethods.ExampleNewsProviders();
            List<IReportable> reportables = new List<IReportable>(Data.Airports.Values);
            reportables.AddRange(Data.CargoPlanes.Values);
            reportables.AddRange(Data.PassengerPlanes.Values);
            var newsGenerator = new NewsGenerator(reportables, providers);
            Console.WriteLine(newsGenerator.GenerateAllNews());
        }

    }
}
