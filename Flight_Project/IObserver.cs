using NetworkSourceSimulator;

namespace Flight_Project
{
    public interface IObserver
    {
        void Update(PositionUpdateArgs args);
        void Update(ContactInfoUpdateArgs args);
        void Update(IDUpdateArgs args);

        public bool IsValidIDUpdate(IDUpdateArgs args);

        public bool IsValidPositionUpdate(PositionUpdateArgs args);

        public bool IsValidContactInfoUpdate(ContactInfoUpdateArgs args);
    }
    public interface IObservable
    {
        void AddObserver(IObserver observer);
        void RemoveObserver(IObserver observer);
        void NotifyObservers(PositionUpdateArgs args);
        void NotifyObservers(IDUpdateArgs args);
        void NotifyObservers(ContactInfoUpdateArgs args);
    }
}
