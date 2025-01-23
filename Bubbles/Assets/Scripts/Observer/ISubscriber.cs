public interface ISubscriber
{
    void RegisterObserver(IObserver observer);
    void UnregisterObserver(IObserver observer);
    void NotifyObservers(EventType eventType, object eventData);
}