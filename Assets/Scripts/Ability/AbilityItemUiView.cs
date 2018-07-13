using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class AbilityItemUiView: MonoBehaviour
{
    [SerializeField] private int abilityId;
    [SerializeField] private Image cdImg;
    [SerializeField] private Image abilityImg;
    private float Cooldown;
    private float Delay;
    private bool Active;
    public static event Action<int> OnAbilityUsed = (id)=> { };

    public void Initialization(AbilityModel abilityModel)
    {
        abilityId = abilityModel.Id;
        abilityImg.sprite = abilityModel.AbilitySprite;
        Cooldown = abilityModel.Delay;
        Delay = Cooldown;
        Active = true;
        cdImg.enabled = false;
    }

    public void UseButton()
    {
        if (Active)
        {
            OnAbilityUsed(abilityId);
            StartCoroutine(TimerTick());
        }
    }

    private IEnumerator TimerTick()
    {
        Active = false;
        cdImg.enabled = true;
        while (Cooldown > 0)
        {
            Cooldown -= Time.deltaTime;
            yield return null;
        }
        Cooldown = Delay;
        cdImg.enabled = false;
        Active = true;
    }

}
