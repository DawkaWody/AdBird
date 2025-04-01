using UnityEngine;
using UnityEngine.InputSystem;

public class BirdController : MonoBehaviour
{
    [SerializeField] private float _speed = 1.5f;
    [SerializeField] private float _rotationSpeed = 10f;
    [SerializeField] private float _heightRange;
    [SerializeField] private GameObject _floatingAd;
    public Camera _camera;
    private int _jumpCount = 0;

    private Rigidbody2D _rigidbody;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!Touchscreen.current.primaryTouch.press.wasPressedThisFrame || GameManager.instance.checkForGameOver()) return;
        if (UiManager.Instance.isPaused) return;

        _rigidbody.linearVelocity = Vector2.up * _speed;
        _jumpCount++;
        if (_jumpCount % 100 == 0)
            UiManager.Instance.EnableBuyClicks();
        else if (_jumpCount % 30 == 0)
        {
            Vector3 screenCenter = _camera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, _camera.nearClipPlane));
            Vector3 spawnPosition = transform.position + new Vector3(0, Random.Range(-_heightRange, _heightRange));
            Instantiate(_floatingAd, spawnPosition, Quaternion.identity);
        }        
        else if (_jumpCount % 3 == 0)
            RewardedAd.Instance.LoadAndShow();
    }

    void FixedUpdate()
    {
        transform.rotation = Quaternion.Euler(0, 0, _rigidbody.linearVelocity.y * _rotationSpeed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameManager.instance.GameOver();
    }
}

