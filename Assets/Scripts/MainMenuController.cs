using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController: MonoBehaviour
{

    private void Awake()
    {
        MainMenuView.OnQuitGame += LeaveGame;
        MainMenuView.OnLoadLevel += LoadGame;
    }

    public void LoadGame()
    {
        SceneManager.LoadScene(1);
    }

    public void LeaveGame()
    {
        Application.Quit();
    }
}
