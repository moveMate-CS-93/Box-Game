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
    public GameObject tapText;
    public Text scoreText;

    private int score = 0;
    private bool gameStarted = false;

    void Start()
    {
        // Show the "Get Ready" image and play button when the game starts
        getReadyImage.SetActive(true);
        playButton.SetActive(true);
        tapText.SetActive(true);
        scoreText.gameObject.SetActive(false);
    }

    public void StartGame()
    {
        // Start spawning blocks and hide the UI elements
        StartSpawning();
        getReadyImage.SetActive(false);
        playButton.SetActive(false);
        tapText.SetActive(false);
        scoreText.gameObject.SetActive(true);
        gameStarted = true;
    }

    void Update()
    {
        // Check for mouse click to start the game if it hasn't started yet
        if (Input.GetMouseButtonDown(0) && !gameStarted)
        {
            StartGame();
        }
    }

    private void StartSpawning()
    {
        InvokeRepeating("SpawnBlock", 0.5f, spawnRate);
    }

    private void SpawnBlock()
    {
        Vector3 spawnPos = spawnPoint.position;
        spawnPos.x = Random.Range(-maxX, maxX);

        Instantiate(block, spawnPos, Quaternion.identity);

        score++;
        scoreText.text = score.ToString();
    }
}
