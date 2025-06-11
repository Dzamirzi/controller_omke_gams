using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("UI")]
    public TextMeshProUGUI gameTimeText;
    public GameObject restartPanel;

    private float gameTime = 0f;
    private bool isGameOver = false;

    void Awake()
    {
        // Singleton pattern (optional)
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        // Hide restart panel at start
        restartPanel.SetActive(false);
    }

    void Update()
    {
        if (isGameOver) return;

        // Update Game Time
        gameTime += Time.deltaTime;
        int minutes = Mathf.FloorToInt(gameTime / 60f);
        int seconds = Mathf.FloorToInt(gameTime % 60f);
        gameTimeText.text = string.Format("Time: {0:00}:{1:00}", minutes, seconds);
    }

    public void GameOver()
    {
        isGameOver = true;
        Time.timeScale = 0f; // Freeze game
        restartPanel.SetActive(true);
    }

    public void RestartGame()
    {
        Time.timeScale = 1f; // Unfreeze before reload
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
