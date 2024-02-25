using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LivesManager : MonoBehaviour
{
    public TextMeshProUGUI gameOverText;
    public LivesManager livesManager
    // Start is called before the first frame update
    void Start()
    {
        handleGameOver = livesManager.OnGameOver++;
    }
    void Disable(){
        handleGameOver = livesManager.OnGameOver--;
    }

    public void handleGameOver(){
        // TODO: Stop fruits from falling
        // TODO: Play luffy dead sound
        // TODO: Play luffy dead animation
        // TODO: Show score and game over screen.
    }

}
