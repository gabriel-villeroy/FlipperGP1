using UnityEngine;

public class HingeController : MonoBehaviour
{
    HingeJoint hingeJoint;
    [SerializeField] private KeyCode key;
    [SerializeField] private KeyCode altKey;

    [SerializeField] float targetPosition = 75f;
    [SerializeField] float originPosition;

    private bool isRightPaddle;
    
    JointSpring jointSpring;
    
    void Start()
    {
        hingeJoint = GetComponent<HingeJoint>();
        jointSpring = hingeJoint.spring;
        CheckPaddlePosition(gameObject.name); 
        SetInputKey();
    }

    void Update()
    {
        if (Input.GetKey(key) || Input.GetKey(altKey))
        {
            jointSpring.targetPosition = targetPosition;
        }
        else
        {
            jointSpring.targetPosition = originPosition;
        }

        hingeJoint.spring = jointSpring;
    }

    void CheckPaddlePosition(string objName)
    {
        if (objName == "RPaddle") isRightPaddle = true;
        else if (objName == "LPaddle") isRightPaddle = false;
        else Debug.LogError("paddle name(s) incorrect !");
    }

    void SetInputKey()
    {
        if (isRightPaddle)
        {
            key = KeyCode.RightArrow;
            altKey = KeyCode.RightShift;
        }
        else
        {
            key = KeyCode.LeftArrow;
            altKey = KeyCode.LeftShift;
        }
    }
}
