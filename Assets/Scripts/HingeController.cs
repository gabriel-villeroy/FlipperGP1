using System;
using UnityEngine;

public class HingeController : MonoBehaviour
{
    new HingeJoint hingeJoint;

    [SerializeField] float targetPosition = 75f;
    [SerializeField] float originPosition;

    public bool isRightPaddle;
    
    JointSpring jointSpring;
    
    void Start()
    {
        hingeJoint = GetComponent<HingeJoint>();
        jointSpring = hingeJoint.spring;
    }
    
    public void LiftPaddle(bool lift)
    {
        if (lift) jointSpring.targetPosition = targetPosition;
        else jointSpring.targetPosition = originPosition;
        
        hingeJoint.spring = jointSpring;
    }
}
