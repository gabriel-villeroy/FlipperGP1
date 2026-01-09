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
    [SerializeField] private GameObject postTraButtonGrp;
    [SerializeField] private GameObject postTraTitle;
    [SerializeField] private GameObject LvlSlctGrp;
    
    [Header("Colors")] 
    [SerializeField] private Color lightColor = Color.white;
    [SerializeField] private Color darkColor = Color.black;

    private void Start()
    {
        preTraGrp.SetActive(true);
        postTraGrp.SetActive(false);
        LvlSlctGrp.SetActive(false);
        camRef.backgroundColor = Color.black;
        nameText.color = lightColor;
    }

    private void Update()
    {
        PreTransitionFeedBack();

        if (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.LeftArrow))
        {
            RevealMainMenu();
        }
    }

    private void PreTransitionFeedBack()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            InputColorShift(true,LtextFrame, Ltext);
        }
        else
        {
            InputColorShift(false,LtextFrame, Ltext);
        }
        
        if (Input.GetKey(KeyCode.RightArrow))
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

    public void LoadLevel(int i)
    {
        SceneManager.LoadScene(i);
    }

    public void LevelPanel()
    {
        postTraButtonGrp.SetActive(false);
        LvlSlctGrp.SetActive(true);
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
        camRef.backgroundColor = lightColor;
        postTraTitle.GetComponent<Image>().color = lightColor;
        preTraGrp.SetActive(false);
        postTraGrp.SetActive(true);
        nameText.color = darkColor;
    }
}
