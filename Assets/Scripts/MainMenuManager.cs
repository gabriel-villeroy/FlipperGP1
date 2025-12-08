using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [Header("References")] 
    [SerializeField] private TMP_Text nameText;
    [SerializeField] private Image LtextFrame;
    [SerializeField] private Image RtextFrame;
    [SerializeField] private TMP_Text Ltext;
    [SerializeField] private TMP_Text Rtext;
    [SerializeField] private Camera camRef;
    [SerializeField] private GameObject preTraGrp;
    [SerializeField] private GameObject postTraGrp;
    
    [Header("Colors")] 
    [SerializeField] private Color whiteColor = Color.white;
    [SerializeField] private Color blackColor = Color.black;

    private void Start()
    {
        preTraGrp.SetActive(true);
        postTraGrp.SetActive(false);
        camRef.backgroundColor = Color.black;
        nameText.color = whiteColor;
    }

    private void Update()
    {
        PreTransitionFeedBack();

        if (Input.GetKey(KeyCode.RightShift) && Input.GetKey(KeyCode.LeftShift))
        {
            RevealMainMenu();
        }
    }

    private void PreTransitionFeedBack()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            InputColorShift(true,LtextFrame, Ltext);
        }
        else
        {
            InputColorShift(false,LtextFrame, Ltext);
        }
        
        if (Input.GetKey(KeyCode.RightShift))
        {
            InputColorShift(true,RtextFrame, Rtext);
        }
        else
        {
            InputColorShift(false,RtextFrame, Rtext);
        }
    }

    private void InputColorShift(bool isKeyPressed, Image textFrame, TMP_Text text)
    {
        if (isKeyPressed)
        {
            text.color = Color.black;
            textFrame.fillCenter = true;
        }
        
        if (!isKeyPressed)
        {
            text.color = Color.white;
            textFrame.fillCenter = false;
        }
    }

    public void LoadLevel1()
    {
        SceneManager.LoadScene(1);
    }

    public void Quit()
    {
        Application.Quit();
    }

    private void RevealMainMenu()
    {
        ColorSwap();
    }

    private void ColorSwap()
    {
        camRef.backgroundColor = whiteColor;
        preTraGrp.SetActive(false);
        postTraGrp.SetActive(true);
        nameText.color = blackColor;
    }
}
