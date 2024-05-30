using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flight_Project.Filters
{
    public interface ICargoPlaneFilter
    {
        public List<CargoPlane> FilterbyID(List<CargoPlane> cargoPlanes, ulong value);
        public List<CargoPlane> FilterbyModel(List<CargoPlane> cargoPlanes, string value);
        public List<CargoPlane> FilterbyCountry(List<CargoPlane> cargoPlanes, string value);
        public List<CargoPlane> FilterbyMaxLoad(List<CargoPlane> cargoPlanes, float value);
        public List<CargoPlane> FilterbySerial(List<CargoPlane> cargoPlanes, string value);
    }

    public class CargoPlaneEqualsOperatorFilter : ICargoPlaneFilter
    {
        public List<CargoPlane> FilterbyID(List<CargoPlane> cargoPlanes, ulong value)
        {
            return cargoPlanes.Where(c => c.ID == value).ToList();
        }

        public List<CargoPlane> FilterbyModel(List<CargoPlane> cargoPlanes, string value)
        {
            return cargoPlanes.Where(c => c.Model == value).ToList();
        }

        public List<CargoPlane> FilterbyCountry(List<CargoPlane> cargoPlanes, string value)
        {
            return cargoPlanes.Where(c => c.Country == value).ToList();
        }

        public List<CargoPlane> FilterbyMaxLoad(List<CargoPlane> cargoPlanes, float value)
        {
            return cargoPlanes.Where(c => c.MaxLoad == value).ToList();
        }

        public List<CargoPlane> FilterbySerial(List<CargoPlane> cargoPlanes, string value)
        {
            return cargoPlanes.Where(c => c.Serial == value).ToList();
        }
    }

    public class CargoPlaneNotEqualsOperatorFilter : ICargoPlaneFilter
    {
        public List<CargoPlane> FilterbyID(List<CargoPlane> cargoPlanes, ulong value)
        {
            return cargoPlanes.Where(c => c.ID != value).ToList();
        }

        public List<CargoPlane> FilterbyModel(List<CargoPlane> cargoPlanes, string value)
        {
            return cargoPlanes.Where(c => c.Model != value).ToList();
        }

        public List<CargoPlane> FilterbyCountry(List<CargoPlane> cargoPlanes, string value)
        {
            return cargoPlanes.Where(c => c.Country != value).ToList();
        }

        public List<CargoPlane> FilterbyMaxLoad(List<CargoPlane> cargoPlanes, float value)
        {
            return cargoPlanes.Where(c => c.MaxLoad != value).ToList();
        }

        public List<CargoPlane> FilterbySerial(List<CargoPlane> cargoPlanes, string value)
        {
            return cargoPlanes.Where(c => c.Serial != value).ToList();
        }
    }

    public class CargoPlaneGreaterThanOperatorFilter : ICargoPlaneFilter
    {
        public List<CargoPlane> FilterbyID(List<CargoPlane> cargoPlanes, ulong value)
        {
            return cargoPlanes.Where(c => c.ID > value).ToList();
        }

        public List<CargoPlane> FilterbyModel(List<CargoPlane> cargoPlanes, string value)
        {
            return cargoPlanes.Where(c => c.Model.CompareTo(value) > 0).ToList();
        }

        public List<CargoPlane> FilterbyCountry(List<CargoPlane> cargoPlanes, string value)
        {
            return cargoPlanes.Where(c => c.Country.CompareTo(value) > 0).ToList();
        }

        public List<CargoPlane> FilterbyMaxLoad(List<CargoPlane> cargoPlanes, float value)
        {
            return cargoPlanes.Where(c => c.MaxLoad > value).ToList();
        }

        public List<CargoPlane> FilterbySerial(List<CargoPlane> cargoPlanes, string value)
        {
            return cargoPlanes.Where(c => c.Serial.CompareTo(value) > 0).ToList();
        }
    }

    public class CargoPlaneLessThanOperatorFilter : ICargoPlaneFilter
    {
        public List<CargoPlane> FilterbyID(List<CargoPlane> cargoPlanes, ulong value)
        {
            return cargoPlanes.Where(c => c.ID < value).ToList();
        }

        public List<CargoPlane> FilterbyModel(List<CargoPlane> cargoPlanes, string value)
        {
            return cargoPlanes.Where(c => c.Model.CompareTo(value) < 0).ToList();
        }

        public List<CargoPlane> FilterbyCountry(List<CargoPlane> cargoPlanes, string value)
        {
            return cargoPlanes.Where(c => c.Country.CompareTo(value) < 0).ToList();
        }

        public List<CargoPlane> FilterbyMaxLoad(List<CargoPlane> cargoPlanes, float value)
        {
            return cargoPlanes.Where(c => c.MaxLoad < value).ToList();
        }

        public List<CargoPlane> FilterbySerial(List<CargoPlane> cargoPlanes, string value)
        {
            return cargoPlanes.Where(c => c.Serial.CompareTo(value) < 0).ToList();
        }
    }
}
