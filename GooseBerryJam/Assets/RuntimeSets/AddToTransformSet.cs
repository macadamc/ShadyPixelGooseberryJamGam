using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddToTransformSet : MonoBehaviour
{
    public TransformRuntimeSet transformRuntimeSet;

    private void OnEnable()
    {
        transformRuntimeSet.Add(transform);
    }

    private void OnDisable()
    {
        transformRuntimeSet.Remove(transform);
    }

}
