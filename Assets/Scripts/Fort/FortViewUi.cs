using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FortViewUi : MonoBehaviour
{
    [SerializeField] private Slider healthBar;

    public void Inititalization(FortModel fortModel)
    {
        healthBar.maxValue = fortModel.MaxHP;
        healthBar.value = healthBar.maxValue;
    }

    public void SetupCurrentHealth(int fortHp)
    {
        healthBar.value = fortHp;
    }
}
