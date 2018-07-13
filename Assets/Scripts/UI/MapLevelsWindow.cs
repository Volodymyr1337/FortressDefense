using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class MapLevelsWindow : MonoBehaviour
{
    [SerializeField] private MapLevelWindowItem[] mapLevelWindowItems;
    private Action loadLevelHandler;

    public void Initialization(PlayerModel playerModel, Action loadLevelHandler)
    {
        this.loadLevelHandler = loadLevelHandler;
        for (var i = 0; i < mapLevelWindowItems.Length; i++)
        {
            mapLevelWindowItems[i].Initialization(playerModel, i, loadLevelHandler + CloseWindow);
        }
    }

    public void CloseWindow()
    {
        Destroy(this.gameObject, 0.1f);
    }

    public void BackToMenuBtn()
    {
        SceneManager.LoadScene(0);
    }
}
