using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Runtime Sets/Weighted GameObject Runtime Set")]
public class WeightedGameObjectSet : RuntimeSet<WeightedGameObject>
{
    public void Add(GameObject prefab, float weight) { }
    public void Remove() { }

    public GameObject Choose()
    {
        float total = 0;
        foreach(WeightedGameObject wGo in Items)
        {
            total += wGo.weight;
        }

        float randomPoint = Random.value * total;

        for (int i = 0; i < Items.Count; i++)
        {
            if (randomPoint < Items[i].weight)
            {
                return Items[i].obj;
            }
            else
            {
                randomPoint -= Items[i].weight;
            }
        }

        return null;
    }
}
