using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flight_Project.Filters
{
    public interface IPassengerPlaneFilter
    {
        public List<PassengerPlane> FilterbyID(List<PassengerPlane> passengerPlanes, ulong value);
        public List<PassengerPlane> FilterbyModel(List<PassengerPlane> passengerPlanes, string value);
        public List<PassengerPlane> FilterbyCountry(List<PassengerPlane> passengerPlanes, string value);
        public List<PassengerPlane> FilterbyFirstClassSize(List<PassengerPlane> passengerPlanes, ushort value);
        public List<PassengerPlane> FilterbyBusinessClassSize(List<PassengerPlane> passengerPlanes, ushort value);
        public List<PassengerPlane> FilterbyEconomyClassSize(List<PassengerPlane> passengerPlanes, ushort value);
        public List<PassengerPlane> FilterbySerial(List<PassengerPlane> passengerPlanes, string value);
    }

    public class PassengerPlaneEqualsOperatorFilter : IPassengerPlaneFilter
    {
        public List<PassengerPlane> FilterbyID(List<PassengerPlane> passengerPlanes, ulong value)
        {
            return passengerPlanes.Where(p => p.ID == value).ToList();
        }

        public List<PassengerPlane> FilterbyModel(List<PassengerPlane> passengerPlanes, string value)
        {
            return passengerPlanes.Where(p => p.Model == value).ToList();
        }

        public List<PassengerPlane> FilterbyCountry(List<PassengerPlane> passengerPlanes, string value)
        {
            return passengerPlanes.Where(p => p.Country == value).ToList();
        }

        public List<PassengerPlane> FilterbyFirstClassSize(List<PassengerPlane> passengerPlanes, ushort value)
        {
            return passengerPlanes.Where(p => p.FirstClassSize == value).ToList();
        }

        public List<PassengerPlane> FilterbyBusinessClassSize(List<PassengerPlane> passengerPlanes, ushort value)
        {
            return passengerPlanes.Where(p => p.BusinessClassSize == value).ToList();
        }

        public List<PassengerPlane> FilterbyEconomyClassSize(List<PassengerPlane> passengerPlanes, ushort value)
        {
            return passengerPlanes.Where(p => p.EconomyClassSize == value).ToList();
        }

        public List<PassengerPlane> FilterbySerial(List<PassengerPlane> passengerPlanes, string value)
        {
            return passengerPlanes.Where(p => p.Serial == value).ToList();
        }
    }

    public class PassengerPlaneNotEqualsOperatorFilter : IPassengerPlaneFilter
    {
        public List<PassengerPlane> FilterbyID(List<PassengerPlane> passengerPlanes, ulong value)
        {
            return passengerPlanes.Where(p => p.ID != value).ToList();
        }

        public List<PassengerPlane> FilterbyModel(List<PassengerPlane> passengerPlanes, string value)
        {
            return passengerPlanes.Where(p => p.Model != value).ToList();
        }

        public List<PassengerPlane> FilterbyCountry(List<PassengerPlane> passengerPlanes, string value)
        {
            return passengerPlanes.Where(p => p.Country != value).ToList();
        }

        public List<PassengerPlane> FilterbyFirstClassSize(List<PassengerPlane> passengerPlanes, ushort value)
        {
            return passengerPlanes.Where(p => p.FirstClassSize != value).ToList();
        }

        public List<PassengerPlane> FilterbyBusinessClassSize(List<PassengerPlane> passengerPlanes, ushort value)
        {
            return passengerPlanes.Where(p => p.BusinessClassSize != value).ToList();
        }

        public List<PassengerPlane> FilterbyEconomyClassSize(List<PassengerPlane> passengerPlanes, ushort value)
        {
            return passengerPlanes.Where(p => p.EconomyClassSize != value).ToList();
        }

        public List<PassengerPlane> FilterbySerial(List<PassengerPlane> passengerPlanes, string value)
        {
            return passengerPlanes.Where(p => p.Serial != value).ToList();
        }
    }

    public class PassengerPlaneGreaterThanOperatorFilter : IPassengerPlaneFilter
    {
        public List<PassengerPlane> FilterbyID(List<PassengerPlane> passengerPlanes, ulong value)
        {
            return passengerPlanes.Where(p => p.ID > value).ToList();
        }

        public List<PassengerPlane> FilterbyModel(List<PassengerPlane> passengerPlanes, string value)
        {
            return passengerPlanes.Where(p => string.Compare(p.Model, value) > 0).ToList();
        }

        public List<PassengerPlane> FilterbyCountry(List<PassengerPlane> passengerPlanes, string value)
        {
            return passengerPlanes.Where(p => string.Compare(p.Country, value) > 0).ToList();
        }

        public List<PassengerPlane> FilterbyFirstClassSize(List<PassengerPlane> passengerPlanes, ushort value)
        {
            return passengerPlanes.Where(p => p.FirstClassSize > value).ToList();
        }

        public List<PassengerPlane> FilterbyBusinessClassSize(List<PassengerPlane> passengerPlanes, ushort value)
        {
            return passengerPlanes.Where(p => p.BusinessClassSize > value).ToList();
        }

        public List<PassengerPlane> FilterbyEconomyClassSize(List<PassengerPlane> passengerPlanes, ushort value)
        {
            return passengerPlanes.Where(p => p.EconomyClassSize > value).ToList();
        }

        public List<PassengerPlane> FilterbySerial(List<PassengerPlane> passengerPlanes, string value)
        {
            return passengerPlanes.Where(p => string.Compare(p.Serial, value) > 0).ToList();
        }
    }
    public class PassengerPlaneLessThanOperatorFilter : IPassengerPlaneFilter
    {
        public List<PassengerPlane> FilterbyID(List<PassengerPlane> passengerPlanes, ulong value)
        {
            return passengerPlanes.Where(p => p.ID < value).ToList();
        }

        public List<PassengerPlane> FilterbyModel(List<PassengerPlane> passengerPlanes, string value)
        {
            return passengerPlanes.Where(p => string.Compare(p.Model, value) < 0).ToList();
        }

        public List<PassengerPlane> FilterbyCountry(List<PassengerPlane> passengerPlanes, string value)
        {
            return passengerPlanes.Where(p => string.Compare(p.Country, value) < 0).ToList();
        }

        public List<PassengerPlane> FilterbyFirstClassSize(List<PassengerPlane> passengerPlanes, ushort value)
        {
            return passengerPlanes.Where(p => p.FirstClassSize < value).ToList();
        }

        public List<PassengerPlane> FilterbyBusinessClassSize(List<PassengerPlane> passengerPlanes, ushort value)
        {
            return passengerPlanes.Where(p => p.BusinessClassSize < value).ToList();
        }

        public List<PassengerPlane> FilterbyEconomyClassSize(List<PassengerPlane> passengerPlanes, ushort value)
        {
            return passengerPlanes.Where(p => p.EconomyClassSize < value).ToList();
        }

        public List<PassengerPlane> FilterbySerial(List<PassengerPlane> passengerPlanes, string value)
        {
            return passengerPlanes.Where(p => string.Compare(p.Serial, value) < 0).ToList();
        }
    }

}
