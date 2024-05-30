using System.Text;
using Flight_Project.Filters;
using NetworkSourceSimulator;

namespace Flight_Project
{
    public interface ICommandInterpreter
    {

        void InterpretCommand(string[] commandParts);
    }

    public class DisplayCommandInterpreter : ICommandInterpreter
    {
        private List<Entity> allEntities = null;
        private List<Crew> allCrews { get; set; }
        private List<Airport> allAirports = null;
        private List<Flight> allFlights = null;
        private List<Passenger> allPassengers = null;
        private List<Cargo> allCargoes = null;
        private List<CargoPlane> allCargoPlanes = null;
        private List<PassengerPlane> allPassengerPlanes = null;
        public void InterpretCommand(string[] commandParts)
        {
            ConditionsInterpreter conditionsInterpreter = new ConditionsInterpreter();
            ResultInterpreter resultInterpreter = new ResultInterpreter();
            switch (commandParts[3])
            {
                case "Crew":
                    allCrews = conditionsInterpreter.FilterCrews(commandParts, 5);
                    resultInterpreter.DisplayCrewFields(commandParts[1].Split(',').ToList(), allCrews);
                    break;
                case "Airport":
                    allAirports = conditionsInterpreter.FilterAirports(commandParts, 5);
                    resultInterpreter.DisplayAirportFields(commandParts[1].Split(',').ToList(), allAirports);
                    break;
                case "Flight":
                    allFlights = conditionsInterpreter.FilterFlights(commandParts, 5);
                    resultInterpreter.DisplayFlightFields(commandParts[1].Split(',').ToList(), allFlights);
                    break;
                case "Passenger":
                    allPassengers = conditionsInterpreter.FilterPassengers(commandParts, 5);
                    resultInterpreter.DisplayPassengerFields(commandParts[1].Split(',').ToList(), allPassengers);
                    break;
                case "Cargo":
                    allCargoes = conditionsInterpreter.FilterCargoes(commandParts, 5);
                    resultInterpreter.DisplayCargoFields(commandParts[1].Split(',').ToList(), allCargoes);
                    break;
                case "CargoPlane":
                    allCargoPlanes = conditionsInterpreter.FilterCargoPlanes(commandParts, 5);
                    resultInterpreter.DisplayCargoPlaneFields(commandParts[1].Split(',').ToList(), allCargoPlanes);
                    break;
                case "PassengerPlane":
                    allPassengerPlanes = conditionsInterpreter.FilterPassengerPlanes(commandParts, 5);
                    resultInterpreter.DisplayPassengerPlaneFields(commandParts[1].Split(',').ToList(),
                        allPassengerPlanes);
                    break;
            }
        }
    }

    public class UpdateCommandInterpreter : ICommandInterpreter
    {
        private List<Entity> allEntities = null;
        private List<Crew> allCrews { get; set; }
        private List<Airport> allAirports = null;
        private List<Flight> allFlights = null;
        private List<Passenger> allPassengers = null;
        private List<Cargo> allCargoes = null;
        private List<CargoPlane> allCargoPlanes = null;
        private List<PassengerPlane> allPassengerPlanes = null;
        public void InterpretCommand(string[] commandParts)
        {
            ConditionsInterpreter conditionsInterpreter = new ConditionsInterpreter();
            ResultInterpreter resultInterpreter = new ResultInterpreter();
            switch (commandParts[1])
            {
                case "Crew":
                    allCrews = conditionsInterpreter.FilterCrews(commandParts, 5);
                    resultInterpreter.UpdateCrews(allCrews,commandParts[3]);
                    break;
                case "Airport":
                    allAirports = conditionsInterpreter.FilterAirports(commandParts, 5);
                    resultInterpreter.UpdateAirports(allAirports,commandParts[3]);
                    break;
                case "Flight":
                    allFlights = conditionsInterpreter.FilterFlights(commandParts, 5);
                    resultInterpreter.UpdateFlights( allFlights,commandParts[3]);
                    break;
                case "Passenger":
                    allPassengers = conditionsInterpreter.FilterPassengers(commandParts, 5);
                    resultInterpreter.UpdatePassengers(allPassengers,commandParts[3]);
                    break;
                case "Cargo":
                    allCargoes = conditionsInterpreter.FilterCargoes(commandParts, 5);
                    resultInterpreter.DisplayCargoFields(commandParts[1].Split(',').ToList(), allCargoes);
                    break;
                case "CargoPlane":
                    allCargoPlanes = conditionsInterpreter.FilterCargoPlanes(commandParts, 5);
                    resultInterpreter.DisplayCargoPlaneFields(commandParts[1].Split(',').ToList(), allCargoPlanes);
                    break;
                case "PassengerPlane":
                    allPassengerPlanes = conditionsInterpreter.FilterPassengerPlanes(commandParts, 5);
                    resultInterpreter.DisplayPassengerPlaneFields(commandParts[1].Split(',').ToList(),
                        allPassengerPlanes);
                    break;
            }
        }
    }

    public class AddCommandInterpreter : ICommandInterpreter
    {
        public void InterpretCommand(string[] commandParts)
        {
            var selectedClass = commandParts[1];
            var arguments = commandParts.Skip(2).ToArray();
            if (HelperMethods.ClassesNames.Contains(selectedClass))
            {
                var entity = Constants.FactoryDictionary[selectedClass](arguments);
            }
            else
            {
                Console.WriteLine("Invalid class name. Please try again.");
            }
        }
    }

    public class DeleteCommandInterpreter : ICommandInterpreter
    {
        private List<Entity> allEntities = null;
        private List<Crew> allCrews { get; set; }
        private List<Airport> allAirports = null;
        private List<Flight> allFlights = null;
        private List<Passenger> allPassengers = null;
        private List<Cargo> allCargoes = null;
        private List<CargoPlane> allCargoPlanes = null;
        private List<PassengerPlane> allPassengerPlanes = null;

        public void InterpretCommand(string[] commandParts)
        {
            ConditionsInterpreter conditionsInterpreter = new ConditionsInterpreter();
            ResultInterpreter resultInterpreter = new ResultInterpreter();
            switch (commandParts[1])
            {
                case "Crew":
                    allCrews = conditionsInterpreter.FilterCrews(commandParts, 3);
                    resultInterpreter.DeleteCrews( allCrews);
                    break;
                case "Airport":
                    allAirports = conditionsInterpreter.FilterAirports(commandParts, 3);
                    resultInterpreter.DeleteAirports(allAirports);
                    break;
                case "Flight":
                    allFlights = conditionsInterpreter.FilterFlights(commandParts, 3);
                    resultInterpreter.DeleteFlights(allFlights);
                    break;
                case "Passenger":
                    allPassengers = conditionsInterpreter.FilterPassengers(commandParts, 3);
                    resultInterpreter.DeletePassengers(allPassengers);
                    break;
                case "Cargo":
                    allCargoes = conditionsInterpreter.FilterCargoes(commandParts, 3);
                    resultInterpreter.DeleteCargoes(allCargoes);
                    break;
                case "CargoPlane":
                    allCargoPlanes = conditionsInterpreter.FilterCargoPlanes(commandParts, 3);
                    resultInterpreter.DeleteCargoPlanes(allCargoPlanes);
                    break;
                case "PassengerPlane":
                    allPassengerPlanes = conditionsInterpreter.FilterPassengerPlanes(commandParts, 3);
                    resultInterpreter.DeletePassengerPlanes( allPassengerPlanes);
                    break;
            }
        }
    }

    public class ResultInterpreter
    {
        public void DisplayCrewFields(List<string> fields, List<Crew> crews)
        {
            try
            {
                Dictionary<string, int> fieldLengths = new Dictionary<string, int>()
                {
                    { "ID", 0 },
                    { "Name", 0 },
                    { "Age", 0 },
                    { "Phone", 0 },
                    { "Email", 0 },
                    { "Practice", 0 },
                    { "Role", 0 }
                };
                if (fields.Count == 1 && fields[0] == "*")
                {
                    fields = HelperMethods.CrewFields.Keys.ToList();
                }

                foreach (var field in fields)
                {
                    switch (field)
                    {
                        case "ID":
                            fieldLengths[field] = Math.Max(field.Length, crews.Max(c => c.ID).ToString().Length);
                            break;
                        case "Name":
                            fieldLengths[field] = Math.Max(field.Length, crews.Max(c => c.Name.Length));
                            break;
                        case "Age":
                            fieldLengths[field] = Math.Max(field.Length, crews.Max(c => c.Age.ToString().Length));
                            break;
                        case "Phone":
                            fieldLengths[field] = Math.Max(field.Length, crews.Max(c => c.Phone.Length));
                            break;
                        case "Email":
                            fieldLengths[field] = Math.Max(field.Length, crews.Max(c => c.Email.Length));
                            break;
                        case "Practice":
                            fieldLengths[field] = Math.Max(field.Length, crews.Max(c => c.Practice.ToString().Length));
                            break;
                        case "Role":
                            fieldLengths[field] = Math.Max(field.Length, crews.Max(c => c.Role.Length));
                            break;
                    }
                }

                var sb = new StringBuilder();
                foreach (var field in fields)
                {
                    sb.Append(field.PadRight(fieldLengths[field] + 1) + "|");
                }

                sb.Remove(sb.Length - 1, 1);
                sb.Append("\n");

                foreach (var field in fields)
                {
                    sb.Append(new string('-', fieldLengths[field] + 1) + "+");
                }

                sb.Remove(sb.Length - 1, 1);
                sb.Append("\n");
                foreach (var crew in crews)
                {
                    foreach (var field in fields)
                    {
                        switch (field)
                        {
                            case "ID":
                                sb.Append(crew.ID.ToString().PadLeft(fieldLengths[field] + 1) + "|");
                                break;
                            case "Name":
                                sb.Append(crew.Name.PadLeft(fieldLengths[field] + 1) + "|");
                                break;
                            case "Age":
                                sb.Append(crew.Age.ToString().PadLeft(fieldLengths[field] + 1) + "|");
                                break;
                            case "Phone":
                                sb.Append(crew.Phone.PadLeft(fieldLengths[field] + 1) + "|");
                                break;
                            case "Email":
                                sb.Append(crew.Email.PadLeft(fieldLengths[field] + 1) + "|");
                                break;
                            case "Practice":
                                sb.Append(crew.Practice.ToString().PadLeft(fieldLengths[field] + 1) + "|");
                                break;
                            case "Role":
                                sb.Append(crew.Role.PadLeft(fieldLengths[field] + 1) + "|");
                                break;
                        }
                    }

                    sb.Remove(sb.Length - 1, 1);
                    sb.Append("\n");
                }

                Console.WriteLine(sb);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void DisplayAirportFields(List<string> fields, List<Airport> airports)
        {
            try
            {
                Dictionary<string, int> fieldLengths = new Dictionary<string, int>()
                {
                    { "ID", 0 },
                    { "Name", 0 },
                    { "Code", 0 },
                    { "Longitude", 0 },
                    { "Latitude", 0 },
                    { "AMSL", 0 },
                    { "Country", 0 }
                };
                if (fields.Count == 1 && fields[0] == "*")
                {
                    fields = HelperMethods.AirportFields.Keys.ToList();
                }

                foreach (var field in fields)
                {
                    switch (field)
                    {
                        case "ID":
                            fieldLengths[field] = Math.Max(field.Length, airports.Max(a => a.ID).ToString().Length);
                            break;
                        case "Name":
                            fieldLengths[field] = Math.Max(field.Length, airports.Max(a => a.Name.Length));
                            break;
                        case "Code":
                            fieldLengths[field] = Math.Max(field.Length, airports.Max(a => a.Code.Length));
                            break;
                        case "Longitude":
                            fieldLengths[field] = Math.Max(field.Length,
                                airports.Max(a => a.Longitude.ToString().Length));
                            break;
                        case "Latitude":
                            fieldLengths[field] =
                                Math.Max(field.Length, airports.Max(a => a.Latitude.ToString().Length));
                            break;
                        case "AMSL":
                            fieldLengths[field] = Math.Max(field.Length, airports.Max(a => a.AMSL.ToString().Length));
                            break;
                        case "Country":
                            fieldLengths[field] = Math.Max(field.Length, airports.Max(a => a.Country.Length));
                            break;
                    }
                }

                var sb = new StringBuilder();
                foreach (var field in fields)
                {
                    sb.Append(field.PadRight(fieldLengths[field] + 1) + "|");
                }

                sb.Remove(sb.Length - 1, 1);
                sb.Append("\n");

                foreach (var field in fields)
                {
                    sb.Append(new string('-', fieldLengths[field] + 1) + "+");
                }

                sb.Remove(sb.Length - 1, 1);
                sb.Append("\n");
                foreach (var airport in airports)
                {
                    foreach (var field in fields)
                    {
                        switch (field)
                        {
                            case "ID":
                                sb.Append(airport.ID.ToString().PadLeft(fieldLengths[field] + 1) + "|");
                                break;
                            case "Name":
                                sb.Append(airport.Name.PadRight(fieldLengths[field] + 1) + "|");
                                break;
                            case "Code":
                                sb.Append(airport.Code.PadLeft(fieldLengths[field] + 1) + "|");
                                break;
                            case "Longitude":
                                sb.Append(airport.Longitude.ToString().PadLeft(fieldLengths[field] + 1) + "|");
                                break;
                            case "Latitude":
                                sb.Append(airport.Latitude.ToString().PadLeft(fieldLengths[field] + 1) + "|");
                                break;
                            case "AMSL":
                                sb.Append(airport.AMSL.ToString().PadLeft(fieldLengths[field] + 1) + "|");
                                break;
                            case "Country":
                                sb.Append(airport.Country.PadLeft(fieldLengths[field] + 1) + "|");
                                break;
                        }
                    }

                    sb.Remove(sb.Length - 1, 1);
                    sb.Append("\n");
                }

                Console.WriteLine(sb);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void DisplayFlightFields(List<string> fields, List<Flight> flights)
        {
            try
            {
                Dictionary<string, int> fieldLengths = new Dictionary<string, int>()
                {
                    { "ID", 0 },
                    { "Origin", 0 },
                    { "Target", 0 },
                    { "TakeoffTime", 0 },
                    { "LandingTime", 0 },
                    { "Longitude", 0 },
                    { "Latitude", 0 },
                    { "AMSL", 0 },
                    { "PlaneID", 0 }
                };
                if (fields.Count == 1 && fields[0] == "*")
                {
                    fields = HelperMethods.FlightFields.Keys.ToList();
                }

                foreach (var field in fields)
                {
                    switch (field)
                    {
                        case "ID":
                            fieldLengths[field] = Math.Max(field.Length, flights.Max(f => f.ID).ToString().Length);
                            break;
                        case "Origin":
                            fieldLengths[field] = Math.Max(field.Length, flights.Max(f => f.Origin.ToString().Length));
                            break;
                        case "Target":
                            fieldLengths[field] = Math.Max(field.Length, flights.Max(f => f.Target.ToString().Length));
                            break;
                        case "TakeoffTime":
                            fieldLengths[field] = Math.Max(field.Length, flights.Max(f => f.TakeoffTime.Length));
                            break;
                        case "LandingTime":
                            fieldLengths[field] = Math.Max(field.Length, flights.Max(f => f.LandingTime.Length));
                            break;
                        case "Longitude":
                            fieldLengths[field] =
                                Math.Max(field.Length, flights.Max(f => f.Longitude.ToString().Length));
                            break;
                        case "Latitude":
                            fieldLengths[field] =
                                Math.Max(field.Length, flights.Max(f => f.Latitude.ToString().Length));
                            break;
                        case "AMSL":
                            fieldLengths[field] = Math.Max(field.Length, flights.Max(f => f.AMSL.ToString().Length));
                            break;
                        case "PlaneID":
                            fieldLengths[field] = Math.Max(field.Length, flights.Max(f => f.PlaneID.ToString().Length));
                            break;
                    }
                }

                var sb = new StringBuilder();
                foreach (var field in fields)
                {
                    sb.Append(field.PadRight(fieldLengths[field] + 1) + "|");
                }

                sb.Remove(sb.Length - 1, 1);
                sb.Append("\n");

                foreach (var field in fields)
                {
                    sb.Append(new string('-', fieldLengths[field] + 1) + "+");
                }

                sb.Remove(sb.Length - 1, 1);
                sb.Append("\n");
                foreach (var flight in flights)
                {
                    foreach (var field in fields)
                    {
                        switch (field)
                        {
                            case "ID":
                                sb.Append(flight.ID.ToString().PadLeft(fieldLengths[field] + 1) + "|");
                                break;
                            case "Origin":
                                sb.Append(flight.Origin.ToString().PadRight(fieldLengths[field] + 1) + "|");
                                break;
                            case "Target":
                                sb.Append(flight.Target.ToString().PadLeft(fieldLengths[field] + 1) + "|");
                                break;
                            case "TakeoffTime":
                                sb.Append(flight.TakeoffTime.PadLeft(fieldLengths[field] + 1) + "|");
                                break;
                            case "LandingTime":
                                sb.Append(flight.LandingTime.PadLeft(fieldLengths[field] + 1) + "|");
                                break;
                            case "Longitude":
                                sb.Append(flight.Longitude.ToString().PadLeft(fieldLengths[field] + 1) + "|");
                                break;
                            case "Latitude":
                                sb.Append(flight.Latitude.ToString().PadLeft(fieldLengths[field] + 1) + "|");
                                break;
                            case "AMSL":
                                sb.Append(flight.AMSL.ToString().PadLeft(fieldLengths[field] + 1) + "|");
                                break;
                            case "PlaneID":
                                sb.Append(flight.PlaneID.ToString().PadLeft(fieldLengths[field] + 1) + "|");
                                break;
                        }
                    }

                    sb.Remove(sb.Length - 1, 1);
                    sb.Append("\n");
                }

                Console.WriteLine(sb);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void DisplayCargoFields(List<string> fields, List<Cargo> cargoes)
        {
            try
            {
                Dictionary<string, int> fieldLengths = new Dictionary<string, int>()
                {
                    { "ID", 0 },
                    { "Weight", 0 },
                    { "Code", 0 },
                    { "Description", 0 }
                };
                if (fields.Count == 1 && fields[0] == "*")
                {
                    fields = HelperMethods.CargoFields.Keys.ToList();
                }

                foreach (var field in fields)
                {
                    switch (field)
                    {
                        case "ID":
                            fieldLengths[field] = Math.Max(field.Length, cargoes.Max(c => c.ID).ToString().Length);
                            break;
                        case "Weight":
                            fieldLengths[field] = Math.Max(field.Length, cargoes.Max(c => c.Weight.ToString().Length));
                            break;
                        case "Code":
                            fieldLengths[field] = Math.Max(field.Length, cargoes.Max(c => c.Code.Length));
                            break;
                        case "Description":
                            fieldLengths[field] = Math.Max(field.Length, cargoes.Max(c => c.Description.Length));
                            break;
                    }
                }

                var sb = new StringBuilder();
                foreach (var field in fields)
                {
                    sb.Append(field.PadRight(fieldLengths[field] + 1) + "|");
                }

                sb.Remove(sb.Length - 1, 1);
                sb.Append("\n");

                foreach (var field in fields)
                {
                    sb.Append(new string('-', fieldLengths[field] + 1) + "+");
                }

                sb.Remove(sb.Length - 1, 1);
                sb.Append("\n");
                foreach (var cargo in cargoes)
                {
                    foreach (var field in fields)
                    {
                        switch (field)
                        {
                            case "ID":
                                sb.Append(cargo.ID.ToString().PadLeft(fieldLengths[field] + 1) + "|");
                                break;
                            case "Weight":
                                sb.Append(cargo.Weight.ToString().PadLeft(fieldLengths[field] + 1) + "|");
                                break;
                            case "Code":
                                sb.Append(cargo.Code.PadLeft(fieldLengths[field] + 1) + "|");
                                break;
                            case "Description":
                                sb.Append(cargo.Description.PadLeft(fieldLengths[field] + 1) + "|");
                                break;
                        }
                    }

                    sb.Remove(sb.Length - 1, 1);
                    sb.Append("\n");
                }

                Console.WriteLine(sb);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void DisplayCargoPlaneFields(List<string> fields, List<CargoPlane> cargoPlanes)
        {
            try
            {
                Dictionary<string, int> fieldLengths = new Dictionary<string, int>()
                {
                    { "ID", 0 },
                    { "Model", 0 },
                    { "Country", 0 },
                    { "Serial", 0 },
                    { "MaxLoad", 0 }
                };
                if (fields.Count == 1 && fields[0] == "*")
                {
                    fields = HelperMethods.CargoPlaneFields.Keys.ToList();
                }

                foreach (var field in fields)
                {
                    switch (field)
                    {
                        case "ID":
                            fieldLengths[field] = Math.Max(field.Length, cargoPlanes.Max(c => c.ID).ToString().Length);
                            break;
                        case "Model":
                            fieldLengths[field] = Math.Max(field.Length, cargoPlanes.Max(c => c.Model.Length));
                            break;
                        case "Country":
                            fieldLengths[field] = Math.Max(field.Length, cargoPlanes.Max(c => c.Country.Length));
                            break;
                        case "Serial":
                            fieldLengths[field] = Math.Max(field.Length, cargoPlanes.Max(c => c.Serial.Length));
                            break;
                        case "MaxLoad":
                            fieldLengths[field] = Math.Max(field.Length,
                                cargoPlanes.Max(c => c.MaxLoad.ToString().Length));
                            break;
                    }
                }

                var sb = new StringBuilder();
                foreach (var field in fields)
                {
                    sb.Append(field.PadRight(fieldLengths[field] + 1) + "|");
                }

                sb.Remove(sb.Length - 1, 1);
                sb.Append("\n");

                foreach (var field in fields)
                {
                    sb.Append(new string('-', fieldLengths[field] + 1) + "+");
                }

                sb.Remove(sb.Length - 1, 1);
                sb.Append("\n");
                foreach (var cargoPlane in cargoPlanes)
                {
                    foreach (var field in fields)
                    {
                        switch (field)
                        {
                            case "ID":
                                sb.Append(cargoPlane.ID.ToString().PadLeft(fieldLengths[field] + 1) + "|");
                                break;
                            case "Model":
                                sb.Append(cargoPlane.Model.PadLeft(fieldLengths[field] + 1) + "|");
                                break;
                            case "Country":
                                sb.Append(cargoPlane.Country.PadLeft(fieldLengths[field] + 1) + "|");
                                break;
                            case "Serial":
                                sb.Append(cargoPlane.Serial.PadLeft(fieldLengths[field] + 1) + "|");
                                break;
                            case "MaxLoad":
                                sb.Append(cargoPlane.MaxLoad.ToString().PadLeft(fieldLengths[field] + 1) + "|");
                                break;
                        }
                    }

                    sb.Remove(sb.Length - 1, 1);
                    sb.Append("\n");
                }

                Console.WriteLine(sb);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void DisplayPassengerPlaneFields(List<string> fields, List<PassengerPlane> passengerPlanes)
        {
            try
            {
                Dictionary<string, int> fieldLengths = new Dictionary<string, int>()
                {
                    { "ID", 0 },
                    { "Model", 0 },
                    { "Country", 0 },
                    { "Serial", 0 },
                    { "FirstClassSize", 0 },
                    { "BusinessClassSize", 0 },
                    { "EconomyClassSize", 0 }
                };
                if (fields.Count == 1 && fields[0] == "*")
                {
                    fields = HelperMethods.PassengerPlaneFields.Keys.ToList();
                }

                foreach (var field in fields)
                {
                    switch (field)
                    {
                        case "ID":
                            fieldLengths[field] = Math.Max(field.Length,
                                passengerPlanes.Max(p => p.ID).ToString().Length);
                            break;
                        case "Model":
                            fieldLengths[field] = Math.Max(field.Length, passengerPlanes.Max(p => p.Model.Length));
                            break;
                        case "Country":
                            fieldLengths[field] = Math.Max(field.Length, passengerPlanes.Max(p => p.Country.Length));
                            break;
                        case "Serial":
                            fieldLengths[field] = Math.Max(field.Length, passengerPlanes.Max(p => p.Serial.Length));
                            break;
                        case "FirstClassSize":
                            fieldLengths[field] = Math.Max(field.Length,
                                passengerPlanes.Max(p => p.FirstClassSize.ToString().Length));
                            break;
                        case "BusinessClassSize":
                            fieldLengths[field] = Math.Max(field.Length,
                                passengerPlanes.Max(p => p.BusinessClassSize.ToString().Length));
                            break;
                        case "EconomyClassSize":
                            fieldLengths[field] = Math.Max(field.Length,
                                passengerPlanes.Max(p => p.EconomyClassSize.ToString().Length));
                            break;
                    }
                }

                var sb = new StringBuilder();
                foreach (var field in fields)
                {
                    sb.Append(field.PadRight(fieldLengths[field] + 1) + "|");
                }

                sb.Remove(sb.Length - 1, 1);
                sb.Append("\n");

                foreach (var field in fields)
                {
                    sb.Append(new string('-', fieldLengths[field] + 1) + "+");
                }

                sb.Remove(sb.Length - 1, 1);
                sb.Append("\n");
                foreach (var passengerPlane in passengerPlanes)
                {
                    foreach (var field in fields)
                    {
                        switch (field)
                        {
                            case "ID":
                                sb.Append(passengerPlane.ID.ToString().PadLeft(fieldLengths[field] + 1) + "|");
                                break;
                            case "Model":
                                sb.Append(passengerPlane.Model.PadLeft(fieldLengths[field] + 1) + "|");
                                break;
                            case "Country":
                                sb.Append(passengerPlane.Country.PadLeft(fieldLengths[field] + 1) + "|");
                                break;
                            case "Serial":
                                sb.Append(passengerPlane.Serial.PadLeft(fieldLengths[field] + 1) + "|");
                                break;
                            case "FirstClassSize":
                                sb.Append(passengerPlane.FirstClassSize.ToString().PadLeft(fieldLengths[field] + 1) +
                                          "|");
                                break;
                            case "BusinessClassSize":
                                sb.Append(
                                    passengerPlane.BusinessClassSize.ToString().PadLeft(fieldLengths[field] + 1) + "|");
                                break;
                            case "EconomyClassSize":
                                sb.Append(passengerPlane.EconomyClassSize.ToString().PadLeft(fieldLengths[field] + 1) +
                                          "|");
                                break;
                        }

                    }

                    sb.Remove(sb.Length - 1, 1);
                    sb.Append("\n");
                }

                Console.WriteLine(sb);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void DisplayPassengerFields(List<string> fields, List<Passenger> passengers)
        {
            try
            {
                Dictionary<string, int> fieldLengths = new Dictionary<string, int>()
                {
                    { "ID", 0 },
                    { "Name", 0 },
                    { "Age", 0 },
                    { "Phone", 0 },
                    { "Email", 0 },
                    { "Class", 0 },
                    { "Miles", 0 }
                };
                if (fields.Count == 1 && fields[0] == "*")
                {
                    fields = HelperMethods.PassengerFields.Keys.ToList();
                }

                foreach (var field in fields)
                {
                    switch (field)
                    {
                        case "ID":
                            fieldLengths[field] = Math.Max(field.Length, passengers.Max(p => p.ID).ToString().Length);
                            break;
                        case "Name":
                            fieldLengths[field] = Math.Max(field.Length, passengers.Max(p => p.Name.Length));
                            break;
                        case "Age":
                            fieldLengths[field] = Math.Max(field.Length, passengers.Max(p => p.Age.ToString().Length));
                            break;
                        case "Phone":
                            fieldLengths[field] = Math.Max(field.Length, passengers.Max(p => p.Phone.Length));
                            break;
                        case "Email":
                            fieldLengths[field] = Math.Max(field.Length, passengers.Max(p => p.Email.Length));
                            break;
                        case "Class":
                            fieldLengths[field] = Math.Max(field.Length, passengers.Max(p => p.Class.Length));
                            break;
                        case "Miles":
                            fieldLengths[field] =
                                Math.Max(field.Length, passengers.Max(p => p.Miles.ToString().Length));
                            break;
                    }
                }

                var sb = new StringBuilder();
                foreach (var field in fields)
                {
                    sb.Append(field.PadRight(fieldLengths[field] + 1) + "|");
                }

                sb.Remove(sb.Length - 1, 1);
                sb.Append("\n");

                foreach (var field in fields)
                {
                    sb.Append(new string('-', fieldLengths[field] + 1) + "+");
                }

                sb.Remove(sb.Length - 1, 1);
                sb.Append("\n");
                foreach (var passenger in passengers)
                {
                    foreach (var field in fields)
                    {
                        switch (field)
                        {
                            case "ID":
                                sb.Append(passenger.ID.ToString().PadLeft(fieldLengths[field] + 1) + "|");
                                break;
                            case "Name":
                                sb.Append(passenger.Name.PadRight(fieldLengths[field] + 1) + "|");
                                break;
                            case "Age":
                                sb.Append(passenger.Age.ToString().PadLeft(fieldLengths[field] + 1) + "|");
                                break;
                            case "Phone":
                                sb.Append(passenger.Phone.PadLeft(fieldLengths[field] + 1) + "|");
                                break;
                            case "Email":
                                sb.Append(passenger.Email.PadLeft(fieldLengths[field] + 1) + "|");
                                break;
                            case "Class":
                                sb.Append(passenger.Class.PadLeft(fieldLengths[field] + 1) + "|");
                                break;
                            case "Miles":
                                sb.Append(passenger.Miles.ToString().PadLeft(fieldLengths[field] + 1) + "|");
                                break;
                        }
                    }

                    sb.Remove(sb.Length - 1, 1);
                    sb.Append("\n");
                }

                Console.WriteLine(sb);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void DeletePassengers(List<Passenger> passengers)
        {
            foreach (var passenger in passengers)
            {
                passenger.Dispose();
            }
        }

        public void DeleteCrews(List<Crew> crews)
        {
            foreach (var crew in crews)
            {
                crew.Dispose();
            }
        }

        public void DeleteAirports(List<Airport> airports)
        {
            foreach (var airport in airports)
            {
                airport.Dispose();
            }
        }

        public void DeleteFlights(List<Flight> flights)
        {
            foreach (var flight in flights)
            {
                flight.Dispose();
            }
        }

        public void DeleteCargoes(List<Cargo> cargoes)
        {
            foreach (var cargo in cargoes)
            {
                cargo.Dispose();
            }
        }

        public void DeleteCargoPlanes(List<CargoPlane> cargoPlanes)
        {
            foreach (var cargoPlane in cargoPlanes)
            {
                cargoPlane.Dispose();
            }
        }

        public void DeletePassengerPlanes(List<PassengerPlane> passengerPlanes)
        {
            foreach (var passengerPlane in passengerPlanes)
            {
                passengerPlane.Dispose();
            }
        }

        public void UpdatePassengers(List<Passenger> passengers, string valuekeypairs)
        {
            var splitpairs = valuekeypairs.Split(',');
            List<string> fields = new List<string>();
            List<string> values = new();
            foreach (var pair in splitpairs)
            {
                var temp = pair.Split("=");
                fields.Add(temp[0]);
                values.Add(temp[1]);
            }

            int i = 0;
            foreach (var field in fields)
            {
                switch (field)
                {
                    case "ID":
                        foreach (var passenger in passengers)
                        {
                            passenger.UpdateID(new IDUpdateArgs(){NewObjectID = ulong.Parse(values[i]),ObjectID = passenger.ID});
                        }

                        i++;
                        break;
                    case "Name":
                        foreach (var passenger in passengers)
                        {
                            passenger.Name = values[i];
                        }

                        i++;
                        break;
                    case "Age":
                        foreach (var passenger in passengers)
                        {
                            passenger.Age = ulong.Parse(values[i]);
                        }

                        i++;
                        break;
                    case "Phone":
                        foreach (var passenger in passengers)
                        {
                            passenger.Phone = values[i];
                        }
                        i++;
                        break;
                    case "Email":
                        foreach (var passenger in passengers)
                        {
                            passenger.Email = values[i];
                        }
                        i++;
                        break;
                    case "Class":
                        foreach (var passenger in passengers)
                        {
                            passenger.Class = values[i];
                        }
                        i++;
                        break;
                    case "Miles":
                        foreach (var passenger in passengers)
                        {
                            passenger.Miles = ulong.Parse(values[i]);
                        }
                        i++;
                        break;
                }

            }

        }

        public void UpdateCrews(List<Crew> crews, string valuekeypairs)
        {
            var splitpairs = valuekeypairs.Split(',');
            List<string> fields = new List<string>();
            List<string> values = new();
            foreach (var pair in splitpairs)
            {
                var temp = pair.Split("=");
                fields.Add(temp[0]);
                values.Add(temp[1]);
            }

            int i = 0;
            foreach (var field in fields)
            {
                switch (field)
                {
                    case "ID":
                        foreach (var crew in crews)
                        {
                            crew.UpdateID(new IDUpdateArgs(){NewObjectID = ulong.Parse(values[i]),ObjectID = crew.ID});
                        }
                        i++;
                        break;
                    case "Name":
                        foreach (var crew in crews)
                        {
                            crew.Name = values[i];
                        }

                        i++;
                        break;
                    case "Age":
                        foreach (var crew in crews)
                        {
                            crew.Age = ulong.Parse(values[i]);
                        }

                        i++;
                        break;
                    case "Phone":
                        foreach (var crew in crews)
                        {
                            crew.Phone = values[i];
                        }

                        i++;
                        break;
                    case "Email":
                        foreach (var crew in crews)
                        {
                            crew.Email = values[i];
                        }
                        i++;
                        break;
                    case "Practice":
                        foreach (var crew in crews)
                        {
                            crew.Practice = ulong.Parse(values[i]);
                        }
                        i++;
                        break;
                    case "Role":
                        foreach (var crew in crews)
                        {
                            crew.Role = (values[i]);
                        }
                        i++;
                        break;
                }

            }
        }

        public void UpdateAirports(List<Airport> airports, string valuekeypairs)
        {
            var splitpairs = valuekeypairs.Split(',');
            List<string> fields = new List<string>();
            List<string> values = new();
            foreach (var pair in splitpairs)
            {
                var temp = pair.Split("=");
                fields.Add(temp[0]);
                values.Add(temp[1]);
            }

            int i = 0;
            foreach (var field in fields)
            {
                switch (field)
                {
                    case "ID":
                        foreach (var airport in airports)
                        {
                            airport.UpdateID(new IDUpdateArgs(){NewObjectID = ulong.Parse(values[i]),ObjectID = airport.ID});
                        }
                        i++;
                        break;
                    case "Name":
                        foreach (var airport in airports)
                        {
                            airport.Name = values[i];
                        }

                        i++;
                        break;
                    case "Code":
                        foreach (var airport in airports)
                        {
                            airport.Code = (values[i]);
                        }

                        i++;
                        break;
                    case "Longitude":
                        foreach (var airport in airports)
                        {
                            airport.Longitude = float.Parse(values[i]);
                        }

                        i++;
                        break;
                    case "Latitude":
                        foreach (var airport  in airports)
                        {
                            airport.Latitude = float.Parse(values[i]);
                        }
                        i++;
                        break;
                    case "AMSL":
                        foreach (var airport  in airports)
                        {
                            airport.AMSL = ulong.Parse(values[i]);
                        }
                        i++;
                        break;
                    case "Country":
                        foreach (var airport  in airports)
                        {
                            airport.Country = (values[i]);
                        }
                        i++;
                        break;
                }

            }
        }

        public void UpdateFlights(List<Flight> flights, string valuekeypairs)
        {
            var splitpairs = valuekeypairs.Split(',');
            List<string> fields = new List<string>();
            List<string> values = new();
            foreach (var pair in splitpairs)
            {
                var temp = pair.Split("=");
                fields.Add(temp[0]);
                values.Add(temp[1]);
            }

            int i = 0;
            foreach (var field in fields)
            {
                switch (field)
                {
                    case "ID":
                        foreach (var flight in flights)
                        {
                            flight.UpdateID(new IDUpdateArgs(){NewObjectID = ulong.Parse(values[i]),ObjectID = flight.ID});
                        }
                        i++;
                        break;
                    case "Origin":
                        foreach (var flight in flights)
                        {
                            flight.Origin = ulong.Parse(values[i]);
                        }

                        i++;
                        break;
                    case "Target":
                        foreach (var flight in flights)
                        {
                            flight.Target = ulong.Parse((values[i]));
                        }

                        i++;
                        break;
                    case "Longitude":
                        foreach (var flight in flights)
                        {
                            flight.Longitude = float.Parse(values[i]);
                        }

                        i++;
                        break;
                    case "Latitude":
                        foreach (var flight  in flights)
                        {
                            flight.Latitude = float.Parse(values[i]);
                        }
                        i++;
                        break;
                    case "AMSL":
                        foreach (var flight  in flights)
                        {
                            flight.AMSL = ulong.Parse(values[i]);
                        }
                        i++;
                        break;
                    case "PlaneID":
                        foreach (var flight  in flights)
                        {
                            flight.PlaneID = ulong.Parse((values[i]));
                        }
                        i++;
                        break;
                }

            }
        }
    }

    public class ConditionsInterpreter
    {
        public List<Crew> FilterCrews(string[] conditions, int startindex)
        {
            var finalcrew = Data.Crews.Values.ToList();
            if (startindex >= conditions.Length)
                return finalcrew;
            
            string logicalOperator = null;
            for (int i = startindex; i < conditions.Length; i += 3)
            {
                var crew = Data.Crews.Values.ToList();
                var field = conditions[i];
                var operation = conditions[i + 1];
                var value = conditions[i + 2];
                ICrewFilter filter = Constants.CrewFilters[operation];

                switch (field)
                {
                    case "ID":
                        crew = filter.FilterbyID(crew, ulong.Parse(value));
                        break;
                    case "Name":
                        crew = filter.FilterbyName(crew, value);
                        break;
                    case "Age":
                        crew = filter.FilterbyAge(crew, ulong.Parse(value));
                        break;
                    case "Phone":
                        crew = filter.FilterbyPhone(crew, value);
                        break;
                    case "Email":
                        crew = filter.FilterbyEmail(crew, value);
                        break;
                    case "Practice":
                        crew = filter.FilterbyPractice(crew, ulong.Parse(value));
                        break;
                    case "Role":
                        crew = filter.FilterbyRole(crew, value);
                        break;
                }

                if (logicalOperator != null)
                {
                    switch (logicalOperator)
                    {
                        case "AND":
                            finalcrew = finalcrew.Intersect(crew).ToList();
                            break;
                        case "OR":
                            finalcrew = finalcrew.Union(crew).ToList();
                            break;
                    }
                }
                else
                {
                    finalcrew = crew;
                }

                if (i + 3 < conditions.Length)
                {
                    logicalOperator = conditions[i + 3];
                    i++;
                }
            }

            return finalcrew;
        }

        public List<Airport> FilterAirports(string[] conditions, int startindex)
        {
            var finalAirports = Data.Airports.Values.ToList();
            string logicalOperator = null;
            for (int i = startindex; i < conditions.Length; i += 3)
            {
                var airports = Data.Airports.Values.ToList();
                var field = conditions[i];
                var operation = conditions[i + 1];
                var value = conditions[i + 2];
                IAirportFilter filter = Constants.AirportFilters[operation];

                switch (field)
                {
                    case "ID":
                        airports = filter.FilterbyID(airports, ulong.Parse(value));
                        break;
                    case "Name":
                        airports = filter.FilterbyName(airports, value);
                        break;
                    case "Code":
                        airports = filter.FilterbyCode(airports, value);
                        break;
                    case "Longitude":
                        airports = filter.FilterbyLongitude(airports, float.Parse(value));
                        break;
                    case "Latitude":
                        airports = filter.FilterbyLatitude(airports, float.Parse(value));
                        break;
                    case "AMSL":
                        airports = filter.FilterbyAMSL(airports, float.Parse(value));
                        break;
                    case "Country":
                        airports = filter.FilterbyCountry(airports, value);
                        break;
                }

                if (logicalOperator != null)
                {
                    switch (logicalOperator)
                    {
                        case "AND":
                            finalAirports = finalAirports.Intersect(airports).ToList();
                            break;
                        case "OR":
                            finalAirports = finalAirports.Union(airports).ToList();
                            break;
                    }
                }
                else
                {
                    finalAirports = airports;
                }

                if (i + 3 < conditions.Length)
                {
                    logicalOperator = conditions[i + 3];
                    i++;
                }
            }

            return finalAirports;
        }

        public List<Flight> FilterFlights(string[] conditions, int startindex)
        {
            var finalFlights = Data.Flights.Values.ToList();
            string logicalOperator = null;
            for (int i = startindex; i < conditions.Length; i += 3)
            {
                var flights =  Data.Flights.Values.ToList();
                var field = conditions[i];
                var operation = conditions[i + 1];
                var value = conditions[i + 2];
                IFlightFilter filter = Constants.FlightFilters[operation];

                switch (field)
                {
                    case "ID":
                        flights = filter.FilterbyID(flights, ulong.Parse(value));
                        break;
                    case "Origin":
                        flights = filter.FilterbyOrigin(flights, ulong.Parse(value));
                        break;
                    case "Target":
                        flights = filter.FilterbyTarget(flights, ulong.Parse(value));
                        break;
                    case "TakeoffTime":
                        flights = filter.FilterbyTakeoffTime(flights, value);
                        break;
                    case "LandingTime":
                        flights = filter.FilterbyLandingTime(flights, value);
                        break;
                    case "Longitude":
                        flights = filter.FilterbyLongitude(flights, float.Parse(value));
                        break;
                    case "Latitude":
                        flights = filter.FilterbyLatitude(flights, float.Parse(value));
                        break;
                    case "AMSL":
                        flights = filter.FilterbyAMSL(flights, float.Parse(value));
                        break;
                    case "PlaneID":
                        flights = filter.FilterbyPlaneID(flights, ulong.Parse(value));
                        break;
                }

                if (logicalOperator != null)
                {
                    switch (logicalOperator)
                    {
                        case "AND":
                            finalFlights = finalFlights.Intersect(flights).ToList();
                            break;
                        case "OR":
                            finalFlights = finalFlights.Union(flights).ToList();
                            break;
                    }
                }
                else
                {
                    finalFlights = flights;
                }

                if (i + 3 < conditions.Length)
                {
                    logicalOperator = conditions[i + 3];
                    i++;
                }
            }

            return finalFlights;
        }

        public List<Passenger> FilterPassengers(string[] conditions, int startindex)
        {
            var finalPassengers = Data.Passengers.Values.ToList();
            string logicalOperator = null;
            for (int i = startindex; i < conditions.Length; i += 3)
            {
                var passengers = Data.Passengers.Values.ToList();
                var field = conditions[i];
                var operation = conditions[i + 1];
                var value = conditions[i + 2];
                IPassengerFilter filter = Constants.PassengerFilters[operation];

                switch (field)
                {
                    case "ID":
                        passengers = filter.FilterbyID(passengers, ulong.Parse(value));
                        break;
                    case "Name":
                        passengers = filter.FilterbyName(passengers, value);
                        break;
                    case "Age":
                        passengers = filter.FilterbyAge(passengers, ulong.Parse(value));
                        break;
                    case "Phone":
                        passengers = filter.FilterbyPhone(passengers, value);
                        break;
                    case "Email":
                        passengers = filter.FilterbyEmail(passengers, value);
                        break;
                    case "Class":
                        passengers = filter.FilterbyClass(passengers, value);
                        break;
                    case "Miles":
                        passengers = filter.FilterbyMiles(passengers, ulong.Parse(value));
                        break;
                }

                if (logicalOperator != null)
                {
                    switch (logicalOperator)
                    {
                        case "AND":
                            finalPassengers = finalPassengers.Intersect(passengers).ToList();
                            break;
                        case "OR":
                            finalPassengers = finalPassengers.Union(passengers).ToList();
                            break;
                    }
                }
                else
                {
                    finalPassengers = passengers;
                }

                if (i + 3 < conditions.Length)
                {
                    logicalOperator = conditions[i + 3];
                    i++;
                }
            }

            return finalPassengers;
        }

        public List<Cargo> FilterCargoes(string[] conditions, int startindex)
        {
            var finalCargoes = Data.Cargoes.Values.ToList();
            string logicalOperator = null;
            for (int i = startindex; i < conditions.Length; i += 3)
            {
                var cargoes =  Data.Cargoes.Values.ToList();
                var field = conditions[i];
                var operation = conditions[i + 1];
                var value = conditions[i + 2];
                ICargoFilter filter = Constants.CargoFilters[operation];

                switch (field)
                {
                    case "ID":
                        cargoes = filter.FilterbyID(cargoes, ulong.Parse(value));
                        break;
                    case "Weight":
                        cargoes = filter.FilterbyWeight(cargoes, float.Parse(value));
                        break;
                    case "Code":
                        cargoes = filter.FilterbyCode(cargoes, value);
                        break;
                    case "Description":
                        cargoes = filter.FilterbyDescription(cargoes, value);
                        break;
                }

                if (logicalOperator != null)
                {
                    switch (logicalOperator)
                    {
                        case "AND":
                            finalCargoes = finalCargoes.Intersect(cargoes).ToList();
                            break;
                        case "OR":
                            finalCargoes = finalCargoes.Union(cargoes).ToList();
                            break;
                    }
                }
                else         {
                    finalCargoes = cargoes;
                }

                if (i + 3 < conditions.Length)
                {
                    logicalOperator = conditions[i + 3];
                    i++;
                }
            }

            return finalCargoes;
        }

        public List<CargoPlane> FilterCargoPlanes(string[] conditions, int startindex)
        {
            var finalCargoPlanes = Data.CargoPlanes.Values.ToList();
            string logicalOperator = null;
            for (int i = startindex; i < conditions.Length; i += 3)
            {
                var cargoPlanes = Data.CargoPlanes.Values.ToList();
                var field = conditions[i];
                var operation = conditions[i + 1];
                var value = conditions[i + 2];
                ICargoPlaneFilter filter = Constants.CargoPlaneFilters[operation];

                switch (field)
                {
                    case "ID":
                        cargoPlanes = filter.FilterbyID(cargoPlanes, ulong.Parse(value));
                        break;
                    case "Model":
                        cargoPlanes = filter.FilterbyModel(cargoPlanes, value);
                        break;
                    case "Country":
                        cargoPlanes = filter.FilterbyCountry(cargoPlanes, value);
                        break;
                    case "Serial":
                        cargoPlanes = filter.FilterbySerial(cargoPlanes, value);
                        break;
                    case "MaxLoad":
                        cargoPlanes = filter.FilterbyMaxLoad(cargoPlanes, float.Parse(value));
                        break;
                }

                if (logicalOperator != null)
                {
                    switch (logicalOperator)
                    {
                        case "AND":
                            finalCargoPlanes = finalCargoPlanes.Intersect(cargoPlanes).ToList();
                            break;
                        case "OR":
                            finalCargoPlanes = finalCargoPlanes.Union(cargoPlanes).ToList();
                            break;
                    }
                }
                else
                {
                    finalCargoPlanes = cargoPlanes;
                }

                if (i + 3 < conditions.Length)
                {
                    logicalOperator = conditions[i + 3];
                    i++;
                }
            }

            return finalCargoPlanes;
        }

        public List<PassengerPlane> FilterPassengerPlanes(string[] conditions, int startindex)
        {
            var finalPassengerPlanes = Data.PassengerPlanes.Values.ToList();
            string logicalOperator = null;
            for (int i = startindex; i < conditions.Length; i += 3)
            {
                var passengerPlanes = Data.PassengerPlanes.Values.ToList();
                var field = conditions[i];
                var operation = conditions[i + 1];
                var value = conditions[i + 2];
                IPassengerPlaneFilter filter = Constants.PassengerPlaneFilters[operation];

                switch (field)
                {
                    case "ID":
                        passengerPlanes = filter.FilterbyID(passengerPlanes, ulong.Parse(value));
                        break;
                    case "Model":
                        passengerPlanes = filter.FilterbyModel(passengerPlanes, value);
                        break;
                    case "FirstClassSize":
                        passengerPlanes = filter.FilterbyFirstClassSize(passengerPlanes, ushort.Parse(value));
                        break;
                    case "BusinessClassSize":
                        passengerPlanes = filter.FilterbyBusinessClassSize(passengerPlanes, ushort.Parse(value));
                        break;
                    case "EconomyClassSize":
                        passengerPlanes = filter.FilterbyEconomyClassSize(passengerPlanes, ushort.Parse(value));
                        break;
                    case "Country":
                        passengerPlanes = filter.FilterbyCountry(passengerPlanes, value);
                        break;
                    case "Serial":
                        passengerPlanes = filter.FilterbySerial(passengerPlanes, value);
                        break;
                }

                if (logicalOperator != null)
                {
                    switch (logicalOperator)
                    {
                        case "AND":
                            finalPassengerPlanes = finalPassengerPlanes.Intersect(passengerPlanes).ToList();
                            break;
                        case "OR":
                            finalPassengerPlanes = finalPassengerPlanes.Union(passengerPlanes).ToList();
                            break;
                    }
                }
                else
                {
                    finalPassengerPlanes = passengerPlanes;
                }

                if (i + 3 < conditions.Length)
                {
                    logicalOperator = conditions[i + 3];
                    i++;
                }
            }

            return finalPassengerPlanes;
        }
    }
}