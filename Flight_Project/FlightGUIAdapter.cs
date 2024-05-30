using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightTrackerGUI;
using Mapsui.Projections;

namespace Flight_Project
{ 
    public class FlightGUIAdapter : FlightsGUIData
    {
        private static FlightGUIAdapter? instance;
        protected static List<Flight> includedFlights;
        public FlightGUIAdapter()
        {
            includedFlights = new List<Flight>();
        }

        public static FlightGUIAdapter Instance
        {
            get
            {
                instance ??= new FlightGUIAdapter();
                return instance;
            }
        }
        public override int GetFlightsCount()
        {
            return includedFlights.Count;
        }
        

        public override ulong GetID(int index)
        {
            var flight =  includedFlights[index];
            return flight.ID;
        }
        public void UpdateFlights()
        {
            while (true)
            {
                var data = new Dictionary<ulong, Flight>(Data.Flights);
                foreach (var flight in data)
                {
                    if(UpdatePosition(flight.Value))
                        includedFlights.Add(flight.Value);
                }
                Runner.UpdateGUI(this);
                includedFlights.Clear();
                Thread.Sleep(1000);
            }
        }
        protected virtual bool UpdatePosition(Flight flight)
        {

            var origin = Data.Airports[flight.Origin];
            var destination = Data.Airports[flight.Target];
            var takeoffTime = DateTime.Parse(flight.TakeoffTime);
            var landingTime = DateTime.Parse(flight.LandingTime);
            var currentTime = DateTime.Now;
            if (landingTime < takeoffTime)
                landingTime = landingTime.AddDays(1);

            if (currentTime <= takeoffTime)
            {
                flight.Latitude = origin.Latitude;
                flight.Longitude = origin.Longitude;
                return false;
            }
            if (currentTime >= landingTime)
            {
                flight.Latitude = destination.Latitude;
                flight.Longitude = destination.Longitude;
                return false;
            }

            var duration = (float)(landingTime - takeoffTime).TotalSeconds;
            var progress = (float)(currentTime - takeoffTime).TotalSeconds / duration;
            flight.Latitude = origin.Latitude + (destination.Latitude - origin.Latitude) * progress;
            flight.Longitude = origin.Longitude + (destination.Longitude - origin.Longitude) * progress;
            return true;
        }

        public override WorldPosition GetPosition(int index)
        {

            var flight = includedFlights[index];
            return new WorldPosition(flight.Latitude, flight.Longitude);
        }

        public override double GetRotation(int index)
        {
            var flight = includedFlights[index];
            var origin = Data.Airports[flight.Origin];
            var destination = Data.Airports[flight.Target]; 
            var coords = SphericalMercator.FromLonLat(destination.Longitude - origin.Longitude, 
                destination.Latitude - origin.Latitude); 
            var angle = Math.Atan2(coords.x, coords.y); 
            return angle;
        }
    }

    public class FightGUIAdapterDecorator : FlightGUIAdapter
    {
        protected override bool UpdatePosition(Flight flight)
        {
            if (flight.Longitude == float.MinValue)
            {
                return base.UpdatePosition(flight);
            }
            var origin = Data.Airports[flight.Origin];
            var destination = Data.Airports[flight.Target];
            var takeoffTime = DateTime.Parse(flight.TakeoffTime);
            var landingTime = DateTime.Parse(flight.LandingTime);
            var currentTime = DateTime.Now;
            if (landingTime < takeoffTime)
                landingTime = landingTime.AddDays(1);

            if (currentTime <= takeoffTime)
            {
                flight.Latitude = origin.Latitude;
                flight.Longitude = origin.Longitude;
                return false;
            }
            if (currentTime >= landingTime)
            {
                flight.Latitude = destination.Latitude;
                flight.Longitude = destination.Longitude;
                return false;
            }

            var remainingDistanceLat = destination.Latitude - flight.Latitude;
            var remainingDistanceLon = destination.Longitude - flight.Longitude;
            var remainingTime = (landingTime - currentTime).TotalSeconds;

            var speedLat = remainingDistanceLat / remainingTime;
            var speedLon = remainingDistanceLon / remainingTime;

            flight.Latitude += (float)speedLat;
            flight.Longitude += (float)speedLon;

            return true;
        }

        public override double GetRotation(int index)
        {
            var flight = includedFlights[index];
            var current = new { Latitude = flight.Latitude, Longitude = flight.Longitude };
            var destination = Data.Airports[flight.Target];
            var coords = SphericalMercator.FromLonLat(destination.Longitude - current.Longitude, 
                destination.Latitude - current.Latitude);
            var angle = Math.Atan2(coords.x, coords.y); 

            return angle;
        }

    }
}
