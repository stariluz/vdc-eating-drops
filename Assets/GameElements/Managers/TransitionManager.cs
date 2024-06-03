using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AYellowpaper.SerializedCollections;
using UnityEditor;

public class TransitionManager : MonoBehaviour
{
    public delegate void AfterTransitionEvent();
    public AfterTransitionEvent AfterMainShowEvent;
    public AfterTransitionEvent AfterMainHideEvent;

    public AfterTransitionEvent AfterSecondaryShowEvent;
    public AfterTransitionEvent AfterSecondaryHideEvent;
    public void AfterMainShow()
    {
        AfterMainShowEvent?.Invoke();
    }

    public void AfterMainHide(GameStatus gameStatus)
    {
        AfterMainHideEvent?.Invoke();
    }
    public void AfterSecondaryShow(PlayersEnum player)
    {
        AfterSecondaryShowEvent?.Invoke();
    }

    public void AfterSecondaryHide(GameStatus gameStatus)
    {
        AfterSecondaryHideEvent?.Invoke();
    }


}
