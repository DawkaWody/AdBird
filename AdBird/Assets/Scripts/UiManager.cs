using UnityEngine;

public class UiManager : MonoBehaviour
{
    public static UiManager Instance;
    public bool isPaused;

    [SerializeField] private GameObject _buyClicksPanel;
    [SerializeField] private GameObject _gameOverCanvas;
    [SerializeField] private GameObject _gameOverText;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void EnableBuyClicks()
    {
        Time.timeScale = 0;
        isPaused = true;
        _buyClicksPanel.SetActive(true);
    }

    public void EnableGameStart()
    {
        _gameOverCanvas.SetActive(true);
        _gameOverText.SetActive(false);
    }

    public void UnfreezeTime()
    {
        isPaused = false;
        Time.timeScale = 1;
    }

    public void Quit()
    {
        Application.Quit();
    }
}
