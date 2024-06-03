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
    [SerializeFIeld]
    public PlayerUI playerUI;

    public GameObject gameDataUI;

    TransitionManager transitionManager;
    public Animator mainTransition;
    public Animator secondaryTrasition;

    void Start()
    {
        transitionManager.AfterMainShowEvent += ContinueUpdateScreen;
        transitionManager.AfterMainHideEvent += ContinueUpdateScreen;
        transitionManager.AfterSecondaryShowEvent += ContinueUpdateScreen;
        transitionManager.AfterSecondaryHideEvent += ContinueUpdateScreen;
    }
    void Disable()
    {

    }
    // public TMPro.TMP_Text winnerText;
    // Start is called before the first frame update

    public Tuple<PlayersEnum, int> UpdateScore(PlayersEnum player, int score)
    {
        playerUI[player].score.text = score.ToString();
        return new(player, score);
    }
    public Tuple<PlayersEnum, int> UpdateLives(PlayersEnum player, int lives)
    {
        playerUI[player].lives.text = lives.ToString();
        return new(player, lives);
    }
    public Tuple<PlayersEnum, int> UpdateCountdown(PlayersEnum player, int time)
    {
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);
        playerUI[player].countdown.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        return new(player, time);
    }

    public void ShowWinner(PlayersEnum player)
    {
        UpdateScreen(GameStatus.WIN_SCREEN);
    }

    public void StartScreen(GameStatus gameStatus)
    {
        DeactivateOtherScreens(nextGameStatus);
        screens[nextGameStatus].SetActive(true);
        nextGameStatus = gameStatus;
        secondaryTrasition.SetBool("show", true);
        secondaryTrasition.SetBool("show", true);
    }
    private GameStatus nextGameStatus;
    public void UpdateScreen(GameStatus gameStatus)
    {
        nextGameStatus = gameStatus;

        if (Array.IndexOf(InGameUI.statusArray, gameStatus) != -1)
        {
            secondaryTrasition.SetBool("show", false);
        }
        else
        {
            mainTransition.SetBool("show", false);
        }
    }
    public void ContinueUpdateScreen()
    {
        DeactivateOtherScreens(nextGameStatus);
        screens[nextGameStatus].SetActive(true);

        if (Array.IndexOf(InGameUI.statusArray, nextGameStatus) != -1)
        {
            secondaryTrasition.SetBool("show", true);
        }
        else
        {
            mainTransition.SetBool("show", true);
        }
    }

    private void DeactivateOtherScreens(GameStatus nextGameStatus)
    {
        // Debug.Log(("DEV -DeactivatingScreens"));
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
