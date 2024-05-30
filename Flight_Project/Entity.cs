using System.Text.Json.Serialization;
using NetTopologySuite.Index.Quadtree;
using NetworkSourceSimulator;


namespace Flight_Project;

public interface IReportable
{
    string AcceptNewsProvider(INewsProvider providers);
}

[JsonDerivedType(typeof(Crew))]
[JsonDerivedType(typeof(Airport))]
[JsonDerivedType(typeof(Passenger))]
[JsonDerivedType(typeof(Cargo))]
[JsonDerivedType(typeof(CargoPlane))]
[JsonDerivedType(typeof(Flight))]
[JsonDerivedType(typeof(PassengerPlane))]
public abstract class Entity(string typename, ulong id): IDisposable
{
    [JsonPropertyOrder(-1)] public ulong ID { get; set; } = id;
    [JsonPropertyOrder(-2)] public string Type { get; set; } = typename;

    public abstract void UpdateID(IDUpdateArgs args);
    public virtual void UpdateContactDetails(ContactInfoUpdateArgs args){}
    public virtual void UpdatePosition(PositionUpdateArgs args){}
    public virtual void Dispose()
    {
        Data.AllEntities.Remove(ID);
    }

}

public class Crew(ulong id, string name, ulong age, string phone, string email, ulong practice, string role) : Entity("Crew", id)
{
    public string Name { get; set; } = name;
    public ulong Age { get; set; } = age;
    public string Phone { get; set; } = phone;
    public string Email { get; set; } = email;
    public ulong Practice { get; set; } = practice;
    public string Role { get; set; } = role;
    public override void UpdateID(IDUpdateArgs args)
    {
        Data.AllEntities.Remove(ID);
        Data.Crews.Remove(ID);
        ID = args.NewObjectID;
        Data.AllEntities.Add(ID,this);
        Data.Crews.Add(ID,this);
    }
    public override void UpdateContactDetails(ContactInfoUpdateArgs args)
    {
        Phone = args.PhoneNumber;
        Email = args.EmailAddress;
    }

    public override void Dispose()
    {
        base.Dispose();
        Data.Crews.Remove(ID);
    }
}

public class Passenger(ulong id, string name, ulong age, string phone, string email, string classProp, ulong miles) : Entity("Passenger", id)
{
    public string Name { get; set; } = name;
    public ulong Age { get; set; } = age;
    public string Phone { get; set; } = phone;
    public string Email { get; set; } = email;
    public string Class { get; set; } = classProp;
    public ulong Miles { get; set; } = miles;
    public override void UpdateID(IDUpdateArgs args)
    {
        Data.AllEntities.Remove(ID);
        Data.Passengers.Remove(ID);
        ID = args.NewObjectID;
        Data.AllEntities.Add(ID,this);
        Data.Passengers.Add(ID,this);
    }
    public override void UpdateContactDetails(ContactInfoUpdateArgs args)
    {
        Phone = args.PhoneNumber;
        Email = args.EmailAddress;
    }
    public override void Dispose()
    {
        base.Dispose();
        Data.Passengers.Remove(ID);
    }
}

public class Cargo(ulong id, float weight, string code, string description) : Entity("Cargo", id)
{
    public float Weight { get; set; } = weight;
    public string Code { get; set; } = code;
    public string Description { get; set; } = description;
    public override void UpdateID(IDUpdateArgs args)
    {
        Data.AllEntities.Remove(ID);
        Data.Cargoes.Remove(ID);
        ID = args.NewObjectID;
        Data.AllEntities.Add(ID,this);
        Data.Cargoes.Add(ID,this);
    }
    public override void Dispose()
    {
        base.Dispose();
        Data.Cargoes.Remove(ID);
    }
}

public class CargoPlane(ulong id, string serial, string country, string model, float maxLoad)
    : Entity("Cargo Plane",
        id), IReportable
{
    public string Serial { get; set; } = serial;
    public string Country { get; set; } = country;
    public string Model { get; set; } = model;
    public float MaxLoad { get; set; } = maxLoad;
    public string AcceptNewsProvider(INewsProvider provider)
    {
        return provider.VisitCargoPlane(this);
    }
    public override void UpdateID(IDUpdateArgs args)
    {
        Data.AllEntities.Remove(ID);
        Data.CargoPlanes.Remove(ID);
        ID = args.NewObjectID;
        Data.AllEntities.Add(ID,this);
        Data.CargoPlanes.Add(ID,this);
    }
    public override void Dispose ()
    {
        base.Dispose();
        Data.CargoPlanes.Remove(ID);
    }
}

public class PassengerPlane(
    ulong id,
    string serial,
    string country,
    string model,
    ushort firstClassSize,
    ushort businessSize,
    ushort ecoSize)
    : Entity("Passenger Plane", id), IReportable
{
    public string Serial { get; } = serial;
    public string Country { get; set; } = country;
    public string Model { get; } = model;
    public ushort FirstClassSize { get; set; } = firstClassSize;
    public ushort BusinessClassSize { get; set; } = businessSize;
    public ushort EconomyClassSize { get; set; } = ecoSize;
    public string AcceptNewsProvider(INewsProvider provider)
    {
        return provider.VisitPassengerPlane(this);
    }
    public override void UpdateID(IDUpdateArgs args)
    {
        Data.AllEntities.Remove(ID);
        Data.PassengerPlanes.Remove(ID);
        ID = args.NewObjectID;
        Data.AllEntities.Add(ID, this);
        Data.PassengerPlanes.Add(ID, this);
    }
    public override void Dispose()
    {
        base.Dispose();
        Data.PassengerPlanes.Remove(ID);
    }
}

public class Airport(
    ulong id,
    string name,
    string code,
    float longitude,
    float latitude,
    float amsl,
    string country)
    : Entity("Airport", id),IReportable
{
    public string Name { get; set; } = name;

    public string Code { get; set; } = code;

    public float Longitude { get; set; } = longitude;

    public float Latitude { get; set; } = latitude;

    public float AMSL { get; set; } = amsl;

    public string Country { get; set; } = country;
    public string AcceptNewsProvider(INewsProvider provider)
    {
        return provider.VisitAirport(this);
    }

    public override void UpdatePosition(PositionUpdateArgs args)
    {
        Longitude = args.Longitude;
        Latitude = args.Latitude;
        AMSL = args.AMSL;
    }
    public override void UpdateID(IDUpdateArgs args)
    {
        Data.AllEntities.Remove(ID);
        Data.Airports.Remove(ID);
        ID = args.NewObjectID;
        Data.AllEntities.Add(ID,this);
        Data.Airports.Add(ID,this);
    }
    public override void Dispose()
    {
        base.Dispose();
        Data.Airports.Remove(ID);
    }
}

public class Flight(
    ulong id,
    ulong origin,
    ulong target,
    string takeofftime,
    string landingtime,
    float longitude,
    float latitude,
    float amsl,
    ulong planeid,
    Dictionary<ulong,Crew> crews,
    Dictionary<ulong,Cargo> loads)
    : Entity("Flight", id)
{
    public ulong Origin { get; set; } = origin;
    public ulong Target { get; set; } = target;
    public string TakeoffTime { get; set; } = takeofftime;
    public string LandingTime { get; set; } = landingtime;
    public float Longitude { get; set; } = longitude;
    public float Latitude { get; set; } = latitude;
    public float AMSL { get; set; } = amsl;
    public ulong PlaneID { get; set; } = planeid;
    public Dictionary<ulong,Crew> CrewMembers { get; set; } = crews;
    public Dictionary<ulong,Cargo> Load { get; set; } = loads;

    public override void UpdatePosition(PositionUpdateArgs args)
    {
        Longitude = args.Longitude;
        Latitude = args.Latitude;
        AMSL = args.AMSL;
    }
    public override void UpdateID(IDUpdateArgs args)
    {
        Data.AllEntities.Remove(ID);
        Data.Flights.Remove(ID);
        ID = args.NewObjectID;
        Data.AllEntities.Add(ID,this);
        Data.Flights.Add(ID,this);
    }
    public override void Dispose()
    {
        base.Dispose();
        Data.Flights.Remove(ID);
    }
}