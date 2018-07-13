using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameController : MonoBehaviour
{
    private PlayerController PlayerController;
    [SerializeField]
    private LevelController LevelController;

    private void Awake()
    {
       // PlayerPrefs.DeleteAll();

        PlayerController = new PlayerController(new PlayerModel());
        LevelController.OnLevelCleared += OnLevelClearedHandler;
        WinLoseModalWindow.OnOkBtnPressed += ShowMapLevelWindow;
    }

    private void Start()
    {
        ShowMapLevelWindow();
    }
    
    private void OnLevelClearedHandler()
    {
        if (PlayerController.PlayerModel.CurrentMapLevel < LevelController.LevelModels.Length)
        {
           
            PlayerController.OnLevelClearedHandler(LevelController.LevelModels[PlayerController.PlayerModel.CurrentMapLevel]);
        }
    }

    private void ShowMapLevelWindow()
    {
        new ShowMapLevelsWindowCommand(PlayerController.PlayerModel, OnStartLevelClick).Execute();
    }

    private void OnStartLevelClick()
    {
        LevelController.InitCurrentLevel(PlayerController.PlayerModel.CurrentMapLevel);
    }
}

