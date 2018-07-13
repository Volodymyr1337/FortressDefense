using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityView : MonoBehaviour
{
    [SerializeField] private GameObject explosionPrefab;

    private List<UnitView> listOfAttackedUnits = new List<UnitView>();
    private int abilityDamage;
    private FortView fortView;

    private void Start()
    {
        fortView = FindObjectOfType<FortView>();
        Invoke("Explode", Random.Range(0.9f,1.3f));
    }

    public void Initialization(int abilityDamage)
    {
        this.abilityDamage = abilityDamage;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            var unitview = collision.gameObject.GetComponent<UnitView>();
            if (!listOfAttackedUnits.Contains(unitview))
            {
                listOfAttackedUnits.Add(unitview);
            }
        }
    }

    private void Explode()
    {
        foreach (var units in listOfAttackedUnits)
        {
            units.ReceiveDamage(fortView, abilityDamage);
        }

        var explosion = Instantiate(explosionPrefab);
        explosion.transform.position = transform.position;

        Destroy(gameObject);
    }
}
