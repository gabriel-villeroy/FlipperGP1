using System;
using System.Collections.Generic;
using UnityEngine;

public class PaletteManager : MonoBehaviour
{
    public static PaletteManager Instance;
    
    [Header("neutral colors")] 
    [SerializeField] private Color net_mainColor;
        
    [Header("regular colors")]
    [SerializeField] private Color uni_mainColor;
    [SerializeField] private Color uni_secondaryColor;
    
    [Header("inverted colors")]
    [SerializeField] private Color inv_mainColor;
    [SerializeField] private Color inv_secondaryColor;
    
    public List<GameObject> primaryObjList = new List<GameObject>();
    public List<GameObject> secondaryObjList = new List<GameObject>();
    
    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        setMaterialColor();
    }

    private void setMaterialColor()
    {
        Color mainColor;
        Color secColor;
        switch (!GameManager.Instance.onAside)
        {
            case (false):
            {
                mainColor = uni_mainColor;
                secColor = uni_secondaryColor;
                break;
            }
            case (true):
            {
                mainColor = inv_mainColor;
                secColor = inv_secondaryColor;
                break;
            }
        }
        
        if (primaryObjList.Count != 0)
        {
            for (int i = 0; i < primaryObjList.Count; i++)
            {
                primaryObjList[i].gameObject.GetComponent<MeshRenderer>().material.color = mainColor;
                Debug.Log("téla ?");
            }
        }

        if (secondaryObjList.Count != 0)
        {
            for (int i = 0; i < secondaryObjList.Count; i++)
            {
                secondaryObjList[i].gameObject.GetComponent<MeshRenderer>().material.color = secColor;
            }
        }
    }
}
