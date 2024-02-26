using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    public TextMeshProUGUI gameOverText;
    public LivesManager livesManager;
    // Start is called before the first frame update
    void Start()
    {
        livesManager.OnGameOver+=HandleGameOver;
    }
    void Disable(){
        livesManager.OnGameOver -= HandleGameOver;
    }

    public void HandleGameOver(){
        // TODO: Stop fruits from falling
        // TODO: Play luffy dead sound
        // TODO: Play luffy dead animation
        // TODO: Show score and game over screen.
        Debug.Log(gameOverText);
    }

}
