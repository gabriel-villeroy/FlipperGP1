using System;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [Header("Keys")] 
    public KeyCode rightKey;
    public KeyCode leftKey;
    public KeyCode switchKey;
    public KeyCode spawnKey;

    [SerializeField] private GameObject rightPaddleRef;
    [SerializeField] private GameObject leftPaddleRef;

    private HingeController rightHC;
    private HingeController leftHC;
    private PaletteManager paletteManager;

    private void Start()
    {
        rightHC = rightPaddleRef.GetComponent<HingeController>();
        leftHC = leftPaddleRef.GetComponent<HingeController>();
        paletteManager = GetComponent<PaletteManager>();
    }

    private void Update()
    {
        PauseInputs();

        if (GameManager.Instance.currentGameState == GameManager.GameState.Game)
        {
            PaddleInputFuncCalls();

            if (Input.GetKeyDown(switchKey))
            {
                if (GameManager.Instance.onAside)
                {
                    paletteManager.swapToB.Invoke();
                }
                else
                {
                    paletteManager.swapToA.Invoke();
                }
            }
        }

        if (GameManager.Instance.ballLeft == 0)
        {
            GameOverPanelInputs();
        }

        if (Input.GetKeyDown(spawnKey) && GameManager.Instance.currentGameState == GameManager.GameState.WaitingBall)
        {
            GameManager.Instance.spawnBallHint.SetActive(false);
            GameManager.Instance.spawnMark.SetActive(false);
            GameManager.Instance.SpawnBall();
        }

        if (GameManager.Instance.currentGameState == GameManager.GameState.Win)
        {
            WinPanelInputs();
        }
    }


    //PauseMenu

    private void PauseInputs()
    {
        if (GameManager.Instance.currentGameState == GameManager.GameState.Game && Input.GetKeyDown(KeyCode.Escape))
        {
            GameManager.Instance.SetPause(true);
        }

        if (GameManager.Instance.currentGameState == GameManager.GameState.Pause)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                GameManager.Instance.SetPause(false);
            }
            
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                GameManager.Instance.LoadMenu();
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                GameManager.Instance.Quit();
            }
        }
    }


    //GameOverInputs

    private void GameOverPanelInputs()
    {
        if (Input.GetKey(KeyCode.R))
        {
            GameManager.Instance.Retry();
        }

        if (Input.GetKey(KeyCode.Tab))
        {
            GameManager.Instance.LoadMenu();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            GameManager.Instance.Quit();
        }
    }
    
    
    //WinPanelInputs

    private void WinPanelInputs()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            GameManager.Instance.LoadNext();
        }

        if (Input.GetKey(KeyCode.Tab))
        {
            GameManager.Instance.LoadMenu();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            GameManager.Instance.Quit();
        }
    }

    //PaddleInputs

    private void PaddleInputFuncCalls()
    {
        PaddleInput(rightHC, rightKey);
        PaddleInput(leftHC, leftKey);
    }

    private void PaddleInput(HingeController hc, KeyCode key)
    {
        if (Input.GetKey(key)) hc.LiftPaddle(true);
        else hc.LiftPaddle(false);
    }
}
