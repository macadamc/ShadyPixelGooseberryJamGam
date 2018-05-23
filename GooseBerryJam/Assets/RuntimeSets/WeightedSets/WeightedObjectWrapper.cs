using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeightedObjectWrapper<T> : ScriptableObject
{
    public T obj;
    public int weight;
}
