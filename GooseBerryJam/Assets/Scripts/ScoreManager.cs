using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ScoreManager : ScriptableObject {

    public IntVariable scoreVar;
    public IntVariable comboVar;

    public void AddPointsCombo(int value)
    {
        scoreVar.value += (value * (1+comboVar.value));
    }

    public void AddPointsFlat(int value)
    {
        scoreVar.value += value;
    }

}
