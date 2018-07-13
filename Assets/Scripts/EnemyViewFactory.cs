using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyViewFactory
{
    public List<EnemyView> Views { get; private set; }

    public EnemyViewFactory(int countOfEnemies, GameObject spot)
    {
        Views = new List<EnemyView>();
        var prefabs = Resources.LoadAll<GameObject>("Enemies/");
        while (countOfEnemies > 0)
        {
            foreach (var prefab in prefabs)
            {
                prefab.transform.position = Vector3.zero;
                var instance = UnityEngine.Object.Instantiate(prefab, spot.transform);
                float pos = UnityEngine.Random.Range(-0.5f, 1.5f);
                instance.transform.localPosition = new Vector3(0f, pos, pos);
                Views.Add(instance.GetComponent<EnemyView>());
                countOfEnemies--;
                if (countOfEnemies <= 0)
                    break;
            }
        }
    }
}