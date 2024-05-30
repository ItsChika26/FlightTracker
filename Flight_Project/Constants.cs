using Flight_Project.Filters;

namespace Flight_Project;

public static class Constants
{
    public static Dictionary<string, FactoryMethod> FactoryDictionary = new()
    {
        { "AI", FactoryMethods.AirportConstructor },
        { "C", FactoryMethods.CrewConstructor },
        { "P", FactoryMethods.PassengerConstructor },
        { "CA", FactoryMethods.CargoConstructor },
        { "CP", FactoryMethods.CargoPlaneConstructor },
        { "PP", FactoryMethods.PassengerPlaneConstructor },
        { "FL", FactoryMethods.FlightConstructor }
    };

    public static Dictionary<string, BinaryConversion> BinaryDictionary = new()
    {
        { "NCR", BinaryConversions.CrewConversion },
        { "NPA", BinaryConversions.PassengerConversion },
        { "NCA", BinaryConversions.CargoConversion },
        { "NCP", BinaryConversions.CargoPlaneConversion },
        { "NPP", BinaryConversions.PassengerPlaneConversion },
        { "NAI", BinaryConversions.AirportConversion },
        { "NFL", BinaryConversions.FlightConversion }

    };

    public static Dictionary<string, ICrewFilter> CrewFilters = new()
    {
        { "==", new CrewEqualsOperatorFilter() },
        { "!=", new CrewNotEqualsOperatorFilter() },
        { ">", new CrewGreaterThanOperatorFilter() },
        { "<", new CrewLessThanOperatorFilter() }
    };

    public static Dictionary<string, IFlightFilter> FlightFilters = new()
    {
        { "==", new FlightEqualsOperatorFilter() },
        { "!=", new FlightNotEqualsOperatorFilter() },
        { ">", new FlightGreaterThanOperatorFilter() },
        { "<", new FlightLessThanOperatorFilter() }
    };

    public static Dictionary<string, IAirportFilter> AirportFilters = new()
    {
        { "==", new AirportEqualsOperatorFilter() },
        { "!=", new AirportNotEqualsOperatorFilter() },
        { ">", new AirportGreaterThanOperatorFilter() },
        { "<", new AirportLessThanOperatorFilter() }
    };

    public static Dictionary<string, IPassengerFilter> PassengerFilters = new()
    {
        { "==", new PassengerEqualsOperatorFilter() },
        { "!=", new PassengerNotEqualsOperatorFilter() },
        { ">", new PassengerGreaterThanOperatorFilter() },
        { "<", new PassengerLessThanOperatorFilter() }
    };

    public static Dictionary<string, ICargoFilter> CargoFilters = new()
    {
        { "==", new CargoEqualsOperatorFilter() },
        { "!=", new CargoNotEqualsOperatorFilter() },
        { ">", new CargoGreaterThanOperatorFilter() },
        { "<", new CargoLessThanOperatorFilter() }
    };

    public static Dictionary<string, ICargoPlaneFilter> CargoPlaneFilters = new()
    {
        { "==", new CargoPlaneEqualsOperatorFilter() },
        { "!=", new CargoPlaneNotEqualsOperatorFilter() },
        { ">", new CargoPlaneGreaterThanOperatorFilter() },
        { "<", new CargoPlaneLessThanOperatorFilter() }
    };

    public static Dictionary<string, IPassengerPlaneFilter> PassengerPlaneFilters = new()
    {
        { "==", new PassengerPlaneEqualsOperatorFilter() },
        { "!=", new PassengerPlaneNotEqualsOperatorFilter() },
        { ">", new PassengerPlaneGreaterThanOperatorFilter() },
        { "<", new PassengerPlaneLessThanOperatorFilter() }
    };

    public static Dictionary<string, ICommandInterpreter> Interpreters = new()
    {
        { "display", new DisplayCommandInterpreter() },
        { "add", new AddCommandInterpreter() },
        { "update", new UpdateCommandInterpreter() },
        { "delete", new DeleteCommandInterpreter() }
    };
}
