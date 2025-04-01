using UnityEngine;

public class FloatingAd : MonoBehaviour
{
    public float speed = 5f;
    private Vector2 direction;

    private float screenWidth;
    private float screenHeight;

    private Camera _camera;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        screenWidth = Camera.main.aspect * Camera.main.orthographicSize;
        screenHeight = Camera.main.orthographicSize;

        transform.position = Vector2.zero;

        direction = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;

        _camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0); 

            if (touch.phase == TouchPhase.Began)
            {
                Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);

                RaycastHit2D hit = Physics2D.Raycast(touchPosition, Vector2.zero);

                if (hit.collider != null)
                {
                    if (hit.collider.gameObject == gameObject)
                    {
                        Debug.Log("hit!");
                        RewardedAd.Instance.LoadAndShow();
                    }
                }
            }
        }

        transform.Translate(direction * speed * Time.deltaTime);

        Vector3 screenPos = Camera.main.WorldToViewportPoint(transform.position);
        if (screenPos.x < 0 || screenPos.x > 1)
        {
            direction.x = -direction.x;
        }

        if (screenPos.y < 0 || screenPos.y > 1)
        {
            direction.y = -direction.y;
        }
    }
}
