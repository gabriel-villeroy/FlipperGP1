using System;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private int score;
    [SerializeField] private TMP_Text scoreText;

    public int bumperBonus;
    
    public static ScoreManager Instance;
    
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        PaletteManager.Instance.UIObjList.Add(scoreText);
    }

    private void Update()
    {
        scoreText.text = score.ToString();
    }

    public void AddScore(int scoreToAdd)
    {
        score += scoreToAdd;
    }
}
