using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flight_Project.Filters
{
    public interface ICargoFilter
    {
        public List<Cargo> FilterbyID(List<Cargo> cargos, ulong value);
        public List<Cargo> FilterbyWeight(List<Cargo> cargos, float value);
        public List<Cargo> FilterbyCode(List<Cargo> cargos, string value);
        public List<Cargo> FilterbyDescription(List<Cargo> cargos, string value);
    }

    public class CargoEqualsOperatorFilter : ICargoFilter
    {
        public List<Cargo> FilterbyWeight(List<Cargo> cargos, float value)
        {
            return cargos.Where(c => c.Weight == value).ToList();
        }

        public List<Cargo> FilterbyCode(List<Cargo> cargos, string value)
        {
            return cargos.Where(c => c.Code == value).ToList();
        }

        public List<Cargo> FilterbyDescription(List<Cargo> cargos, string value)
        {
            return cargos.Where(c => c.Description.CompareTo(value) > 0).ToList();
        }

        public List<Cargo> FilterbyID(List<Cargo> cargos, ulong value)
        {
            return cargos.Where(c => c.ID == value).ToList();
        }
    }

    public class CargoGreaterThanOperatorFilter : ICargoFilter
    {
        public List<Cargo> FilterbyWeight(List<Cargo> cargos, float value)
        {
            return cargos.Where(c => c.Weight > value).ToList();
        }

        public List<Cargo> FilterbyCode(List<Cargo> cargos, string value)
        {
            return cargos.Where(c => c.Code.CompareTo(value) > 0).ToList();
        }

        public List<Cargo> FilterbyDescription(List<Cargo> cargos, string value)
        {
            return cargos.Where(c => c.Description.CompareTo(value) > 0).ToList();
        }

        public List<Cargo> FilterbyID(List<Cargo> cargos, ulong value)
        {
            return cargos.Where(c => c.ID > value).ToList();
        }
    }

    public class CargoLessThanOperatorFilter : ICargoFilter
    {
        public List<Cargo> FilterbyWeight(List<Cargo> cargos, float value)
        {
            return cargos.Where(c => c.Weight < value).ToList();
        }

        public List<Cargo> FilterbyCode(List<Cargo> cargos, string value)
        {
            return cargos.Where(c => c.Code.CompareTo(value) < 0).ToList();
        }

        public List<Cargo> FilterbyDescription(List<Cargo> cargos, string value)
        {
            return cargos.Where(c => c.Description.CompareTo(value) < 0).ToList();
        }

        public List<Cargo> FilterbyID(List<Cargo> cargos, ulong value)
        {
            return cargos.Where(c => c.ID < value).ToList();
        }
    }

    public class CargoNotEqualsOperatorFilter : ICargoFilter
    {
        public List<Cargo> FilterbyWeight(List<Cargo> cargos, float value)
        {
            return cargos.Where(c => c.Weight != value).ToList();
        }

        public List<Cargo> FilterbyCode(List<Cargo> cargos, string value)
        {
            return cargos.Where(c => c.Code != value).ToList();
        }

        public List<Cargo> FilterbyDescription(List<Cargo> cargos, string value)
        {
            return cargos.Where(c => c.Description.CompareTo(value) != 0).ToList();
        }

        public List<Cargo> FilterbyID(List<Cargo> cargos, ulong value)
        {
            return cargos.Where(c => c.ID != value).ToList();
        }
    }
}
