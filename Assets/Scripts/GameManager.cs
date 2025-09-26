using System;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    
    [SerializeField] private GameObject ball;
    [SerializeField] private Transform spawnPoint; 
    [SerializeField] private int ballLeft = 3;
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

        if (ballLeft == 0)
        {
            GameOver();
        }
    }

    private void SpawnBall()
    {
        currentBall = Instantiate(ball, spawnPoint.position, Quaternion.identity);
        currentBall.layer = 3;
        ballCount++;
    }

    private void GameOver()
    {
        
    }
}
