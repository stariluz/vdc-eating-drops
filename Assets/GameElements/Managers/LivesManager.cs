using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LivesManager : MonoBehaviour
{
    public int initialLives = 3;
    public int currentLives = 3;

    public TextMeshPro lives;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void LoseLives(int lostLives){
        lostLives = lostLives > currentLives ? currentLives : lostLives;
        currentLives -= lostLives;

        lives.text = lostLives.ToString();
    }
}
