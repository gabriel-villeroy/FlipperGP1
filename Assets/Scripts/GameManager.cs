using System;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    
    [SerializeField] private GameObject ball;
    [SerializeField] private Transform spawnPoint;
    public int ballCount;
    private GameObject currentBall;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        SpawnBall();
    }

    void Update()
    {
        if (ballCount <= 0)
        { 
            SpawnBall();
        }
    }

    private void SpawnBall()
    {
        currentBall = Instantiate(ball, spawnPoint.position, Quaternion.identity);
        currentBall.layer = 3;
        ballCount++;
    }
}
