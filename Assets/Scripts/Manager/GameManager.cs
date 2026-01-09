using System;
using System.Collections.Generic;
using TMPro;
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
    [NonSerialized] public GameObject currentBall;
    
    [Header("UI")] 
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject winPanel;
    [SerializeField] private GameObject pausePanel;
    [SerializeField] public GameObject spawnBallHint;
    [SerializeField] public GameObject spawnMark;
    [SerializeField] private TMP_Text ballLeftText;

    [Header("SideManagement")] 
    public bool onAside; 
    
    [Header("General")]
    public GameState currentGameState;

    public enum GameState
    {
        Game,
        WaitingBall,
        Pause,
        GameOver,
        Win
    }
    
    
    //
    
    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        PaletteManager.Instance.swapToA += switchToA;
        PaletteManager.Instance.swapToB += switchToB;
        
        spawnBallHint.SetActive(false);
        spawnMark.SetActive(false);
        winPanel.SetActive(false);
        pausePanel.SetActive(false);
        gameOverPanel.SetActive(false);

        currentGameState = GameState.WaitingBall;
    }

    void Update()
    {
        DisplayBallCount();
        if (ballLeft == 0 && currentGameState != GameState.GameOver)
        {
            Time.timeScale = 0;
            SetGameOverPanel();
            return;
        }
        if (!ballInScene)
        {
            spawnBallHint.SetActive(true);
            spawnMark.SetActive(true);
            if (currentGameState == GameState.Game)
            {
                currentGameState = GameState.WaitingBall;
            }
        }
    }
    
    
    //Game
    
    public void SpawnBall()
    {
        currentGameState = GameState.Game;
        currentBall = Instantiate(ball, spawnPoint.position, Quaternion.identity);
        currentBall.layer = 3;

        if (onAside)
        {
            currentBall.GetComponent<MeshRenderer>().material.color = PaletteManager.Instance.A_ballColor;
        }
        else
        {
            currentBall.GetComponent<MeshRenderer>().material.color = PaletteManager.Instance.B_ballColor;
        }
        ballInScene = true;
    }

    private void DisplayBallCount()
    {
        ballLeftText.text = ballLeft + " Ball Left";
    }
    
    
    //SideManagement
    
    public void switchToA()
    {
        onAside = true;
    }
    public void switchToB()
    {
        onAside = false;
    }
    
    //PauseMenu

    public void SetPause(bool paused)
    {
        if (paused)
        {
            currentGameState = GameState.Pause;
            Time.timeScale = 0;
        }
        else
        {
            currentGameState = GameState.Game;
            Time.timeScale = 1;
        }
        pausePanel.SetActive(paused);
    }
    
    
    //GameOver
    
    private void SetGameOverPanel()
    {
        currentGameState = GameState.GameOver;
        gameOverPanel.SetActive(true);
    }
    
    //Win

    public void SetWinPanel()
    {
        currentGameState = GameState.Win;
        winPanel.SetActive(true);
    }
    
    
    //SceneControl
    
    public void Retry()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
    
    public void LoadNext()
    {
        if (SceneManager.GetActiveScene().buildIndex + 1 == SceneManager.sceneCountInBuildSettings)
        {
            LoadMenu();
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Application.Quit");
    }
}
