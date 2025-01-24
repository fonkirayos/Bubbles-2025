using UnityEngine;

public class Bubble : MonoBehaviour
{
    public SpriteRenderer sprite;
    public float scaleDownRate = 0.1f;
    Animator animator;
    public bool isPopped = false;
    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isPopped)
        {
            ScaleDown();
        }

        if(isPopped)
        {
           checkPopAnimationEnd();
        }
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
            GameEventManager.Instance.NotifyObservers(EventType.TimeOut, null);
        }
    }

    private void OnMouseDown()
    {
        if (!isPopped)
        {
            Debug.Log("Click down on Bubble");
            GameEventManager.Instance.NotifyObservers(EventType.BubblePop, sprite.color);
            isPopped = true;
            animator.SetBool("isPopped", true);
        }
        
    }

    void checkPopAnimationEnd()
    {
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);

        if (stateInfo.IsName("BubblePop") && stateInfo.normalizedTime >= 1.0f)
        {
            // Animation has ended
            Debug.Log("Animation has ended");
            sprite.enabled = false;
            GameEventManager.Instance.NotifyObservers(EventType.PopAnimationFinished, null);  
        }
    }

    public void resetAnimator()
    {
        animator.SetBool("isPopped", false);
        animator.Play(0);
    }
}
