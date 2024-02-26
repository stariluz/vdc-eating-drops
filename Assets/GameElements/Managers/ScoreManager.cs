using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int initialStreak = 0;
    public int streakBonus = 10;
    [SerializeField] int currentStreak = 0;
    public float initialScoreMultiplier = 1;
    [SerializeField] float scoreMultiplier = 1;
    // To use if there are any object that gives a temporaly multiplier.
    [SerializeField] float savedScoreMultiplier = 1;
    public int initialScore = 0;
    [SerializeField] int currentScore = 0;
    public TextMeshProUGUI scoreText;
    public Transform streaksContainer;
    public TextMeshProUGUI streakPrefab;
    public float streakShowTime = 2f;
    public delegate void GameOverEvent();
    public GameOverEvent OnGameOver;
    public bool isStreakActive = false;
    // Start is called before the first frame update
    private void Start()
    {
        scoreMultiplier = initialScoreMultiplier;
        savedScoreMultiplier = initialScoreMultiplier;
        currentScore = initialScore;
        currentStreak = initialScore;
    }
    public void AddScore(int score)
    {
        currentStreak++;
        currentScore += (int)scoreMultiplier * score;
        scoreText.text = currentScore.ToString();
        if (currentStreak > streakBonus)
        {
            StartCoroutine(ShowStreakEvent());
            isStreakActive = true;
            scoreMultiplier = scoreMultiplier * 1.01f + 1;
        }

    }
    public void RestoreStreak()
    {
        isStreakActive = false;
        currentStreak = initialStreak;
        scoreMultiplier = initialScoreMultiplier;
    }

    private IEnumerator ShowStreakEvent()
    {
        Debug.Log(("STREAK"));
        TextMeshProUGUI streakText = Instantiate(streakPrefab, streaksContainer, false);
        streakText.text = currentStreak.ToString();
        yield return new WaitForSeconds(streakShowTime);
        streakText.text = null;
        Destroy(streakText);
    }
}
