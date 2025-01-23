using System;
public interface IObserver
{
    void OnNotify(EventType eventType, object eventData);
}