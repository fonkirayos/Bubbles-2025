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
        }

    }
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
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
        audioSource.Play();
    }
}
