using System;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [Header("Keys")] public KeyCode rightKey;
    public KeyCode rightAltKey;
    public KeyCode leftKey;
    public KeyCode leftAltKey;
    public KeyCode switchKey;
    public KeyCode shootKey;

    [SerializeField] private GameObject rightPaddleRef;
    [SerializeField] private GameObject leftPaddleRef;

    private HingeController rightHC;
    private HingeController leftHC;
    private PaletteManager paletteManager;
    [NonSerialized] public Shooter shooter;

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

        if (Input.GetKey(shootKey) && shooter.canPush)
        {
            shooter.ChargeShoot();
        }

        if (Input.GetKeyUp(shootKey))
        {
            shooter.ReleaseShoot();
        }
    }


    //PauseMenu

    private void PauseInputs()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameManager.Instance.currentGameState == GameManager.GameState.Game)
            {
                GameManager.Instance.SetPause(true);
            }

            if (GameManager.Instance.currentGameState == GameManager.GameState.Pause)
            {
                GameManager.Instance.SetPause(false);
            }
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


    //PaddleInputs

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
