using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PaletteManager : MonoBehaviour
{
    public static PaletteManager Instance;
    
    [Header("A side colors")]
    public Color A_UIColor;
    public Color A_FinishColor;
    public Color A_foregroundColor;
    public Color A_ballColor;
    public Color A_primaryColor;
    public Color A_secondaryColor;
    public Color A_backgroundColor;
    
    [Header("B side colors")]
    public Color B_UIColor;
    public Color B_FinishColor;
    public Color B_foregroundColor;
    public Color B_ballColor;
    public Color B_primaryColor;
    public Color B_secondaryColor;
    public Color B_backgroundColor;
    
    //[Header("References")]
    private Camera camRef;
    
    private void Awake()
    {
        Instance = this;
        camRef = FindAnyObjectByType<Camera>();
    }

    private void Start()
    {
        StartCoroutine(InitLevel());
        swapToA += SetColor_bg_A;
        swapToB += SetColor_bg_B;
    }

    private IEnumerator InitLevel()
    {
        yield return new WaitForSeconds(0.01f);
        swapToA.Invoke();
    }

    public void SetColor_bg_A()
    {
        camRef.backgroundColor = A_backgroundColor;
    }
    public void SetColor_bg_B()
    {
        camRef.backgroundColor = B_backgroundColor;
    }
    

    public Action swapToA;
    public Action swapToB;
}
