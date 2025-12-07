using System.Linq;
using UnityEditor.Search;
using UnityEngine;

public class CategoryHandler : MonoBehaviour
{
    public enum colorPriority
    {
        Primary,
        Secondary
    }
    public colorPriority cp;
    
    public enum activeStateConstancy
    {
        Constant,
        Aside,
        Bside
    }
    public activeStateConstancy activeConstacy;
    
    void Awake()
    {
        if (cp == colorPriority.Primary) PaletteManager.Instance.primaryObjList.Add(gameObject);
        if (cp == colorPriority.Secondary) PaletteManager.Instance.secondaryObjList.Add(gameObject);
        if (activeConstacy == activeStateConstancy.Aside) GameManager.Instance.AsideList.Add(gameObject);
        if (activeConstacy == activeStateConstancy.Bside) GameManager.Instance.BsideList.Add(gameObject);
    }
}
