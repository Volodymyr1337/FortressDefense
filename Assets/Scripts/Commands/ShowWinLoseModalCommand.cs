using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ShowWinLoseModalCommand
{
    private LevelModel levelModel;
    private bool won;
    private Action onOkBtnPressed;

    public ShowWinLoseModalCommand(bool won, LevelModel levelModel)
    {
        this.levelModel = levelModel;
        this.won = won;
    }

    public void Execute()
    {
        WinLoseModalWindow window = Resources.Load<WinLoseModalWindow>("WinLoseModalWindow");
        GameObject rootCanvas = GameObject.FindGameObjectWithTag("GameRootCanvas");
        var win = UnityEngine.Object.Instantiate(window, rootCanvas.transform);
        win.InitializeWindow(won, levelModel);
    }
}
