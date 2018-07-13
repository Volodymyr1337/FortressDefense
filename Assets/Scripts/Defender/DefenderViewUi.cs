using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DefenderViewUi : MonoBehaviour
{
    [SerializeField] private Slider expBar;
    [SerializeField] private Image Icon;

    private void Awake()
    {

    }

    public void CurrentLevelInitialize(DefenderUnitLevel defenderUnitLevel)
    {
        expBar.maxValue = defenderUnitLevel.ExpToNextLvl;
        Icon.sprite = defenderUnitLevel.UnitSprite;
    }

    public void OnExpChangedHandler(int expVal)
    {
        expBar.value = expVal;
    }

    public void LevelUphandler()
    {

    }
}
