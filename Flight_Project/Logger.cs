using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetworkSourceSimulator;

namespace Flight_Project
{
    public class Logger : IObserver,IDisposable
    {
        private string LogPath { get; }
        public Logger()
        {
            string directoryPath = ".\\Logs";
            Directory.CreateDirectory(directoryPath);
            LogPath = $"{directoryPath}\\FlightTrackerLog_{DateTime.Now:yyyy-MM-dd}";
            File.AppendAllText(LogPath, $"Application started at {DateTime.Now.TimeOfDay:hh\\:mm\\:ss}\n\n");
        }

        public void Log(string message)
        {
            File.AppendAllText(LogPath, $"{DateTime.UtcNow}: {message}\n");
        }

        public void Update(PositionUpdateArgs args)
        {
            if(IsValidPositionUpdate(args)) 
                Log($"Position Update: ObjectID {args.ObjectID} of type {Data.AllEntities[args.ObjectID].Type} moved to Longitude {args.Longitude}, Latitude {args.Latitude}, AMSL {args.AMSL}");
        }

        public void Update(ContactInfoUpdateArgs args)
        {
            if(IsValidContactInfoUpdate(args)) 
                Log($"Contact Info Update: ObjectID {args.ObjectID} of type {Data.AllEntities[args.ObjectID].Type} contact info changed to Phone: {args.PhoneNumber}, Email: {args.EmailAddress}");
        }

        public void Update(IDUpdateArgs args)
        {
            if(IsValidIDUpdate(args))
                Log($"ID Update: ObjectID {args.ObjectID} of type {Data.AllEntities[args.ObjectID].Type} changed to {args.NewObjectID}");
        }
        public void Dispose()
        {
            File.AppendAllText(LogPath, $"\nApplication closed at {DateTime.Now.TimeOfDay:hh\\:mm\\:ss}\n\n");
        }

        public bool IsValidIDUpdate(IDUpdateArgs args)
        {
            if(Data.AllEntities.ContainsKey(args.NewObjectID))
            {
                Log($"ID Update: ObjectID {args.ObjectID} of type {Data.AllEntities[args.ObjectID].Type} changed to {args.NewObjectID} failed. ObjectID {args.NewObjectID} already exists.");
                return false;
            }
            if (!Data.AllEntities.ContainsKey(args.ObjectID))
            {
                Log($"ID Update: ObjectID {args.ObjectID} changed to {args.NewObjectID} failed. ObjectID {args.ObjectID} does not exist.");
                return false;
            }

            return true;
        }

        public bool IsValidPositionUpdate(PositionUpdateArgs args)
        {
            if(Data.AllEntities.TryGetValue(args.ObjectID,out var item)){
                if (item.Type!="Flight" && item.Type!="Airport")
                {
                    Log($"Position Update: ObjectID {args.ObjectID} of type {Data.AllEntities[args.ObjectID].Type} moved to Longitude {args.Longitude}, Latitude {args.Latitude}, AMSL {args.AMSL} failed. ObjectID {args.ObjectID} is not a Flight or Airport.");
                    return false;
                }
                return true;
            }
            Log($"Position Update: ObjectID {args.ObjectID} moved to Longitude {args.Longitude}, Latitude {args.Latitude}, AMSL {args.AMSL} failed. ObjectID {args.ObjectID} does not exist.");
            return false;
        }

        public bool IsValidContactInfoUpdate(ContactInfoUpdateArgs args)
        {
            if (Data.AllEntities.TryGetValue(args.ObjectID, out var item))
            {
                if (item.Type!="Crew" && item.Type!="Passenger")
                {
                    Log($"Contact Info Update: ObjectID {args.ObjectID} of type {Data.AllEntities[args.ObjectID].Type} contact info changed to Phone: {args.PhoneNumber}, Email: {args.EmailAddress} failed. ObjectID {args.ObjectID} is not a Crew or Passenger.");
                    return false;
                }
                return true;
            } 
            Log($"Contact Info Update: ObjectID {args.ObjectID} contact info changed to Phone: {args.PhoneNumber}, Email: {args.EmailAddress} failed. ObjectID {args.ObjectID} does not exist.");
            return false;
        }
    }
}
