using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PLayerScore : MonoBehaviour, IScore
{
    [Header("Очки")]
    public int score;
    [Header("Вывод")]
    [SerializeField] private TMP_Text scoreText;

    private void Start()
    {
        scoreText.text = score.ToString();
        score = 0;
    }
    public void IScore(int scorePoint)
    {
        score += scorePoint;
        scoreText.text = score.ToString();
    }
}
