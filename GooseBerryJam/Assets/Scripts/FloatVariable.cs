using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Variables/New Float Variable")]
public class FloatVariable : ScriptableObject
{
    public float value;

    public void ApplyChange(float change)
    {
        value += change;
    }

    public void SetValue(float newValue)
    {
        value = newValue;
    }
}
