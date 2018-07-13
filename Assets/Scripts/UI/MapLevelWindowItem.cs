using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class MapLevelWindowItem : MonoBehaviour
{
    [SerializeField] private Image FlagIcon;

    [SerializeField] private Sprite availableLevel;
    [SerializeField] private Sprite[] doneLevel;
    [SerializeField] private Sprite lockedLevel;

    private int level;
    private bool isAvailable;

    public Action onLoadLevelPressed;

    public void Initialization(PlayerModel playerModel, int level, Action onLoadLevelPressed)
    {
        this.onLoadLevelPressed = onLoadLevelPressed;
        this.level = level;
        isAvailable = level == playerModel.CurrentMapLevel;

        if (playerModel.DoneLevelsProgress.ContainsKey(level))
            FlagIcon.sprite = doneLevel[playerModel.DoneLevelsProgress[level]];
        else if (isAvailable)
            FlagIcon.sprite = availableLevel;
        else
            FlagIcon.sprite = lockedLevel;
    }

    public void LoadLevelButtonPress()
    {
        if (!isAvailable)
            return;

        onLoadLevelPressed?.Invoke();
    }
}
