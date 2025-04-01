using UnityEngine;

public class Pipe : MonoBehaviour
{
    [SerializeField] private float _speed = 0.65f;

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * _speed * Time.deltaTime;
    }
}
