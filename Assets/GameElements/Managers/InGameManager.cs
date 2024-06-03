using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class InGameManager : MonoBehaviour
{

    public Countdown countdown;
    public delegate void UpdateTimeEvent(int time);
    public UpdateTimeEvent OnUpdateTime;
    public DropSpawner dropSpawner;
    public LivesManager livesManager;
    void StartGamePlay(){
        livesManager.OnGameOver+=HandleGameOver;
        countdown.OnUpdateTime+=UpdateTime;
        dropSpawner.StartGamePlay();
    }
    void Disable()
    {
        livesManager.OnGameOver -= HandleGameOver;
        countdown.OnUpdateTime-=UpdateTime;
    }
    public void UpdateTime(int time)
    {
        OnUpdateTime?.Invoke(time);
    }

    public void End()
    {
        dropSpawner.Stop();
    }
    public void RestartGame()
    {
        dropSpawner.Restart();
    }
    public void Pause()
    {
        dropSpawner.Pause();
        countdown.Pause();
    }
    public void Resume()
    {
        dropSpawner.Pause();
        countdown.Resume();
    }

    public void HandleGameOver(){
        dropSpawner.Stop();
        countdown.Stop();
    }
}
