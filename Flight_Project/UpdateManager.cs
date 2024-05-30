using NetworkSourceSimulator;

namespace Flight_Project
{
    public class UpdateManager : IObserver
    {
        public void Update(PositionUpdateArgs args)
        {
            if (IsValidPositionUpdate(args))
                Data.AllEntities[args.ObjectID].UpdatePosition(args);
        }

        public void Update(ContactInfoUpdateArgs args)
        {
            if (IsValidContactInfoUpdate(args))
                Data.AllEntities[args.ObjectID].UpdateContactDetails(args);
        }

        public void Update(IDUpdateArgs args)
        {
            if (IsValidIDUpdate(args))
                Data.AllEntities[args.ObjectID].UpdateID(args);
        }

        public bool IsValidIDUpdate(IDUpdateArgs args)
        {
            if(Data.AllEntities.ContainsKey(args.NewObjectID))
            {
                return false;
            }
            if (!Data.AllEntities.ContainsKey(args.ObjectID))
            {
                return false;
            }

            return true;
        }

        public bool IsValidPositionUpdate(PositionUpdateArgs args)
        {
            if (!Data.AllEntities.ContainsKey(args.ObjectID))
            {
                return false;
            }

            return true;
        }

        public bool IsValidContactInfoUpdate(ContactInfoUpdateArgs args)
        {
            if (!Data.AllEntities.ContainsKey(args.ObjectID))
            {
                return false;
            }

            return true;
        }
    }
}
