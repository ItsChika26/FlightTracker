using Avalonia.Markup.Xaml.MarkupExtensions;
using Mapsui.Projections;
using System.Reactive.Joins;

namespace Flight_Project;

public delegate Entity FactoryMethod(string[] arguments);

internal static class FactoryMethods
{
    public static Entity CrewConstructor(string[] arguments)
    {
        if (!ulong.TryParse(arguments[1], out var ID))
            throw new ArgumentException("Invalid ID format");

        if (!ulong.TryParse(arguments[3], out var age))
            throw new ArgumentException("Invalid age format");

        if (!ulong.TryParse(arguments[6], out var practice))
            throw new ArgumentException("Invalid practice format.");

        var name = arguments[2];
        var phone = arguments[4];
        var email = arguments[5];
        var role = arguments[7];

        var crew = new Crew(ID, name, age, phone, email, practice, role);
        Data.Crews.TryAdd(ID,crew);
        Data.AllEntities.TryAdd(ID,crew);
        return crew;
    }

    public static Entity PassengerConstructor(string[] arguments)
    {
        if (!ulong.TryParse(arguments[1], out var ID))
            throw new ArgumentException("Invalid ID format");

        if (!ulong.TryParse(arguments[3], out var age))
            throw new ArgumentException("Invalid age format");

        if (!ulong.TryParse(arguments[7], out var miles))
            throw new ArgumentException("Invalid miles format");

        var name = arguments[2];
        var phone = arguments[4];
        var email = arguments[5];
        var _class = arguments[6];

        var passenger = new Passenger(ID, name, age, phone, email, _class, miles);
        Data.Passengers.TryAdd(ID,passenger);
        Data.AllEntities.TryAdd(ID,passenger);
        return passenger;
    }

    public static Entity CargoConstructor(string[] arguments)
    {
        if (!ulong.TryParse(arguments[1], out var ID))
            throw new ArgumentException("Invalid ID format");

        if (!float.TryParse(arguments[2], out var weight))
            throw new ArgumentException("Invalid weight format");

        var code = arguments[3];
        var description = arguments[4];

        var cargo = new Cargo(ID, weight, code, description);
        Data.Cargoes.TryAdd(ID,cargo);
        Data.AllEntities.TryAdd(ID,cargo);
        return cargo;
    }

    public static Entity CargoPlaneConstructor(string[] arguments)
    {
        if (!ulong.TryParse(arguments[1], out var ID))
            throw new ArgumentException("Invalid ID format");

        if (!float.TryParse(arguments[5], out var maxload))
            throw new ArgumentException("Invalid MaxLoad format");

        var serial = arguments[2];
        var country = arguments[3];
        var model = arguments[4];

        var cargoPlane = new CargoPlane(ID, serial, country, model, maxload);
        Data.CargoPlanes.TryAdd(ID,cargoPlane);
        Data.AllEntities.TryAdd(ID,cargoPlane);
        return cargoPlane;
    }

    public static Entity PassengerPlaneConstructor(string[] arguments)
    {
        if (!ulong.TryParse(arguments[1], out var ID))
            throw new ArgumentException("Invalid ID format");

        if (!ushort.TryParse(arguments[5], out var firstclasssize))
            throw new ArgumentException("Invalid First Class Size format");

        if (!ushort.TryParse(arguments[6], out var businesssize))
            throw new ArgumentException("Invalid Business Class size format");

        if (!ushort.TryParse(arguments[7], out var ecosize))
            throw new ArgumentException("Invalid Economy Class Size format");

        var serial = arguments[2];
        var country = arguments[3];
        var model = arguments[4];

        var passengerPlane = new PassengerPlane(ID, serial, country, model, firstclasssize, businesssize, ecosize);
        Data.PassengerPlanes.TryAdd(ID,passengerPlane);
        Data.AllEntities.TryAdd(ID,passengerPlane);
        return passengerPlane;
    }

    public static Entity AirportConstructor(string[] arguments)
    {
        if (!ulong.TryParse(arguments[1], out var ID))
            throw new ArgumentException("Invalid ID format");

        if (!float.TryParse(arguments[4], out var longitude))
            throw new ArgumentException("Invalid longitude format");

        if (!float.TryParse(arguments[5], out var latitude))
            throw new ArgumentException("Invalid latitude format");

        if (!float.TryParse(arguments[6], out var amsl))
            throw new ArgumentException("Invalid AMSL format");

        var name = arguments[2];
        var code = arguments[3];
        var country = arguments[7];

        var airport = new Airport(ID, name, code, longitude, latitude, amsl, country);
        Data.Airports.TryAdd(ID,airport);
        Data.AllEntities.TryAdd(ID,airport);
        return airport;
    }

    public static Entity FlightConstructor(string[] arguments)
    {
        if (!ulong.TryParse(arguments[1], out var ID))
            throw new ArgumentException("Invalid ID format");

        if (!ulong.TryParse(arguments[2], out var origin))
            throw new ArgumentException("Invalid origin format");

        if (!ulong.TryParse(arguments[3], out var target))
            throw new ArgumentException("Invalid target format");

        if (!float.TryParse(arguments[6], out var longitude))
            throw new ArgumentException("Invalid longitude format");

        if (!float.TryParse(arguments[7], out var latitude))
            throw new ArgumentException("Invalid latitude format");

        if (!float.TryParse(arguments[8], out var amsl))
            throw new ArgumentException("Invalid AMSL format");

        if (!ulong.TryParse(arguments[9], out var planeid))
            throw new ArgumentException("Invalid planeID format");

        var takeoffTime = arguments[4];
        var landingTime = arguments[5];
        var crewList =
            HelperMethods.Parse<ulong>(arguments[10]
                .Split(new[] { '[', ']', ';' },
                    StringSplitOptions.RemoveEmptyEntries));
        Dictionary<ulong, Crew> crews = new Dictionary<ulong, Crew>();
        foreach (var crew in crewList)
        {
            if (Data.Crews.TryGetValue(crew, out var c))
                crews.TryAdd(crew, c);
        }
        var load = HelperMethods.Parse<ulong>(arguments[11]
            .Split(new[] { '[', ']', ';' },
                StringSplitOptions.RemoveEmptyEntries));
        Dictionary<ulong, Cargo> cargoes = new Dictionary<ulong, Cargo>();
        foreach (var cargo in load)
        {
            if (Data.Cargoes.TryGetValue(cargo, out var c))
                cargoes.TryAdd(cargo, c);
        }
        var flight = new Flight(ID, origin, target, takeoffTime, landingTime, longitude, latitude, amsl, planeid,
            crews, cargoes);
        Data.Flights.TryAdd(ID,flight);
        Data.AllEntities.TryAdd(ID,flight);
        return flight;
    }
}