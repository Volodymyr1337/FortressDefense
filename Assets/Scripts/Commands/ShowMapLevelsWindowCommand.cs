using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ShowMapLevelsWindowCommand
{
    private PlayerModel playerModel;
    private Action loadLevelHandler;

    public ShowMapLevelsWindowCommand(PlayerModel playerModel, Action loadLevelhandler)
    {
        this.playerModel = playerModel;
        loadLevelHandler = loadLevelhandler;
    }

    public void Execute()
    {
        MapLevelsWindow mapLevelsWindow = Resources.Load<MapLevelsWindow>("MapLevelsWindow");
        GameObject rootCanvas = GameObject.FindGameObjectWithTag("GameRootCanvas");
        MapLevelsWindow window = UnityEngine.Object.Instantiate(mapLevelsWindow, rootCanvas.transform);
        window.Initialization(playerModel, loadLevelHandler);
    }
}
