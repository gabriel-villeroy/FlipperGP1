using System;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    [SerializeField] private Rigidbody selfRb;

    private void Start()
    {
        gameObject.GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ReverseGravity();
        }
    }
    
    private void ReverseGravity()
    {
        Physics.gravity = -Physics.gravity;
    }
}
