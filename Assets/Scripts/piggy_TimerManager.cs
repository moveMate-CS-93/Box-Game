using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class piggy_TimerManager : MonoBehaviour
{
    public static piggy_TimerManager Instance { get; private set; }

    [SerializeField] private Text timerText;
    private float elapsedTime;
    private bool isGameOver = false;

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
        if (!isGameOver)
        {
            elapsedTime += Time.deltaTime;
            int minutes = Mathf.FloorToInt(elapsedTime / 60);
            int seconds = Mathf.FloorToInt(elapsedTime % 60);
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }

    public void RestartTimer()
    {
        elapsedTime = 0f;
        isGameOver = false;
    }

    public void StopTimer()
    {
        isGameOver = true;
    }
}
