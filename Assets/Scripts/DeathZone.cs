using System;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
        GameManager.Instance.ballInScene = false;
        GameManager.Instance.ballLeft--;
    }
}
