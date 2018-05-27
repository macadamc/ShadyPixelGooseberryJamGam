using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu]
public class FloatingTextManager : ScriptableObject
{
    public GameObject floatingPointsPrefab;
    private string textToDisplay;

    public void SetText(string value)
    {
        textToDisplay = value;
    }
         
    public void CreateFloatingPointsObj(GameObject spawnPosObj)
    {
        GameObject ft = Instantiate(floatingPointsPrefab, GameObject.Find("Manager").transform.Find("WorldSpaceCanvas"));
        ft.transform.position = spawnPosObj.transform.position;
        ft.GetComponent<Text>().text = textToDisplay;
    }
}
