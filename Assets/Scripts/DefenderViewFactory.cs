using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderViewFactory
{
    public List<DefenderView> Views { get; private set; }

    public DefenderViewFactory(GameObject[] spots)
    {
        Views = new List<DefenderView>();
        GameObject prefab = Resources.Load<GameObject>("Defenders/DefenderUnitPrefab");
        foreach (var spot in spots)
        {
            prefab.transform.position = Vector3.zero;
            var instance = UnityEngine.Object.Instantiate(prefab, spot.transform);
            Views.Add(instance.GetComponent<DefenderView>());
        }
    }
}
