using UnityEngine;
using UnityEngine.UI;

public class piggy_TimerManager : MonoBehaviour
{
    public static piggy_TimerManager Instance { get; private set; }

    [SerializeField] private Text timerText;
    private float elapsedTime;
<<<<<<< HEAD
    private bool isTimerRunning = false;
=======
    private bool isGameOver = false;
    private bool gameStarted = false; // Variable to track if the game has started
>>>>>>> parent of 52f98fb (fixed the piggy into the frame, and reduce the number of box falls)

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
<<<<<<< HEAD
        if (isTimerRunning)
=======
        if (gameStarted && !isGameOver) // Only update the timer when the game has started and not over
>>>>>>> parent of 52f98fb (fixed the piggy into the frame, and reduce the number of box falls)
        {
            elapsedTime += Time.deltaTime;
            UpdateTimerText();
        }
    }

    public void RestartTimer()
    {
        elapsedTime = 0f;
<<<<<<< HEAD
        isTimerRunning = false;
        UpdateTimerText();
    }

    public void PauseTimer()
    {
        isTimerRunning = false;
    }

    public void ResumeTimer()
    {
        isTimerRunning = true;
=======
        isGameOver = false;
        UpdateTimerText(); // Update the timer text to keep it at 00:00
>>>>>>> parent of 52f98fb (fixed the piggy into the frame, and reduce the number of box falls)
    }

    public void StopTimer()
    {
<<<<<<< HEAD
        isTimerRunning = false;
        UpdateTimerText();
=======
        isGameOver = true;
>>>>>>> parent of 52f98fb (fixed the piggy into the frame, and reduce the number of box falls)
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
