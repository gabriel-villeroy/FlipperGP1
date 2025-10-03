using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private Image LtextFrame;
    [SerializeField] private Image RtextFrame;
    [SerializeField] private TMP_Text Ltext;
    [SerializeField] private TMP_Text Rtext;
    
    
    void Update()
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

        if (Input.GetKey(KeyCode.RightShift) && Input.GetKey(KeyCode.LeftShift))
        {
            LoadLevel();
        }
    }

    void InputColorShift(bool isKeyPressed, Image textFrame, TMP_Text text)
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

    private void LoadLevel()
    {
        SceneManager.LoadScene(1);
    }
}
