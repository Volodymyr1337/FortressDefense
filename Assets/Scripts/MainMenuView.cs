using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MainMenuView: MonoBehaviour
{
    public static event Action OnQuitGame;
    public static event Action OnLoadLevel;


    public void QuitBtn()
    {
        OnQuitGame();
    }
    public void LoadLevelBtn()
    {
        OnLoadLevel();
    }

}
