using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu]
public class ScoreManager : ScriptableObject {

    public IntVariable scoreVar;
    public IntVariable comboVar;
    public FloatingTextManager FloatingTextManager;

    public void AddPointsCombo(int value)
    {
        scoreVar.value += (value * (1+comboVar.value));
        FloatingTextManager.SetText((value * (1 + comboVar.value)).ToString());
    }

    public void AddPointsFlat(int value)
    {
        scoreVar.value += value;
        FloatingTextManager.SetText(value.ToString());
    }

    
}
