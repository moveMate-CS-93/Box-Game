using UnityEngine;
using UnityEngine.UI;

public class piggy_TimerManager : MonoBehaviour
{
    public static piggy_TimerManager Instance { get; private set; }

    [SerializeField] private Text timerText;
    private float elapsedTime;
    private bool isGameOver = false;
    private bool gameStarted = false; // Variable to track if the game has started

    private void Awake()
    {
        if (Instance != null)
        {
            DestroyImmediate(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    void Update()
    {
        if (gameStarted && !isGameOver) // Only update the timer when the game has started and not over
        {
            elapsedTime += Time.deltaTime;
            UpdateTimerText();
        }
    }

    public void RestartTimer()
    {
        elapsedTime = 0f;
        isGameOver = false;
        UpdateTimerText(); // Update the timer text to keep it at 00:00
    }

    public void StopTimer()
    {
        isGameOver = true;
    }

    public void StartGame()
    {
        gameStarted = true; // Set game started
    }

    public void ShowStartScreen()
    {
        gameStarted = false; // Set game not started
        UpdateTimerText(); // Update the timer text to keep it at 00:00
    }

    private void UpdateTimerText()
    {
        int minutes = Mathf.FloorToInt(elapsedTime / 60);
        int seconds = Mathf.FloorToInt(elapsedTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
