using UnityEngine;

public class FloatingAd : MonoBehaviour
{
    public float speed = 5f;
    private Vector2 direction;

    private float screenWidth;
    private float screenHeight;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        screenWidth = Camera.main.aspect * Camera.main.orthographicSize;
        screenHeight = Camera.main.orthographicSize;

        transform.position = Vector2.zero;

        direction = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
    }

    // Update is called once per frame
    void Update()
    {
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
