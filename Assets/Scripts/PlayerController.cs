using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerController
{
    public PlayerModel PlayerModel;

	public PlayerController(PlayerModel playerModel)
    {
        PlayerModel = playerModel;

        Initialization();
    }

    private void Initialization()
    {
        if (!PlayerPrefs.HasKey(PrefsState.CurrentMapLevel.ToString()))
            PlayerPrefs.SetInt(PrefsState.CurrentMapLevel.ToString(), 0);
        
        PlayerModel.CurrentMapLevel = PlayerPrefs.GetInt(PrefsState.CurrentMapLevel.ToString());
        if (PlayerPrefs.HasKey(PrefsState.DoneLevelsIds.ToString()) && PlayerPrefs.HasKey(PrefsState.DoneLevelProgress.ToString()))
        {
            string[] lvlIds = PlayerPrefs.GetString(PrefsState.DoneLevelsIds.ToString()).Split(',');
            string[] lvlsStars = PlayerPrefs.GetString(PrefsState.DoneLevelProgress.ToString()).Split(',');

            for (var i = 0; i < lvlIds.Length; i++)
                PlayerModel.DoneLevelsProgress.Add(int.Parse(lvlIds[i]), int.Parse(lvlsStars[i]));
        }
    }

    public void OnLevelClearedHandler(LevelModel levelModel)
    {
        int starCount = Mathf.CeilToInt(4f * levelModel.CurrentScore / levelModel.MaxScore) - 1;
        new ShowWinLoseModalCommand(true, levelModel).Execute();
        PlayerModel.DoneLevelsProgress.Add(PlayerModel.CurrentMapLevel, starCount);

        string levels = "";
        string stars = "";
        if (PlayerPrefs.HasKey(PrefsState.DoneLevelsIds.ToString()) && PlayerPrefs.HasKey(PrefsState.DoneLevelProgress.ToString()))
        {
            levels = PlayerPrefs.GetString(PrefsState.DoneLevelsIds.ToString()) + ",";
            stars = PlayerPrefs.GetString(PrefsState.DoneLevelProgress.ToString()) + ",";
        }
        levels += PlayerModel.CurrentMapLevel;
        stars += starCount;
        PlayerPrefs.SetString(PrefsState.DoneLevelsIds.ToString(), levels);
        PlayerPrefs.SetString(PrefsState.DoneLevelProgress.ToString(), stars);

        PlayerModel.CurrentMapLevel++;
        PlayerPrefs.SetInt(PrefsState.CurrentMapLevel.ToString(), PlayerModel.CurrentMapLevel);
        
    }
}

[Serializable]
public class PlayerModel
{
    public int CurrentMapLevel;
    public int[] DefendersLevel;
    public Dictionary<int, int> DoneLevelsProgress;

    public PlayerModel()
    {
        DoneLevelsProgress = new Dictionary<int, int>();
    }
}