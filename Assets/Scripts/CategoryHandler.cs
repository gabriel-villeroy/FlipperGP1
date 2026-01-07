using System;
using System.Linq;
using TMPro;
using UnityEngine;

public class CategoryHandler : MonoBehaviour
{
    public enum colorPriority
    {
        ForeGround,
        Primary,
        Secondary,
        Ball,
        UI,
        Finish
    }
    public colorPriority cp;
    
    public enum activeStateConstancy
    {
        Constant,
        Aside,
        Bside
    }
    public activeStateConstancy activeConstacy;

    private MeshRenderer meshRef;
    private TMP_Text tmpTextRef;
    
    void Start()
    {
        switch (activeConstacy)
        {
            case activeStateConstancy.Aside : 
                PaletteManager.Instance.swapToA += Show;
                PaletteManager.Instance.swapToB += Hide;
                break;
            case activeStateConstancy.Bside : 
                PaletteManager.Instance.swapToA += Hide;
                PaletteManager.Instance.swapToB += Show;
                break;
        }
        
        switch (cp)
        {
            case colorPriority.ForeGround :
                meshRef = gameObject.GetComponent<MeshRenderer>();
                PaletteManager.Instance.swapToA += SetColors_fg_A;
                PaletteManager.Instance.swapToB += SetColors_fg_B;
                break;
            case colorPriority.Primary :
                meshRef = gameObject.GetComponent<MeshRenderer>();
                PaletteManager.Instance.swapToA += SetColors_prim_A;
                PaletteManager.Instance.swapToB += SetColors_prim_B;
                break;
            case colorPriority.Secondary :
                meshRef = gameObject.GetComponent<MeshRenderer>();
                PaletteManager.Instance.swapToA += SetColors_sec_A;
                PaletteManager.Instance.swapToB += SetColors_sec_B;
                break;
            case colorPriority.Ball :
                meshRef = gameObject.GetComponent<MeshRenderer>();
                PaletteManager.Instance.swapToA += SetColors_ball_A;
                PaletteManager.Instance.swapToB += SetColors_ball_B;
                break;
            case colorPriority.Finish :
                meshRef = gameObject.GetComponent<MeshRenderer>();
                PaletteManager.Instance.swapToA += SetColors_Finish_A;
                PaletteManager.Instance.swapToB += SetColors_Finish_B;
                break;
            case colorPriority.UI :
                tmpTextRef = gameObject.GetComponent<TMP_Text>();
                PaletteManager.Instance.swapToA += SetColors_UI_A;
                PaletteManager.Instance.swapToB += SetColors_UI_B;
                break;
        }
    }

    private void OnDestroy()
    {
        switch (activeConstacy)
        {
            case activeStateConstancy.Aside : 
                PaletteManager.Instance.swapToA -= Show;
                PaletteManager.Instance.swapToB -= Hide;
                break;
            case activeStateConstancy.Bside : 
                PaletteManager.Instance.swapToA -= Hide;
                PaletteManager.Instance.swapToB -= Show;
                break;
        }
        switch (cp)
        {
            case colorPriority.ForeGround :
                PaletteManager.Instance.swapToA -= SetColors_fg_A;
                PaletteManager.Instance.swapToB -= SetColors_fg_B;
                break;
            case colorPriority.Primary :
                PaletteManager.Instance.swapToA -= SetColors_prim_A;
                PaletteManager.Instance.swapToB -= SetColors_prim_B;
                break;
            case colorPriority.Secondary :
                PaletteManager.Instance.swapToA -= SetColors_sec_A;
                PaletteManager.Instance.swapToB -= SetColors_sec_B;
                break;
            case colorPriority.Ball :
                PaletteManager.Instance.swapToA -= SetColors_ball_A;
                PaletteManager.Instance.swapToB -= SetColors_ball_B;
                break;
            case colorPriority.Finish :
                meshRef = gameObject.GetComponent<MeshRenderer>();
                PaletteManager.Instance.swapToA -= SetColors_Finish_A;
                PaletteManager.Instance.swapToB -= SetColors_Finish_B;
                break;
            case colorPriority.UI :
                PaletteManager.Instance.swapToA -= SetColors_UI_A;
                PaletteManager.Instance.swapToB -= SetColors_UI_B;
                break;
        }
    }

    private void Show() => gameObject.SetActive(true);
    private void Hide() => gameObject.SetActive(false);
    private void SetColors_fg_A() => meshRef.material.color = PaletteManager.Instance.A_foregroundColor;
    private void SetColors_fg_B() => meshRef.material.color = PaletteManager.Instance.B_foregroundColor;
    private void SetColors_prim_A() => meshRef.material.color = PaletteManager.Instance.A_primaryColor;
    private void SetColors_prim_B() => meshRef.material.color = PaletteManager.Instance.B_primaryColor;
    private void SetColors_sec_A() => meshRef.material.color = PaletteManager.Instance.A_secondaryColor;
    private void SetColors_sec_B() => meshRef.material.color = PaletteManager.Instance.B_secondaryColor;
    private void SetColors_ball_A() => meshRef.material.color = PaletteManager.Instance.A_ballColor;
    private void SetColors_ball_B() => meshRef.material.color = PaletteManager.Instance.B_ballColor;
    private void SetColors_Finish_A() => meshRef.material.color = PaletteManager.Instance.A_FinishColor;
    private void SetColors_Finish_B() => meshRef.material.color = PaletteManager.Instance.B_FinishColor;
    private void SetColors_UI_A() => tmpTextRef.color = PaletteManager.Instance.A_UIColor;
    private void SetColors_UI_B() => tmpTextRef.color = PaletteManager.Instance.B_UIColor;
}
