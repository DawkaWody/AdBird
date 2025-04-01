using UnityEngine;
using UnityEngine.InputSystem;

public class BirdController : MonoBehaviour
{
    [SerializeField] private float _speed = 1.5f;
    [SerializeField] private float _rotationSpeed = 10f;

    private Rigidbody2D _rigidbody;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Touchscreen.current.primaryTouch.press.isPressed)
        {
            Debug.Log("fly");
            _rigidbody.linearVelocity = Vector2.up * _speed;
        }
    }

    void FixedUpdate()
    {
        transform.rotation = Quaternion.Euler(0, 0, _rigidbody.linearVelocity.y * _rotationSpeed);
    }
}
