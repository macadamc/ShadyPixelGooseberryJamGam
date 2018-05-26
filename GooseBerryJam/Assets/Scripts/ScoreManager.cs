using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu]
public class ScoreManager : ScriptableObject {

    public IntVariable scoreVar;
    public IntVariable comboVar;
    public GameObject floatingPointsPrefab;
    int lastPoints;

    public void AddPointsCombo(int value)
    {
        scoreVar.value += (value * (1+comboVar.value));
        lastPoints = (value * (1 + comboVar.value));
    }

    public void AddPointsFlat(int value)
    {
        scoreVar.value += value;
        lastPoints = value;
    }

    public void CreateFloatingPointsObj(GameObject spawnPosObj)
    {
        GameObject ft = Instantiate(floatingPointsPrefab, GameObject.Find("Manager").transform.Find("WorldSpaceCanvas"));
        ft.transform.position = spawnPosObj.transform.position;
        ft.GetComponent<Text>().text = lastPoints.ToString();
    }
}
