using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AYellowpaper.SerializedCollections;
using UnityEditor;

public class UIManager : MonoBehaviour
{
    [SerializedDictionary("GameStatus", "GameObject")]
    public SerializedDictionary<GameStatus, GameObject> screens;

    // [SerializedDictionary("Player", "PlayerUI")]
    // public SerializedDictionary<PlayersEnum, PlayerUI> playerUI;
    [SerializeField]
    public PlayerUI playerUI;

    public GameObject gameDataUI;

    TransitionController mainTransition;
    TransitionController secondaryTransition;

    void Start()
    {
        mainTransition.AfterEntryTransitionEvent += ContinueUpdateScreen;
        mainTransition.AfterExitTransitionEvent += ContinueUpdateScreen;
        secondaryTransition.AfterEntryTransitionEvent += ContinueUpdateScreen;
        secondaryTransition.AfterExitTransitionEvent += ContinueUpdateScreen;
    }
    void Disable()
    {

    }

    public void UpdateScore(int score)
    {
        playerUI.score.text = score.ToString();
    }
    public void UpdateLives(int lives)
    {
        playerUI.lives.text = lives.ToString();
    }
    public void UpdateCountdown(int time)
    {
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);
        playerUI.countdown.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void StartScreen(GameStatus gameStatus)
    {
        DeactivateOtherScreens(nextGameStatus);
        screens[nextGameStatus].SetActive(true);
        nextGameStatus = gameStatus;
    }
    private GameStatus nextGameStatus;
    private TransitionController currentTransition;
    public void UpdateScreen(GameStatus gameStatus)
    {
        nextGameStatus = gameStatus;

        if (Array.IndexOf(InGameUI.statusArray, gameStatus) != -1)
        {
            currentTransition = secondaryTransition;
        }
        else
        {
            currentTransition = mainTransition;
        }
        currentTransition.PlayExitTransition(TransitionTypesEnum.CIRCLE);
    }
    public void ContinueUpdateScreen()
    {
        DeactivateOtherScreens(nextGameStatus);
        screens[nextGameStatus].SetActive(true);
        currentTransition.PlayEntryTransition(TransitionTypesEnum.CIRCLE);
        currentTransition = null;
        // if (Array.IndexOf(InGameUI.statusArray, nextGameStatus) != -1)
        // {
        //     secondaryTrasition.SetBool("show", true);
        // }
        // else
        // {
        //     mainTransition.SetBool("show", true);
        // }
    }

    private void DeactivateOtherScreens(GameStatus nextGameStatus)
    {
        HashSet<GameStatus> gameStatusArray = new((GameStatus[])Enum.GetValues(typeof(GameStatus)));
        gameStatusArray.Remove(nextGameStatus);
        foreach (GameStatus gameStatus in gameStatusArray)
        {
            screens[gameStatus].SetActive(false);
        }
    }


    void Restart()
    {
    }
}
