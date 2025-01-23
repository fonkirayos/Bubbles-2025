using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEventManager : MonoBehaviour, ISubscriber
{
    private List<IObserver> observers = new List<IObserver>();

    public void RegisterObserver(IObserver observer)
    {
        if (!observers.Contains(observer))
        {
            observers.Add(observer);
        }
    }

    public void UnregisterObserver(IObserver observer)
    {
        if (observers.Contains(observer))
        {
            observers.Remove(observer);
        }
    }

    public void NotifyObservers(EventType eventType, object eventData)
    {
        foreach (IObserver observer in observers)
        {
            observer.OnNotify(eventType, eventData);
        }
    }

    // Singleton pattern implementation
    private static GameEventManager instance;
    public static GameEventManager Instance
    {
        get
        {
            if (instance == null)
            {
                GameObject go = new GameObject("GameEventManager");
                instance = go.AddComponent<GameEventManager>();
                //DontDestroyOnLoad(go); // Ensure the GameEventManager persists across scenes
            }
            return instance;
        }
    }
    // Ensure the singleton instance is destroyed properly
    private void OnDestroy()
    {
        //if (instance == this)
        //{
        //    instance = null;
        //}
        Debug.Log("Cleaning GEM from onDestroy()");
        Cleanup();
    }

    // Optional: Clean up when a new scene is loaded
    private void OnEnable()
    {
        //UnityEngine.SceneManagement.SceneManager.sceneUnloaded += OnSceneUnloaded;
    }

    //private void OnDisable()
    //{
    //    UnityEngine.SceneManagement.SceneManager.sceneUnloaded -= OnSceneUnloaded;
    //    Cleanup();
    //}

    //private void OnSceneUnloaded(UnityEngine.SceneManagement.Scene scene)
    //{
    //    if (instance == this)
    //    {
    //        Debug.Log("Cleaning GEM from onSceneUnloaded()");
    //        Cleanup();
    //        ///Destroy(gameObject); // Clean up the singleton GameObject
    //    }
    //}

    public static void Cleanup()
    {
        if (instance != null)
        {
            Debug.Log("cleaning up gameEventManager");
            Destroy(instance.gameObject);
            instance = null;
        }
    }
}