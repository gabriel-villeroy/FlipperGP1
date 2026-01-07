using System;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [Header("Keys")] 
    public KeyCode rightKey;
    public KeyCode rightAltKey;
    public KeyCode leftKey;
    public KeyCode leftAltKey;
    public KeyCode switchKey;
    
    [Header("Paddles")]
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
            SwitchSideInput();
        }

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
        
        if (GameManager.Instance.ballLeft == 0)
        {
            GameOverPanelInputs();
        }
    }
    
    
    //PauseMenu
    
    private void PauseInputs()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GameManager.Instance.SetPause
                (GameManager.Instance.currentGameState != GameManager.GameState.Pause);
        }

        if (GameManager.Instance.currentGameState == GameManager.GameState.Pause)
        {
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
    
    
    //SideManagement
    
    private void SwitchSideInput()
    {
        if (Input.GetKeyDown(switchKey))
        {
            GameManager.Instance.Invertbool();
            GameManager.Instance.setActiveObjectsOfCurrentSide();
        }
    }
    
    
    //GameOver
    
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
    
    
    //PaddleInput

    private void PaddleInputFuncCalls()
    {
        PaddleInput(rightHC, rightKey);
        PaddleInput(rightHC, rightAltKey);
        PaddleInput(leftHC, leftKey);
        PaddleInput(leftHC, leftAltKey);
    }
    
    private void PaddleInput(HingeController hingeController, KeyCode key)
    {
        if (Input.GetKey(key)) hingeController.LiftPaddle(true);
        else hingeController.LiftPaddle(false);
    }
}
