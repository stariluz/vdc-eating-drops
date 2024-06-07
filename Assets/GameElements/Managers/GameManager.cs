using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using AYellowpaper.SerializedCollections;
using Stariluz.GameLoop;

public class GameManager : MonoBehaviour, IGameElement
{
    public GameStatus gameStatus = GameStatus.START_SCREEN;
    public AudioManager audioManager;
    public UIManager uiManager;
    public InGameManager inGameManager;

    // Start is called before the first frame update
    void Start()
    {
        StartGame();
    }
    public void StartGame()
    {
        uiManager.StartScreen(GameStatus.START_SCREEN);
    }
    public void RestartGame()
    {
        inGameManager.RestartGame();
        uiManager.UpdateScreen(GameStatus.START_SCREEN);
    }
    public void StartGamePlay()
    {
        inGameManager.StartGamePlay();
        uiManager.UpdateScreen(GameStatus.IN_PLAY);
        audioManager.StartGamePlay();
    }
    public void Pause()
    {
        gameStatus = GameStatus.PAUSE_SCREEN;
        uiManager.UpdateScreen(gameStatus);
        inGameManager.Pause();
        audioManager.Pause();
    }

    public void Resume()
    {
        gameStatus = GameStatus.IN_PLAY;
        uiManager.UpdateScreen(gameStatus);
        inGameManager.Resume();
        audioManager.Resume();
    }

    // public void StartGameLevel()
    // {
    //     InitBoard();
    //     RestartBoard();
    // }
    // public void InitBoard()
    // {
    //     gameStatus = GameStatus.IN_PLAY;
    //     uiManager.UpdateScreen(gameStatus);
    // }
    // public void RestartBoard()
    // {
    //     uiManager.UpdateLives(player.lives);
    // }

    // public int Score()
    // {
    //     Debug.Log((player, audioManager));
    //     audioManager.OnScore();
    //     int score = player.score;
    //     if (gameStatus == GameStatus.IN_PLAY)
    //     {
    //         score++;
    //         player.score = score;
    //         uiManager.UpdateScore(score);
    //         // if (levelsManager.IsLevelCompleted())
    //         // {
    //         //     Win(player);
    //         // }
    //     }
    //     return score;
    // }

    // public void LoseLive()
    // {
    //     if (gameStatus == GameStatus.IN_PLAY)
    //     {
    //         bool hasLost = player.LoseLive();
    //         if (hasLost)
    //         {
    //             GameOver();
    //         }
    //         else
    //         {
    //             // TODO: Cooldown
    //             uiManager.UpdateLives(player.lives);
    //             NextAttempt();
    //         }
    //     }
    // }

    public void UpdateTime(int time)
    {
        uiManager.UpdateCountdown(time);
    }

    public void TimeOut()
    {
        audioManager.OnGameOver();
        gameStatus = GameStatus.TIME_OUT_SCREEN;
        uiManager.UpdateScreen(gameStatus);
    }
    public void GameOver()
    {
        audioManager.OnGameOver();
        inGameManager.countdown.Stop();
        gameStatus = GameStatus.GAME_OVER_SCREEN;
        uiManager.UpdateScreen(gameStatus);
    }

    public void Win()
    {
        audioManager.OnGameWin();
        inGameManager.countdown.Stop();
        gameStatus = GameStatus.WIN_SCREEN;
        uiManager.UpdateScreen(gameStatus);
    }

    public void StopGamePlay()
    {
        throw new NotImplementedException();
    }
}
