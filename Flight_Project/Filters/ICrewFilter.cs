
namespace Flight_Project.Filters
{
    public interface ICrewFilter
    {
        public List<Crew> FilterbyID(List<Crew> crews, ulong value);
        public List<Crew> FilterbyName(List<Crew> crews, string value);
        public List<Crew> FilterbyAge(List<Crew> crews, ulong value);
        public List<Crew> FilterbyPhone(List<Crew> crews, string value);

        public List<Crew> FilterbyEmail(List<Crew> crews, string value);

        public List<Crew> FilterbyPractice(List<Crew> crews, ulong value);
        public List<Crew> FilterbyRole(List<Crew> crews, string value);

    }
    public class CrewEqualsOperatorFilter : ICrewFilter
    {
        public List<Crew> FilterbyID(List<Crew> crews, ulong value)
        {
            return crews.Where(c => c.ID == value).ToList();
        }
        
        public List<Crew> FilterbyName(List<Crew> crews, string value)
        {
            return crews.Where(c => c.Name == value).ToList();
        }

        public List<Crew> FilterbyAge(List<Crew> crews, ulong value)
        {
            var filtered = crews.Where(c => c.Age == value).ToList();
            return filtered;
        }

        public List<Crew> FilterbyPhone(List<Crew> crews, string value)
        {
            return crews.Where(c => c.Phone == value).ToList();
        }

        public List<Crew> FilterbyEmail(List<Crew> crews, string value)
        {
            return crews.Where(c => c.Email == value).ToList();
        }

        public List<Crew> FilterbyPractice(List<Crew> crews, ulong value)
        {
            return crews.Where(c => c.Practice == value).ToList();
        }

        public List<Crew> FilterbyRole(List<Crew> crews, string value)
        {
            return crews.Where(c => c.Role == value).ToList();
        }

    }

    public class CrewNotEqualsOperatorFilter : ICrewFilter
    {
        public List<Crew> FilterbyID(List<Crew> crews, ulong value)
        {
            return crews.Where(c => c.ID != value).ToList();
        }

        public List<Crew> FilterbyName(List<Crew> crews, string value)
        {
            return crews.Where(c => c.Name != value).ToList();
        }

        public List<Crew> FilterbyAge(List<Crew> crews, ulong value)
        {
            return crews.Where(c => c.Age != value).ToList();
        }

        public List<Crew> FilterbyPhone(List<Crew> crews, string value)
        {
            return crews.Where(c => c.Phone != value).ToList();
        }

        public List<Crew> FilterbyEmail(List<Crew> crews, string value)
        {
            return crews.Where(c => c.Email != value).ToList();
        }

        public List<Crew> FilterbyPractice(List<Crew> crews, ulong value)
        {
            return crews.Where(c => c.Practice != value).ToList();
        }

        public List<Crew> FilterbyRole(List<Crew> crews, string value)
        {
            return crews.Where(c => c.Role != value).ToList();
        }

    }

    public class CrewGreaterThanOperatorFilter : ICrewFilter
    {
        public List<Crew> FilterbyID(List<Crew> crews, ulong value)
        {
            return crews.Where(c => c.ID > value).ToList();
        }

        public List<Crew> FilterbyName(List<Crew> crews, string value)
        {
            return crews.Where(c => c.Name.Length > value.Length).ToList();
        }

        public List<Crew> FilterbyAge(List<Crew> crews, ulong value)
        {
            return crews.Where(c => c.Age > value).ToList();
        }

        public List<Crew> FilterbyPhone(List<Crew> crews, string value)
        {
            return crews.Where(c => c.Phone.Length > value.Length).ToList();
        }

        public List<Crew> FilterbyEmail(List<Crew> crews, string value)
        {
            return crews.Where(c => c.Email.Length > value.Length).ToList();
        }

        public List<Crew> FilterbyPractice(List<Crew> crews, ulong value)
        {
            return crews.Where(c => c.Practice > value).ToList();
        }

        public List<Crew> FilterbyRole(List<Crew> crews, string value)
        {
            return crews.Where(c => c.Role.Length > value.Length).ToList();
        }

    }

    public class CrewLessThanOperatorFilter : ICrewFilter
    {
        public List<Crew> FilterbyID(List<Crew> crews, ulong value)
        {
            return crews.Where(c => c.ID < value).ToList();
        }

        public List<Crew> FilterbyName(List<Crew> crews, string value)
        {
            return crews.Where(c => c.Name.Length < value.Length).ToList();
        }

        public List<Crew> FilterbyAge(List<Crew> crews, ulong value)
        {
            return crews.Where(c => c.Age < value).ToList();
        }

        public List<Crew> FilterbyPhone(List<Crew> crews, string value)
        {
            return crews.Where(c => c.Phone.Length < value.Length).ToList();
        }

        public List<Crew> FilterbyEmail(List<Crew> crews, string value)
        {
            return crews.Where(c => c.Email.Length < value.Length).ToList();
        }

        public List<Crew> FilterbyPractice(List<Crew> crews, ulong value)
        {
            return crews.Where(c => c.Practice < value).ToList();
        }

        public List<Crew> FilterbyRole(List<Crew> crews, string value)
        {
            return crews.Where(c => c.Role.Length < value.Length).ToList();
        }
    }
}
