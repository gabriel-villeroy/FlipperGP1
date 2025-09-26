using System;
using UnityEngine;
using DG.Tweening;

public class PaddleController : MonoBehaviour
{
    [SerializeField] private GameObject RPivot;
    [SerializeField] private GameObject LPivot;

    [SerializeField] private float defaultPivotRot;
    [SerializeField] private float movementPivotRot;

    [SerializeField] private float moveDuration;

    private float pivotTargetRot;

    private void Start()
    { 
        RPivot.transform.rotation = Quaternion.Euler(0,0,defaultPivotRot);
        LPivot.transform.rotation = Quaternion.Euler(0,0,-defaultPivotRot);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.RightShift)) Pivot(RPivot, true);
        if(Input.GetKeyDown(KeyCode.LeftShift)) Pivot(LPivot, true);
        if(Input.GetKeyUp(KeyCode.RightShift)) Pivot(RPivot, false);
        if(Input.GetKeyUp(KeyCode.LeftShift)) Pivot(LPivot, false);
    }

    private void Pivot(GameObject targetPivot, bool activate)
    {
        if (activate)
        {
            pivotTargetRot = movementPivotRot;
        }
        else
        {
            pivotTargetRot = defaultPivotRot;
        }
        
        if (targetPivot == LPivot)
        {
            //targetPivot.transform.rotation = Quaternion.Euler(0,0,-pivotTargetRot);
            targetPivot.transform.DORotate(new Vector3(0, 0, -pivotTargetRot), moveDuration);

        }

        if (targetPivot == RPivot)
        {
            //targetPivot.transform.rotation = Quaternion.Euler(0,0,pivotTargetRot);
            targetPivot.transform.DORotate(new Vector3(0, 0, pivotTargetRot), moveDuration);
        }
    }
}
