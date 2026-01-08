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
    public GameObject currentBall;
    
    [Header("UI")] 
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private TMP_Text ballLeftText;

    [Header("SideManagement")] 
    public bool onAside;

    [NonSerialized] public List<GameObject> AsideList = new List<GameObject>();
    [NonSerialized] public List<GameObject> BsideList = new List<GameObject>();

    
    [Header("General")]
    public GameState currentGameState;

    public enum GameState
    {
        Game,
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
        SpawnBall();
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
            SpawnBall();
        }
    }
    
    
    //Game
    
    private void SpawnBall()
    {
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
        pausePanel.SetActive(!pausePanel.activeSelf);
    }
    
    
    //GameOver
    
    private void SetGameOverPanel()
    {
        currentGameState = GameState.GameOver;
        gameOverPanel.SetActive(true);
    }
    
    
    //SceneControl
    
    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Application.Quit");
    }
}
