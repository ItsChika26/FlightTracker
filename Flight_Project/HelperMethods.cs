namespace Flight_Project
{
    public static class HelperMethods
    {
        public static List<T> Parse<T>(string[] arguments) where T : IParsable<T>
        {
            List<T> result = new List<T>();

            foreach (var item in arguments)
            {
                if (T.TryParse(item, null, out var parsable))
                    result.Add(parsable);
                else
                    throw new ArgumentException("Invalid format");
            }

            return result;
        }

        public static List<INewsProvider> ExampleNewsProviders()
        {
            var providers = new List<INewsProvider>();
            providers.Add(new Television("Abelian Television"));
            providers.Add(new Television("Channel TV-Tensor"));
            providers.Add(new Newspaper("Categories Journal"));
            providers.Add(new Newspaper("Polytechnical Gazette"));
            providers.Add(new Radio("Quantifier radio"));
            providers.Add(new Radio("Shmem radio"));
            return providers;
        }

        public static IReadOnlyCollection<string> ClassesNames = new HashSet<string>()
        {
            "Flight",
            "Airport",
            "Crew",
            "Passenger",
            "Cargo",
            "CargoPlane",
            "PassengerPlane"
        };

        public static IReadOnlyDictionary<string, string> CrewFields = new Dictionary<string, string>()
        {
            {"ID","ulong"},
            { "Name", "string" },
            { "Age", "int" },
            { "Phone", "string" },
            { "Email", "string" },
            { "Practice", "string" },
            { "Role", "string" }
        };

        public static IReadOnlyDictionary<string, string> PassengerFields = new Dictionary<string, string>()
        {
            {"ID","ulong"},
            { "Name", "string" },
            { "Age", "int" },
            { "Phone", "string" },
            { "Email", "string" },
            { "Class", "string" },
            { "Miles", "int" }
        };

        public static IReadOnlyDictionary<string, string> CargoFields = new Dictionary<string, string>()
        {
            {"ID","ulong"},
            { "Weight", "double" },
            { "Code", "string" },
            { "Description", "string" }
        };

        public static IReadOnlyDictionary<string, string> CargoPlaneFields = new Dictionary<string, string>()
        {
            {"ID","ulong"},
            { "Serial", "string" },
            { "Country", "string" },
            { "Model", "string" },
            { "MaxLoad", "double" }
        };

        public static IReadOnlyDictionary<string, string> PassengerPlaneFields = new Dictionary<string, string>()
        {
            {"ID","ulong"},
            { "Serial", "string" },
            { "Country", "string" },
            { "Model", "string" },
            { "FirstClassSize", "int" },
            { "BusinessClassSize", "int" },
            { "EconomyClassSize", "int" }
        };

        public static IReadOnlyDictionary<string, string> AirportFields = new Dictionary<string, string>()
        {
            {"ID","ulong"},
            { "Name", "string" },
            { "Code", "string" },
            { "Longitude", "double" },
            { "Latitude", "double" },
            { "AMSL", "double" },
            { "Country", "string" }
        };

        public static IReadOnlyDictionary<string, string> FlightFields = new Dictionary<string, string>()
        {
            {"ID","ulong"},
            { "Origin", "string" },
            { "Target", "string" },
            { "TakeoffTime", "DateTime" },
            { "LandingTime", "DateTime" },
            { "Longitude", "double" },
            { "Latitude", "double" },
            { "AMSL", "double" },
            { "PlaneID", "string" }
        };

        public static IReadOnlyDictionary<string, IReadOnlyDictionary<string, string>> Fields = new Dictionary<string, IReadOnlyDictionary<string, string>>()
        {
            { "Crew", CrewFields },
            { "Passenger", PassengerFields },
            { "Cargo", CargoFields },
            { "CargoPlane", CargoPlaneFields },
            { "PassengerPlane", PassengerPlaneFields },
            { "Airport", AirportFields },
            { "Flight", FlightFields }
        };

        public static IReadOnlyCollection<string> ComparisionOperators = new HashSet<string>()
        { 
            "==", "!=", ">=", "<="
        };

        public static IReadOnlyCollection<string> LogicalOperators = new HashSet<string>()
        {
            "AND", "OR"
        };




    }
}
