using System;
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
    [SerializeField] private float holdTime = 1f;
    private float timeHeld;
    private bool inInvertedMode;

    public enum GameState
    {
        Game,
        Pause,
        GameOver
    }

    public GameState currentGameState = GameState.Game;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        currentGameState = GameState.Game;
        RefreshSceneInvertion();
        SpawnBall();
    }

    void Update()
    {
        InvertModeInput();
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
    
    
    //Invert

    private void InvertModeInput()
    {
        if ((Input.GetKey(rightKey) && Input.GetKey(leftKey)) ||
            (Input.GetKey(rightAltKey) && Input.GetKey(leftAltKey)))
        {
            Invertbool();
            RefreshSceneInvertion();
        }
    }
    
    private void Invertbool()
    {
        inInvertedMode =! inInvertedMode;
    }

    private void RefreshSceneInvertion()
    {
        foreach (var element in GameObject.FindGameObjectsWithTag("NegItem"))
        {
            element.SetActive(inInvertedMode);
        }
        foreach (var element in GameObject.FindGameObjectsWithTag("PosItem"))
        {
            element.SetActive(!inInvertedMode);
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
