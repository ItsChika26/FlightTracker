
namespace Flight_Project.Filters
{
    public interface IAirportFilter
    {
        public List<Airport> FilterbyID(List<Airport> airports, ulong value);
        public List<Airport> FilterbyName(List<Airport> airports, string value);
        public List<Airport> FilterbyCode(List<Airport> airports, string value);
        public List<Airport> FilterbyLongitude(List<Airport> airports, float value);
        public List<Airport> FilterbyLatitude(List<Airport> airports, float value);
        public List<Airport> FilterbyAMSL(List<Airport> airports, float value);
        public List<Airport> FilterbyCountry(List<Airport> airports, string value);
    }
    public class AirportEqualsOperatorFilter : IAirportFilter
    {
        public List<Airport> FilterbyID(List<Airport> airports, ulong value)
        {
            return airports.Where(a => a.ID == value).ToList();
        }

        public List<Airport> FilterbyName(List<Airport> airports, string value)
        {
            return airports.Where(a => a.Name == value).ToList();
        }

        public List<Airport> FilterbyCode(List<Airport> airports, string value)
        {
            return airports.Where(a => a.Code == value).ToList();
        }

        public List<Airport> FilterbyLongitude(List<Airport> airports, float value)
        {
            return airports.Where(a => a.Longitude == value).ToList();
        }

        public List<Airport> FilterbyLatitude(List<Airport> airports, float value)
        {
            return airports.Where(a => a.Latitude == value).ToList();
        }

        public List<Airport> FilterbyAMSL(List<Airport> airports, float value)
        {
            return airports.Where(a => a.AMSL == value).ToList();
        }

        public List<Airport> FilterbyCountry(List<Airport> airports, string value)
        {
            return airports.Where(a => a.Country == value).ToList();
        }
    }

    public class AirportGreaterThanOperatorFilter : IAirportFilter
    {
        public List<Airport> FilterbyID(List<Airport> airports, ulong value)
        {
            return airports.Where(a => a.ID > value).ToList();
        }

        public List<Airport> FilterbyName(List<Airport> airports, string value)
        {
            return airports.Where(a => a.Name.CompareTo(value) > 0).ToList();
        }

        public List<Airport> FilterbyCode(List<Airport> airports, string value)
        {
            return airports.Where(a => a.Code.CompareTo(value) > 0).ToList();
        }

        public List<Airport> FilterbyLongitude(List<Airport> airports, float value)
        {
            return airports.Where(a => a.Longitude > value).ToList();
        }

        public List<Airport> FilterbyLatitude(List<Airport> airports, float value)
        {
            return airports.Where(a => a.Latitude > value).ToList();
        }

        public List<Airport> FilterbyAMSL(List<Airport> airports, float value)
        {
            return airports.Where(a => a.AMSL > value).ToList();
        }

        public List<Airport> FilterbyCountry(List<Airport> airports, string value)
        {
            return airports.Where(a => a.Country.CompareTo(value) > 0).ToList();
        }
    }

    public class AirportLessThanOperatorFilter : IAirportFilter
    {
        public List<Airport> FilterbyID(List<Airport> airports, ulong value)
        {
            return airports.Where(a => a.ID < value).ToList();
        }

        public List<Airport> FilterbyName(List<Airport> airports, string value)
        {
            return airports.Where(a => a.Name.CompareTo(value) < 0).ToList();
        }

        public List<Airport> FilterbyCode(List<Airport> airports, string value)
        {
            return airports.Where(a => a.Code.CompareTo(value) < 0).ToList();
        }

        public List<Airport> FilterbyLongitude(List<Airport> airports, float value)
        {
            return airports.Where(a => a.Longitude < value).ToList();
        }

        public List<Airport> FilterbyLatitude(List<Airport> airports, float value)
        {
            return airports.Where(a => a.Latitude < value).ToList();
        }

        public List<Airport> FilterbyAMSL(List<Airport> airports, float value)
        {
            return airports.Where(a => a.AMSL < value).ToList();
        }

        public List<Airport> FilterbyCountry(List<Airport> airports, string value)
        {
            return airports.Where(a => a.Country.CompareTo(value) < 0).ToList();
        }
    }

    public class AirportNotEqualsOperatorFilter : IAirportFilter
    {
        public List<Airport> FilterbyID(List<Airport> airports, ulong value)
        {
            return airports.Where(a => a.ID != value).ToList();
        }

        public List<Airport> FilterbyName(List<Airport> airports, string value)
        {
            return airports.Where(a => a.Name != value).ToList();
        }

        public List<Airport> FilterbyCode(List<Airport> airports, string value)
        {
            return airports.Where(a => a.Code != value).ToList();
        }

        public List<Airport> FilterbyLongitude(List<Airport> airports, float value)
        {
            return airports.Where(a => a.Longitude != value).ToList();
        }

        public List<Airport> FilterbyLatitude(List<Airport> airports, float value)
        {
            return airports.Where(a => a.Latitude != value).ToList();
        }

        public List<Airport> FilterbyAMSL(List<Airport> airports, float value)
        {
            return airports.Where(a => a.AMSL != value).ToList();
        }

        public List<Airport> FilterbyCountry(List<Airport> airports, string value)
        {
            return airports.Where(a => a.Country != value).ToList();
        }
    }
}
