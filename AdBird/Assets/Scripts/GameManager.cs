using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] private GameObject _gameOverCanvas;

    private bool isGameOver;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        Time.timeScale = 1f;
        isGameOver = false;
    }

    public void GameOver()
    {
        _gameOverCanvas.SetActive(true);
        isGameOver = true;

        Time.timeScale = 0f;
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        isGameOver = false;
    }
    public bool checkForGameOver()
    {
        return isGameOver;
    }
}
