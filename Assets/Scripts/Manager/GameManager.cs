using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Keys")] 
    public KeyCode rightKey;
    public KeyCode rightAltKey;
    public KeyCode leftKey;
    public KeyCode leftAltKey;
    public KeyCode switchKey;
    
    [Header("Ball")]
    [SerializeField] private GameObject ball;
    [SerializeField] private Transform spawnPoint; 
    public int ballLeft = 3;
    public bool ballInScene;
    private GameObject currentBall;
    
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
        GameOver
    }

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        setActiveObjectsOfCurrentSide();
        SpawnBall();
    }

    void Update()
    {
        SwitchSideInput();
        DisplayBallCount();
        if (ballLeft == 0)
        { 
            GameOver();
            return;
        }
        if (!ballInScene)
        { 
            SpawnBall();
        }
        PauseInputs();
    }

        
    //Game
    
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
    
    
    //SideManagement

    private void SwitchSideInput()
    {
        if (Input.GetKeyDown(switchKey))
        {
            Invertbool();
            setActiveObjectsOfCurrentSide();
        }
    }
    
    private void Invertbool()
    {
        onAside = !onAside;
    }

    private void setActiveObjectsOfCurrentSide()
    {
        foreach (GameObject element in BsideList)
        {
            element.SetActive(onAside);
        }
        foreach (GameObject element in AsideList)
        {
            element.SetActive(!onAside);
        }
    }
    
    
    //PauseMenu

    private void SetPause(bool paused)
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

    private void PauseInputs()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SetPause(currentGameState != GameState.Pause);
        }

        if (currentGameState == GameState.Pause)
        {
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                LoadMenu();
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                Quit();
            }
        }
    }
    
    
    //GameOver
    
    public void GameOverPanelInputs()
    {
        if (Input.GetKey(KeyCode.R))
        {
            Retry();
        }
        if (Input.GetKey(KeyCode.Tab))
        {
            LoadMenu();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            Quit();
        }
    }
    
    private void GameOver()
    {
        if (currentGameState != GameState.GameOver)
        {
            currentGameState = GameState.GameOver;
            gameOverPanel.SetActive(true);
        }
        GameOverPanelInputs();
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
