namespace Flight_Project
{
    public static class Data
    {
        public static Dictionary<ulong, Entity> AllEntities = new();
        public static Dictionary<ulong,Airport> Airports = new();
        public static Dictionary<ulong,Flight> Flights = new();
        public static Dictionary<ulong,Crew> Crews = new();
        public static Dictionary<ulong,Passenger> Passengers = new();
        public static Dictionary<ulong,Cargo> Cargoes = new();
        public static Dictionary<ulong,CargoPlane> CargoPlanes = new();
        public static Dictionary<ulong,PassengerPlane> PassengerPlanes = new();

    }
}
