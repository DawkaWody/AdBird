using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Score.instance.UpdateScore();
    }
}
