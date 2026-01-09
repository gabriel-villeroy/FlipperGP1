using System;
using TMPro;
using Unity.Jobs;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private int score;
    [SerializeField] private TMP_Text scoreText;

    private int scoreTarget;
    public int bumperBonus;
    
    public static ScoreManager Instance;
    
    private void Awake()
    {
        Instance = this;
        scoreTarget = 100;
    }

    private void Update()
    {
        scoreText.text = score.ToString();
        
        if (score >= scoreTarget)
        {
            ScoreBonus();
        }
    }

    public void AddScore(int scoreToAdd)
    {
        score += scoreToAdd;
    }

    public void ScoreBonus()
    {
        scoreTarget += 100;
        GameManager.Instance.ballLeft++;
    }
}
