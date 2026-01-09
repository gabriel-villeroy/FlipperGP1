using System;
using UnityEngine;

public class Finish : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        GameManager.Instance.SetWinPanel();
    }
}
