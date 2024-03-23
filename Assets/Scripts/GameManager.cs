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
        piggy_TimerManager.Instance.StopTimer();// Pause the timer initially
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
        timerManager.RestartTimer(); // Restart the timer when the game starts
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

        // Stop the timer when the game is over
        piggy_TimerManager.Instance.StopTimer();
        // timerManager.StopTimer();
    }

    public void RestartGame()
    {
        StartGame();
    }

    public void OnPlayButtonClicked()
    {
        // Reset the timer when the play button is clicked
        timerManager.RestartTimer();
    }
}
