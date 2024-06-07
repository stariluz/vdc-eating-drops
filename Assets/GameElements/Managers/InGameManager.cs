using System;
using System.Collections;
using System.Collections.Generic;
using Stariluz.GameLoop;
using UnityEditor;
using UnityEngine;

public class InGameManager : MonoBehaviour, IGameElement
{

    public Countdown countdown;
    public delegate void UpdateTimeEvent(int time);
    public UpdateTimeEvent OnUpdateTime;
    
    public ScoreManager scoreManager;
    public DropSpawner dropSpawner;
    public LivesManager livesManager;
    public PlayerManager player;
    void Disable()
    {
        livesManager.OnGameOver -= HandleGameOver;
        countdown.OnUpdateTime -= UpdateTime;
    }
    public void StartGamePlay()
    {
        player.movement.StartGamePlay();
        player.collisionsController.OnCollisionWithEdibleDrop += PositiveScore;
        player.collisionsController.OnCollisionWithNastyDrop += NegativeScore;
        livesManager.OnGameOver += HandleGameOver;
        countdown.OnUpdateTime += UpdateTime;
        dropSpawner.StartGamePlay();
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
        throw new NotImplementedException();
        // dropSpawner.Restart();
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

    public void HandleGameOver()
    {
        dropSpawner.Stop();
        countdown.Stop();
    }

    public void StopGamePlay()
    {
        throw new System.NotImplementedException();
    }

    public void RestartGamePlay()
    {
        throw new System.NotImplementedException();
    }

    private void PositiveScore(DropController drop)
    {
        scoreManager.AddScore(drop.GetComponentInParent<DropController>().score);
        dropSpawner.UnregisterDrop(drop.GetComponentInParent<DropController>());
    }
    private void NegativeScore(DropController drop)
    {
        
        scoreManager.RestoreStreak();
        livesManager.LoseLives(1);
        // dropSpawner.UnregisterDrop(collider.GetComponentInParent<DropLogic>());
    }

}
