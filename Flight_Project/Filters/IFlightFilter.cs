using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flight_Project.Filters
{
    public interface IFlightFilter
    {
        public List<Flight> FilterbyID(List<Flight> flights, ulong value);
        public List<Flight> FilterbyOrigin(List<Flight> flights, ulong value);
        public List<Flight> FilterbyTarget(List<Flight> flights, ulong value);
        public List<Flight> FilterbyTakeoffTime(List<Flight> flights, string value);
        public List<Flight> FilterbyLandingTime(List<Flight> flights, string value);
        public List<Flight> FilterbyLongitude(List<Flight> flights, float value);
        public List<Flight> FilterbyLatitude(List<Flight> flights, float value);
        public List<Flight> FilterbyAMSL(List<Flight> flights, float value);
        public List<Flight> FilterbyPlaneID(List<Flight> flights, ulong value);
    }

    public class FlightEqualsOperatorFilter : IFlightFilter
    {
        public List<Flight> FilterbyID(List<Flight> flights, ulong value)
        {
            return flights.Where(f => f.ID == value).ToList();
        }
        
        public List<Flight> FilterbyOrigin(List<Flight> flights, ulong value)
        {
            return flights.Where(f => f.Origin == value).ToList();
        }

        public List<Flight> FilterbyTarget(List<Flight> flights, ulong value)
        {
            return flights.Where(f => f.Target == value).ToList();
        }

        public List<Flight> FilterbyTakeoffTime(List<Flight> flights, string value)
        {
            return flights.Where(f => f.TakeoffTime == value).ToList();
        }

        public List<Flight> FilterbyLandingTime(List<Flight> flights, string value)
        {
            return flights.Where(f => f.LandingTime == value).ToList();
        }

        public List<Flight> FilterbyLongitude(List<Flight> flights, float value)
        {
            return flights.Where(f => f.Longitude == value).ToList();
        }

        public List<Flight> FilterbyLatitude(List<Flight> flights, float value)
        {
            return flights.Where(f => f.Latitude == value).ToList();
        }

        public List<Flight> FilterbyAMSL(List<Flight> flights, float value)
        {
            return flights.Where(f => f.AMSL == value).ToList();
        }

        public List<Flight> FilterbyPlaneID(List<Flight> flights, ulong value)
        {
            return flights.Where(f => f.PlaneID == value).ToList();
        }

    }

    public class FlightNotEqualsOperatorFilter : IFlightFilter
    {
        public List<Flight> FilterbyID(List<Flight> flights, ulong value)
        {
            return flights.Where(f => f.ID != value).ToList();
        }

        public List<Flight> FilterbyOrigin(List<Flight> flights, ulong value)
        {
            return flights.Where(f => f.Origin != value).ToList();
        }

        public List<Flight> FilterbyTarget(List<Flight> flights, ulong value)
        {
            return flights.Where(f => f.Target != value).ToList();
        }

        public List<Flight> FilterbyTakeoffTime(List<Flight> flights, string value)
        {
            return flights.Where(f => f.TakeoffTime != value).ToList();
        }

        public List<Flight> FilterbyLandingTime(List<Flight> flights, string value)
        {
            return flights.Where(f => f.LandingTime != value).ToList();
        }

        public List<Flight> FilterbyLongitude(List<Flight> flights, float value)
        {
            return flights.Where(f => f.Longitude != value).ToList();
        }

        public List<Flight> FilterbyLatitude(List<Flight> flights, float value)
        {
            return flights.Where(f => f.Latitude != value).ToList();
        }

        public List<Flight> FilterbyAMSL(List<Flight> flights, float value)
        {
            return flights.Where(f => f.AMSL != value).ToList();
        }

        public List<Flight> FilterbyPlaneID(List<Flight> flights, ulong value)
        {
            return flights.Where(f => f.PlaneID != value).ToList();
        }
    }

    public class FlightGreaterThanOperatorFilter : IFlightFilter
    {
        public List<Flight> FilterbyID(List<Flight> flights, ulong value)
        {
            return flights.Where(f => f.ID > value).ToList();
        }

        public List<Flight> FilterbyOrigin(List<Flight> flights, ulong value)
        {
            return flights.Where(f => f.Origin > value).ToList();
        }

        public List<Flight> FilterbyTarget(List<Flight> flights, ulong value)
        {
            return flights.Where(f => f.Target > value).ToList();
        }

        public List<Flight> FilterbyTakeoffTime(List<Flight> flights, string value)
        {
            return flights.Where(f => f.TakeoffTime.CompareTo(value) > 0).ToList();
        }

        public List<Flight> FilterbyLandingTime(List<Flight> flights, string value)
        {
            return flights.Where(f => f.LandingTime.CompareTo(value) > 0).ToList();
        }

        public List<Flight> FilterbyLongitude(List<Flight> flights, float value)
        {
            return flights.Where(f => f.Longitude > value).ToList();
        }

        public List<Flight> FilterbyLatitude(List<Flight> flights, float value)
        {
            return flights.Where(f => f.Latitude > value).ToList();
        }

        public List<Flight> FilterbyAMSL(List<Flight> flights, float value)
        {
            return flights.Where(f => f.AMSL > value).ToList();
        }

        public List<Flight> FilterbyPlaneID(List<Flight> flights, ulong value)
        {
            return flights.Where(f => f.PlaneID > value).ToList();
        }
    }

    public class FlightLessThanOperatorFilter : IFlightFilter
    {
        public List<Flight> FilterbyID(List<Flight> flights, ulong value)
        {
            return flights.Where(f => f.ID < value).ToList();
        }

        public List<Flight> FilterbyOrigin(List<Flight> flights, ulong value)
        {
            return flights.Where(f => f.Origin < value).ToList();
        }

        public List<Flight> FilterbyTarget(List<Flight> flights, ulong value)
        {
            return flights.Where(f => f.Target < value).ToList();
        }

        public List<Flight> FilterbyTakeoffTime(List<Flight> flights, string value)
        {
            return flights.Where(f => f.TakeoffTime.CompareTo(value) < 0).ToList();
        }

        public List<Flight> FilterbyLandingTime(List<Flight> flights, string value)
        {
            return flights.Where(f => f.LandingTime.CompareTo(value) < 0).ToList();
        }

        public List<Flight> FilterbyLongitude(List<Flight> flights, float value)
        {
            return flights.Where(f => f.Longitude < value).ToList();
        }

        public List<Flight> FilterbyLatitude(List<Flight> flights, float value)
        {
            return flights.Where(f => f.Latitude < value).ToList();
        }

        public List<Flight> FilterbyAMSL(List<Flight> flights, float value)
        {
            return flights.Where(f => f.AMSL < value).ToList();
        }

        public List<Flight> FilterbyPlaneID(List<Flight> flights, ulong value)
        {
            return flights.Where(f => f.PlaneID < value).ToList();
        }
    }
}
