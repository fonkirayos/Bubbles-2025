using UnityEngine;

public class Bubble : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    SpriteRenderer sprite;
    public float scaleDownRate = 0.0f;
    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ScaleDown();
    }

    private void ScaleDown()
    {
        // Update the scale of the object
        Vector3 newScale = transform.localScale - Vector3.one * scaleDownRate * Time.deltaTime;

        // Ensure the scale doesn't become negative
        newScale.x = Mathf.Max(newScale.x, 0.0f);
        newScale.y = Mathf.Max(newScale.y, 0.0f);
        newScale.z = Mathf.Max(newScale.z, 0.0f);

        transform.localScale = newScale;

        // Optionally, destroy the object if it's too small to be visible
        if (newScale.x <= 0.01f && newScale.y <= 0.01f)
        {
            Destroy(gameObject);
        }
    }

    private void OnMouseDown()
    {
        Debug.Log("Click down on Bubble");
        sprite.color = Color.red;
        
    }

    
    private void OnMouseUpAsButton()
    {
        Debug.Log("Click released on Bubble");
        sprite.color = Color.white;
    }

    public void OnNotify(EventType eventType, object eventData)
    {
        
    }
}
