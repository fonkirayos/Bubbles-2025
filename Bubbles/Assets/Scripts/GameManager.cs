using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class GameManager : MonoBehaviour, IObserver
{
    public Color point = Color.black;
    public List<Color> pointColors;
    public Bubble[] bubbles;
    public int Score = 0;
    public TMPro.TMP_Text scoreText;
    public TMPro.TMP_Text colorText;
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
        ChangeColorText();
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
            bubble.scaleDownRate = 0.5f;
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
        if (point == color)
        {

            Score++;
            scoreText.text = Score.ToString();
            isPoint = true;
            //RandomizePointColor();
            //ShuffleColors();
            //ResetBubbles();
        }
        else
        {
            Score--;
            if(Score < 0)
                Score = 0;  
            scoreText.text = Score.ToString();
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
            case EventType.TimeOut:
                RandomizePointColor();
                ShuffleColors();
                ResetBubbles();
                ChangeColorText();
                isPoint = false;
                break;
            case EventType.Score:
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
            ChangeColorText();
            isPoint = false;
        }
       
    }

    void ChangeColorText()
    {
        if(point == Color.red)
        {
            colorText.color = Color.red;
            colorText.text = "RED";
        }
        if (point == Color.blue)
        {
            colorText.color = Color.blue;
            colorText.text = "BLUE";
        }
        if (point == Color.yellow)
        {
            colorText.color = Color.yellow;
            colorText.text = "YELLOW";
        }
        if (point == Color.green)
        {
            colorText.color = Color.green;
            colorText.text = "GREEN";
        }
        if (point == Color.magenta)
        {
            colorText.color = Color.magenta;
            colorText.text = "PINK";
        }
    }

    void Lose()
    {

    }
}
