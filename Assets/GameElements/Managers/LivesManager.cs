using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LivesManager : MonoBehaviour
{
    public int initialLives = 3;
    public int currentLives = 3;
    public TextMeshProUGUI lives;
     public delegate void GameOverEvent(); 
    public GameOverEvent OnGameOver;
    // Start is called before the first frame update
    void Start()
    {
        lives.text = initialLives.ToString();
        currentLives = initialLives;
    }

    public void LoseLives(int lostLives){
        if(currentLives==0){
            GameOver();
        }
        lostLives = lostLives > currentLives ? currentLives : lostLives;
        currentLives -= lostLives;
        Debug.Log((currentLives, lostLives));

        lives.text = currentLives.ToString();
    }

    public void GameOver(){
        OnGameOver?.Invoke();
    }
}
