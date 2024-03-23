using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject block;
    public float maxX;
    public Transform spawnPoint;
    public float spawnRate = 5f;

    public GameObject getReadyImage;
    public GameObject playButton;
    public Text scoreText;
    public GameObject gameOverPanel;
    public piggy_TimerManager timerManager; // Reference to the TimerManager script

    private int score = 0;
    private bool gameStarted = false;

    void Start()
    {
        ShowStartScreen();
    }

    void ShowStartScreen()
    {
        getReadyImage.SetActive(true);
        playButton.SetActive(true);
        scoreText.gameObject.SetActive(true);
        gameOverPanel.SetActive(false);
        score = 0;
<<<<<<< HEAD
        timerManager.RestartTimer();
=======
        timerManager.ShowStartScreen(); // Update the timer when showing start screen
>>>>>>> parent of 52f98fb (fixed the piggy into the frame, and reduce the number of box falls)
    }

    public void StartGame()
    {
        StartSpawning();
        getReadyImage.SetActive(false);
        playButton.SetActive(false);
        gameOverPanel.SetActive(false);
        score = 0; // Reset score when starting a new game
        scoreText.text = score.ToString(); // Update the score text
        scoreText.gameObject.SetActive(true);
        gameStarted = true;
<<<<<<< HEAD
        timerManager.ResumeTimer(); // Resume the timer when the game starts
=======
        timerManager.StartGame(); // Start the timer when the game starts
>>>>>>> parent of 52f98fb (fixed the piggy into the frame, and reduce the number of box falls)
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !gameStarted)
        {
            StartGame();
        }
    }

    void StartSpawning()
    {
        InvokeRepeating("SpawnBlock", 1f, spawnRate);
    }

    void SpawnBlock()
    {
        if (!gameStarted)
            return;

        Vector3 spawnPos = spawnPoint.position;
        spawnPos.x = Random.Range(-maxX, maxX);

        Instantiate(block, spawnPos, Quaternion.identity);

        score++;
        scoreText.text = score.ToString();
    }

    public void GameOver()
    {
        CancelInvoke("SpawnBlock"); // Stop spawning blocks
        gameOverPanel.SetActive(true);
        playButton.SetActive(true);
        Text gameOverScoreText = gameOverPanel.GetComponentInChildren<Text>();
        gameOverScoreText.text = "Score: " + score.ToString();
        gameStarted = false;

<<<<<<< HEAD
        // Pause the timer when the game is over
        timerManager.PauseTimer();
=======
        // Stop the timer when the game is over
        timerManager.StopTimer();
>>>>>>> parent of 52f98fb (fixed the piggy into the frame, and reduce the number of box falls)
    }

    public void RestartGame()
    {
        ShowStartScreen();
    }
<<<<<<< HEAD

    public void OnPlayButtonClicked()
    {
        StartGame();
    }
=======
>>>>>>> parent of 52f98fb (fixed the piggy into the frame, and reduce the number of box falls)
}
