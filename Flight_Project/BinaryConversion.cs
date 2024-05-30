using System.ComponentModel;
using System.Text;

namespace Flight_Project
{
    public delegate Entity BinaryConversion(byte[] data);
    public static class BinaryConversions
    {
        public static Entity CrewConversion(byte[] message)
        {
            int index = 0;
            string code = Encoding.ASCII.GetString(message, index, 3);
            index += 3;

            string messageLength = BitConverter.ToUInt32(message, index).ToString();
            index += 4;

            ulong id = BitConverter.ToUInt64(message, index);
            index += 8;

            ushort nameLength = BitConverter.ToUInt16(message, index);
            index += 2;

            string name = Encoding.ASCII.GetString(message, index, nameLength);
            index += nameLength;

            ushort age = BitConverter.ToUInt16(message, index);
            index += 2;

            string phoneNumber = Encoding.ASCII.GetString(message, index, 12);
            index += 12;

            ushort emailLength = BitConverter.ToUInt16(message, index);
            index += 2;

            string emailAddress = Encoding.ASCII.GetString(message, index, emailLength);
            index += emailLength;

            ushort practice = BitConverter.ToUInt16(message, index);
            index += 2;

            string role = Encoding.ASCII.GetString(message, index, 1);
            var crew = new Crew(id, name, age, phoneNumber, emailAddress, practice, role);
            Data.Crews.TryAdd(id, crew);
            Data.AllEntities.TryAdd(id, crew);
            return crew;
        }
        public static Entity PassengerConversion(byte[] message)
        {
            int index = 0;
            string code = Encoding.ASCII.GetString(message, index, 3);
            index += 3;

            uint messageLength = BitConverter.ToUInt32(message, index);
            index += 4;

            ulong id = BitConverter.ToUInt64(message, index);
            index += 8;

            ushort nameLength = BitConverter.ToUInt16(message, index);
            index += 2;

            string name = Encoding.ASCII.GetString(message, index, nameLength);
            index += nameLength;

            ushort age = BitConverter.ToUInt16(message, index);
            index += 2;

            string phoneNumber = Encoding.ASCII.GetString(message, index, 12);
            index += 12;

            ushort emailLength = BitConverter.ToUInt16(message, index);
            index += 2;

            string emailAddress = Encoding.ASCII.GetString(message, index, emailLength);
            index += emailLength;

            string classType = Encoding.ASCII.GetString(message, index, 1);
            index += 1;

            ulong miles = BitConverter.ToUInt64(message, index);
            var passenger = new Passenger(id, name, age, phoneNumber, emailAddress, classType, miles);
            Data.Passengers.TryAdd(id, passenger);
            Data.AllEntities.TryAdd(id, passenger);
            return passenger;
        }

        public static Entity CargoConversion(byte[] message)
        {
            int index = 0;
            string code = Encoding.ASCII.GetString(message, index, 3); 
            index += 3;

            uint messageLength = BitConverter.ToUInt32(message, index); 
            index += 4;

            ulong id = BitConverter.ToUInt64(message, index); 
            index += 8;

            float weight = BitConverter.ToSingle(message, index); 
            index += 4;

            string cargoCode = Encoding.ASCII.GetString(message, index, 6); 
            index += 6;

            ushort descriptionLength = BitConverter.ToUInt16(message, index);
            index += 2;

            string description = Encoding.ASCII.GetString(message, index, descriptionLength);

            var cargo = new Cargo(id, weight, cargoCode, description);
            Data.Cargoes.TryAdd(id, cargo);
            Data.AllEntities.TryAdd(id, cargo);
            return cargo;
        }
        public static Entity CargoPlaneConversion(byte[] message)
        {
            int index = 0;
            string code = Encoding.ASCII.GetString(message, index, 3); 
            index += 3;

            uint messageLength = BitConverter.ToUInt32(message, index);
            index += 4;

            ulong id = BitConverter.ToUInt64(message, index);
            index += 8;

            string serial = Encoding.ASCII.GetString(message, index, 10); 
            index += 10;

            string isoCountryCode = Encoding.ASCII.GetString(message, index, 3); 
            index += 3;

            ushort modelLength = BitConverter.ToUInt16(message, index);
            index += 2;

            string model = Encoding.ASCII.GetString(message, index, modelLength); 
            index += modelLength;

            float maxLoad = BitConverter.ToSingle(message, index);

            var cargoPlane = new CargoPlane(id, serial, isoCountryCode, model, maxLoad);
            Data.CargoPlanes.TryAdd(id, cargoPlane);
            Data.AllEntities.TryAdd(id, cargoPlane);
            return cargoPlane;
        }

        public static Entity PassengerPlaneConversion(byte[] message)
        {
            int index = 0;
            string code = Encoding.ASCII.GetString(message, index, 3);
            index += 3;

            uint messageLength = BitConverter.ToUInt32(message, index);
            index += 4;

            ulong id = BitConverter.ToUInt64(message, index); 
            index += 8;

            string serial = Encoding.ASCII.GetString(message, index, 10); 
            index += 10;

            string isoCountryCode = Encoding.ASCII.GetString(message, index, 3); 
            index += 3;

            ushort modelLength = BitConverter.ToUInt16(message, index); 
            index += 2;

            string model = Encoding.ASCII.GetString(message, index, modelLength); 
            index += modelLength;

            ushort firstClassSize = BitConverter.ToUInt16(message, index); 
            index += 2;

            ushort businessClassSize = BitConverter.ToUInt16(message, index); 
            index += 2;

            ushort economyClassSize = BitConverter.ToUInt16(message, index); 

            var passengerPlane = new PassengerPlane(id, serial, isoCountryCode, model, firstClassSize, businessClassSize, economyClassSize);
            Data.PassengerPlanes.TryAdd(id, passengerPlane);
            Data.AllEntities.TryAdd(id, passengerPlane);
            return passengerPlane;

        }
        public static Entity AirportConversion(byte[] message)
        {
            int index = 0;
            string code = Encoding.ASCII.GetString(message, index, 3); 
            index += 3;

            string messageLength = BitConverter.ToUInt32(message, index).ToString(); 
            index += 4;

            ulong id = BitConverter.ToUInt64(message, index); 
            index += 8;

            ushort nameLength = BitConverter.ToUInt16(message, index); 
            index += 2;

            string name = Encoding.ASCII.GetString(message, index, nameLength); 
            index += nameLength;

            string airportCode = Encoding.ASCII.GetString(message, index, 3); 
            index += 3;

            float longitude = BitConverter.ToSingle(message, index); 
            index += 4;

            float latitude = BitConverter.ToSingle(message, index); 
            index += 4;

            float amsl = BitConverter.ToSingle(message, index); 
            index += 4;

            string isoCountryCode = Encoding.ASCII.GetString(message, index, 3);

            var airport = new Airport(id, name, airportCode, longitude, latitude, amsl, isoCountryCode);
            Data.Airports.TryAdd(id, airport);
            Data.AllEntities.TryAdd(id, airport);
            return airport;
        }

        public static Entity FlightConversion(byte[] message)
        {
            int index = 0;
            string code = Encoding.ASCII.GetString(message, index, 3); 
            index += 3;

            uint messageLength = BitConverter.ToUInt32(message, index);
            index += 4;

            ulong id = BitConverter.ToUInt64(message, index); 
            index += 8;

            ulong originId = BitConverter.ToUInt64(message, index); 
            index += 8;

            ulong targetId = BitConverter.ToUInt64(message, index); 
            index += 8;

            long epochtakeoffTime = BitConverter.ToInt64(message, index);
            string takeoffTime = DateTimeOffset.FromUnixTimeMilliseconds(epochtakeoffTime).TimeOfDay.ToString();
            index += 8;

            long epochlandingTime = BitConverter.ToInt64(message, index);
            string landingTime = DateTimeOffset.FromUnixTimeMilliseconds(epochlandingTime).TimeOfDay.ToString();

            index += 8;

            ulong planeId = BitConverter.ToUInt64(message, index); 
            index += 8;

            ushort crewCount = BitConverter.ToUInt16(message, index); 
            index += 2;

            Dictionary<ulong,Crew> crew = new();
            for (int i = 0; i < crewCount; i++)
            {
                var crewid = BitConverter.ToUInt64(message, index);
                crew.Add(crewid,Data.Crews[crewid]);
                index += 8;
            }
            ushort passengersCargoCount = BitConverter.ToUInt16(message, index); 
            index += 2;

            Dictionary<ulong, Cargo> passengersCargo = new();
            for (int i = 0; i < passengersCargoCount; i++)
            {
                var cargoid = BitConverter.ToUInt64(message, index);
                passengersCargo.Add(cargoid,Data.Cargoes[cargoid]);
                index += 8;
            }

            var flight = new Flight(id, originId, targetId, takeoffTime, landingTime, float.MinValue, float.MinValue, float.MinValue, planeId, crew, passengersCargo);
            Data.Flights.TryAdd(id, flight);
            Data.AllEntities.TryAdd(id, flight);
            return flight;
        }




    }
}
