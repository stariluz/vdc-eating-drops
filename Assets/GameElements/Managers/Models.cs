using System;
using UnityEngine;
using AYellowpaper.SerializedCollections;

[Serializable]
public class PlayerUI
{
    [SerializeField] public TMPro.TMP_Text score;
    [SerializeField] public TMPro.TMP_Text lives;
    [SerializeField] public TMPro.TMP_Text countdown;
}

public class InGameUI
{
    public static GameStatus[] statusArray ={
        GameStatus.GAME_OVER_SCREEN,
        GameStatus.IN_PLAY,
        GameStatus.PAUSE_SCREEN,
        GameStatus.TIME_OUT_SCREEN,
        GameStatus.WIN_SCREEN
    };
}