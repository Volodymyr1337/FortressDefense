using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class AbilityController : MonoBehaviour
{
    [SerializeField] private GameObject AbilitySpotPoint;
    [SerializeField] private AbilityModel[] abilityModels;

    void Start ()
    {
        AbilityItemUiView.OnAbilityUsed += AbilityUsedHandler;
        AbilityItemUiView[] abViews = FindObjectsOfType<AbilityItemUiView>();
        for (var i = 0; i < abilityModels.Length; i++)
        {
            abViews[i].Initialization(abilityModels[i]);
        }
    }
	
	private void AbilityUsedHandler(int abilityId)
    {
        AbilityModel model = abilityModels.FirstOrDefault(ability => ability.Id == abilityId);
        if (model!= null)
        {
            GameObject ability = Instantiate(model.AbilityViewPrefab, AbilitySpotPoint.transform);
            ability.GetComponent<Rigidbody2D>().velocity = new Vector2(-1f, 0f) * Random.Range(3f,6f);
            ability.GetComponent<AbilityView>().Initialization(model.AbilityDamage);
        }
    }
}

[System.Serializable]
public class AbilityModel
{
    public int AbilityDamage;
    public float Delay;
    public int Id;
    public Sprite AbilitySprite;
    public GameObject AbilityViewPrefab;
}
