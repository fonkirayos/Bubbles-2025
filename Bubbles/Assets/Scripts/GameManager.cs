using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;

public class GameManager : MonoBehaviour, IObserver
{
    public Color point = Color.black;
    public List<Color> pointColors;
    public Bubble[] bubbles;
    public int Score = 0;

    bool isPoint = false;
    private void Awake()
    {
        GameEventManager.Instance.RegisterObserver(this);
        pointColors = new List<Color>();
        bubbles = new Bubble[5];
    }
    void Start()
    {
        bubbles = Object.FindObjectsOfType<Bubble>();
        InitializePointColors();
        ResetBubbles();
        RandomizePointColor();
        Debug.Log("Color to get point " + point);
    }

    void Update()
    {
        
    }

    void InitializePointColors()
    {
        pointColors.Add(Color.red);
        pointColors.Add(Color.green);
        pointColors.Add(Color.blue);
        pointColors.Add(Color.yellow);
        pointColors.Add(Color.magenta);
    }

    void ShuffleColors()
    {
        //fisher yates
        int n = pointColors.Count;
        for (int i = 0; i < n; i++)
        {
            int randIndex = Random.Range(i, n);
            Color temp = pointColors[i];
            pointColors[i] = pointColors[randIndex];
            pointColors[randIndex] = temp;
        }
    }

    void ResetBubbles()
    {
        int n = 0;
        foreach(Bubble bubble in bubbles)
        {
            bubble.isPopped = false;
            bubble.resetAnimator();
            bubble.transform.localScale = Vector3.one;
            bubble.scaleDownRate = 0f;
            bubble.sprite.enabled = true;
            bubble.sprite.color = pointColors[n];
            n++;
        }
    }
    void RandomizePointColor()
    {
        point = pointColors[Random.Range(0, pointColors.Count)];
    }

    void OnBubblePop(Color color)
    {
        if(point == color)
        {
            
            Score++;
            isPoint = true;
            //RandomizePointColor();
            //ShuffleColors();
            //ResetBubbles();
        }
    }
    public void OnNotify(EventType eventType, object eventData)
    {
        switch (eventType)
        {
            case EventType.BubblePop:
                OnBubblePop((Color)eventData);
                break;
            case EventType.Lose:
                break;
            case EventType.PopAnimationFinished:
                ResetMiniGame();
                break;
        }

    }

    void ResetMiniGame()
    {
        if (isPoint)
        {
            RandomizePointColor();
            ShuffleColors();
            ResetBubbles();
            isPoint = false;
        }
       
    }
}
