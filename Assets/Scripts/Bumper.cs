using System;
using UnityEngine;

public class Bumper : MonoBehaviour
{
    [SerializeField] private float strength;
    private void OnCollisionEnter(Collision other)
    {
        Vector3 bumpPos = transform.position;
        Vector3 otherPos = other.transform.position;
        Vector3 direction = otherPos - bumpPos;
        direction = direction.normalized;
        
        other.rigidbody.AddForce(direction * strength);
    }
}

