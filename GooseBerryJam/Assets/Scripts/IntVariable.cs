using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Variables/New Int Variable")]
public class IntVariable : ScriptableObject
{
    public int value;

    public void ApplyChange(int change)
    {
        value += change;
    }

    public void SetValue(int newValue)
    {
        value = newValue;
    }
}
