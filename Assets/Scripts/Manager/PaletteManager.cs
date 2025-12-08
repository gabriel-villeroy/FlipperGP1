using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PaletteManager : MonoBehaviour
{
    public static PaletteManager Instance;
    
    [Header("A side colors")]
    [SerializeField] private Color A_UIColor;
    [SerializeField] private Color A_foregroundColor;
    [SerializeField] private Color A_ballColor;
    [SerializeField] private Color A_primaryColor;
    [SerializeField] private Color A_secondaryColor;
    [SerializeField] private Color A_backgroundColor;
    
    [Header("B side colors")]
    [SerializeField] private Color B_UIColor;
    [SerializeField] private Color B_foregroundColor;
    [SerializeField] private Color B_ballColor;
    [SerializeField] private Color B_primaryColor;
    [SerializeField] private Color B_secondaryColor;
    [SerializeField] private Color B_backgroundColor;
    
    public List<TMP_Text> UIObjList = new List<TMP_Text>();
    public List<GameObject> foregroundObjList = new List<GameObject>();
    public List<GameObject> primaryObjList = new List<GameObject>();
    public List<GameObject> secondaryObjList = new List<GameObject>();

    //[Header("References")]
    private Camera camRef;
    
    private void Awake()
    {
        Instance = this;
        camRef = FindAnyObjectByType<Camera>();
    }

    private void Start()
    {
        setMaterialColor();
    }

    private void Update()
    {
        if (Input.GetKeyDown(GameManager.Instance.switchKey))
        {
            setMaterialColor();
        }
    }

    private void setMaterialColor()
    {
        Color uiColor;
        Color fgColor;
        Color ballColor;
        Color primColor;
        Color secColor;
        Color bgColor;
        
        switch (!GameManager.Instance.onAside)
        {
            case (false):
            {
                uiColor = A_UIColor;
                fgColor = A_foregroundColor;
                ballColor = A_ballColor;
                primColor = A_primaryColor;
                secColor = A_secondaryColor;
                bgColor = A_backgroundColor;
                break;
            }
            case (true):
            {
                uiColor = B_UIColor;
                fgColor = B_foregroundColor;
                ballColor = B_ballColor;
                primColor = B_primaryColor;
                secColor = B_secondaryColor;
                bgColor = B_backgroundColor;
                break;
            }
        }
        
        if (UIObjList.Count != 0)
        {
            for (int i = 0; i < UIObjList.Count; i++)
            {
                UIObjList[i].color = uiColor;
            }
        }
        
        if (foregroundObjList.Count != 0)
        {
            for (int i = 0; i < foregroundObjList.Count; i++)
            {
                foregroundObjList[i].gameObject.GetComponent<MeshRenderer>().material.color = fgColor;
            }
        }
        
        if (primaryObjList.Count != 0)
        {
            for (int i = 0; i < primaryObjList.Count; i++)
            {
                primaryObjList[i].gameObject.GetComponent<MeshRenderer>().material.color = primColor;
            }
        }

        if (secondaryObjList.Count != 0)
        {
            for (int i = 0; i < secondaryObjList.Count; i++)
            {
                secondaryObjList[i].gameObject.GetComponent<MeshRenderer>().material.color = secColor;
            }
        }
        
        //bgColor
        camRef.backgroundColor = bgColor;
        //ballColor
        if(GameManager.Instance.currentBall != null)
        {
            GameManager.Instance.currentBall.GetComponent<MeshRenderer>().material.color = ballColor;
        }
    }
}
