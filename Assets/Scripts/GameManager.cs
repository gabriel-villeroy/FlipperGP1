using System;
using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    
    [Header("Ball")]
    [SerializeField] private GameObject ball;
    [SerializeField] private Transform spawnPoint; 
    public int ballLeft = 3;
    public bool ballInScene;
    private GameObject currentBall;
    
    [Header("UI")] 
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private TMP_Text ballLeftText;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        SpawnBall();
    }

    void Update()
    {
        DisplayBallCount();
        if (ballLeft == 0)
        {
            GameOver();
            if (Input.GetKey(KeyCode.Space))
            {
                Retry();
            }
        }
        else
        {
            if (!ballInScene)
            { 
                SpawnBall();
            }
        }
    }

    private void SpawnBall()
    {
        currentBall = Instantiate(ball, spawnPoint.position, Quaternion.identity);
        currentBall.layer = 3;
        ballInScene = true;
    }

    private void DisplayBallCount()
    {
        ballLeftText.text = ballLeft + " Ball Left";
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void GameOver()
    {
        gameOverPanel.SetActive(true);
    }
}
