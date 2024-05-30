using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flight_Project.Filters
{
    public interface IPassengerFilter
    {
        public List<Passenger> FilterbyName(List<Passenger> passengers, string name);
        public List<Passenger> FilterbyAge(List<Passenger> passengers, ulong age);
        public List<Passenger> FilterbyPhone(List<Passenger> passengers, string phone);
        public List<Passenger> FilterbyEmail(List<Passenger> passengers, string email);
        public List<Passenger> FilterbyClass(List<Passenger> passengers, string classProp);
        public List<Passenger> FilterbyMiles(List<Passenger> passengers, ulong miles);
        public List<Passenger> FilterbyID(List<Passenger> passengers, ulong id);
    }

    public class PassengerEqualsOperatorFilter : IPassengerFilter
    {
        public List<Passenger> FilterbyName(List<Passenger> passengers, string name)
        {
            return passengers.Where(p => p.Name == name).ToList();
        }

        public List<Passenger> FilterbyAge(List<Passenger> passengers, ulong age)
        {
            return passengers.Where(p => p.Age == age).ToList();
        }

        public List<Passenger> FilterbyPhone(List<Passenger> passengers, string phone)
        {
            return passengers.Where(p => p.Phone == phone).ToList();
        }

        public List<Passenger> FilterbyEmail(List<Passenger> passengers, string email)
        {
            return passengers.Where(p => p.Email == email).ToList();
        }

        public List<Passenger> FilterbyClass(List<Passenger> passengers, string classProp)
        {
            return passengers.Where(p => p.Class == classProp).ToList();
        }

        public List<Passenger> FilterbyMiles(List<Passenger> passengers, ulong miles)
        {
            return passengers.Where(p => p.Miles == miles).ToList();
        }

        public List<Passenger> FilterbyID(List<Passenger> passengers, ulong id)
        {
            return passengers.Where(p => p.ID == id).ToList();
        }
    }

    public class PassengerNotEqualsOperatorFilter : IPassengerFilter
    {
        public List<Passenger> FilterbyName(List<Passenger> passengers, string name)
        {
            return passengers.Where(p => p.Name != name).ToList();
        }

        public List<Passenger> FilterbyAge(List<Passenger> passengers, ulong age)
        {
            return passengers.Where(p => p.Age != age).ToList();
        }

        public List<Passenger> FilterbyPhone(List<Passenger> passengers, string phone)
        {
            return passengers.Where(p => p.Phone != phone).ToList();
        }

        public List<Passenger> FilterbyEmail(List<Passenger> passengers, string email)
        {
            return passengers.Where(p => p.Email != email).ToList();
        }

        public List<Passenger> FilterbyClass(List<Passenger> passengers, string classProp)
        {
            return passengers.Where(p => p.Class != classProp).ToList();
        }

        public List<Passenger> FilterbyMiles(List<Passenger> passengers, ulong miles)
        {
            return passengers.Where(p => p.Miles != miles).ToList();
        }

        public List<Passenger> FilterbyID(List<Passenger> passengers, ulong id)
        {
            return passengers.Where(p => p.ID != id).ToList();
        }
    }

    public class PassengerGreaterThanOperatorFilter : IPassengerFilter
    {
        public List<Passenger> FilterbyName(List<Passenger> passengers, string name)
        {
            return passengers.Where(p => string.Compare(p.Name, name) > 0).ToList();
        }

        public List<Passenger> FilterbyAge(List<Passenger> passengers, ulong age)
        {
            return passengers.Where(p => p.Age > age).ToList();
        }

        public List<Passenger> FilterbyPhone(List<Passenger> passengers, string phone)
        {
            return passengers.Where(p => string.Compare(p.Phone, phone) > 0).ToList();
        }

        public List<Passenger> FilterbyEmail(List<Passenger> passengers, string email)
        {
            return passengers.Where(p => string.Compare(p.Email, email) > 0).ToList();
        }

        public List<Passenger> FilterbyClass(List<Passenger> passengers, string classProp)
        {
            return passengers.Where(p => string.Compare(p.Class, classProp) > 0).ToList();
        }

        public List<Passenger> FilterbyMiles(List<Passenger> passengers, ulong miles)
        {
            return passengers.Where(p => p.Miles > miles).ToList();
        }

        public List<Passenger> FilterbyID(List<Passenger> passengers, ulong id)
        {
            return passengers.Where(p => p.ID > id).ToList();
        }
    }

    public class PassengerLessThanOperatorFilter : IPassengerFilter
    {
        public List<Passenger> FilterbyName(List<Passenger> passengers, string name)
        {
            return passengers.Where(p => string.Compare(p.Name, name) < 0).ToList();
        }

        public List<Passenger> FilterbyAge(List<Passenger> passengers, ulong age)
        {
            return passengers.Where(p => p.Age < age).ToList();
        }

        public List<Passenger> FilterbyPhone(List<Passenger> passengers, string phone)
        {
            return passengers.Where(p => string.Compare(p.Phone, phone) < 0).ToList();
        }

        public List<Passenger> FilterbyEmail(List<Passenger> passengers, string email)
        {
            return passengers.Where(p => string.Compare(p.Email, email) < 0).ToList();
        }

        public List<Passenger> FilterbyClass(List<Passenger> passengers, string classProp)
        {
            return passengers.Where(p => string.Compare(p.Class, classProp) < 0).ToList();
        }

        public List<Passenger> FilterbyMiles(List<Passenger> passengers, ulong miles)
        {
            return passengers.Where(p => p.Miles < miles).ToList();
        }

        public List<Passenger> FilterbyID(List<Passenger> passengers, ulong id)
        {
            return passengers.Where(p => p.ID < id).ToList();
        }
    }
}
