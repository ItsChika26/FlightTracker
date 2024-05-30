using System.Linq.Expressions;

namespace Flight_Project
{
    public abstract class INewsProvider(string name)
    {

        public string Name { get; } = name;
        public abstract string VisitAirport(Airport airport);
        public abstract string VisitCargoPlane(CargoPlane cargoPlane);
        public abstract string VisitPassengerPlane(PassengerPlane passengerPlane);
    }

    public class Television(string name) : INewsProvider(name)
    {
        public override string VisitAirport(Airport airport)
        {
            return $"<An image of {airport.Name} airport>";
        }

        public override string VisitCargoPlane(CargoPlane cargoPlane)
        {
            return $"<An image of {cargoPlane.Model}-{cargoPlane.Serial} cargo plane>";
        }

        public override string VisitPassengerPlane(PassengerPlane passengerPlane)
        {
            return $"<An image of {passengerPlane.Model}-{passengerPlane.Serial} passenger plane>";
        }
    }

    public class Radio(string name) : INewsProvider(name)
    {
        public override string VisitAirport(Airport airport)
        {
            return $"Reporting for {Name}, Ladies and Gentlemen, we are at the {airport.Name} airport.";
        }

        public override string VisitCargoPlane(CargoPlane cargoPlane)
        {
            return
                $"Reporting for {Name}, Ladies and Gentlemen, we are seeing the {cargoPlane.Serial} aircraft fly above us.";
        }

        public override string VisitPassengerPlane(PassengerPlane passengerPlane)
        {
            return
                $"Reporting for {Name}, Ladies and Gentlemen, we’ve just witnessed {passengerPlane.Serial} take off.";
        }
    }
    public class Newspaper(string name) : INewsProvider(name)
    {
        public override string VisitAirport(Airport airport)
        {
            return $"{Name} - A report from the {airport.Name} airport,{airport.Country}.";
        }

        public override string VisitCargoPlane(CargoPlane cargoPlane)
        {
            return $"{Name} - An interview with the crew of {cargoPlane.Serial}.";
        }

        public override string VisitPassengerPlane(PassengerPlane passengerPlane)
        {
            return
                $"{Name} - Breaking news! {passengerPlane.Model} aircraft loses EASA fails certification after inspection of {passengerPlane.Serial}.";
        }
    }

}

