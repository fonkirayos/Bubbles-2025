using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour, IObserver
{
    public Color point = Color.black;
    public List<Color> pointColors;

    public int Score = 0;
    private void Awake()
    {
        pointColors = new List<Color>();
        InitializePointColors();
    }
    void Start()
    {
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
    void RandomizePointColor()
    {
        point = pointColors[Random.Range(0, pointColors.Count)];
    }

    public void OnNotify(EventType eventType, object eventData)
    {
        throw new System.NotImplementedException();
    }
}
