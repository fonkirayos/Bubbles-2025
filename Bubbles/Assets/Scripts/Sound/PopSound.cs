using UnityEngine;

public class PopSound : MonoBehaviour, IObserver
{
    AudioSource audioSource;

    public void OnNotify(EventType eventType, object eventData)
    {
        switch (eventType)
        {
            case EventType.BubblePop:
                playSource();
                break;
            case EventType.TimeOut:
                break;
            case EventType.Score:
                break;
            case EventType.Lose:
                break;
            case EventType.PopAnimationFinished:
                
                break;
        }

    }
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        GameEventManager.Instance.RegisterObserver(this);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void playSource()
    {
        Debug.Log("play popped audio");
        audioSource.Play();
    }
}
