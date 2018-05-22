using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TextSetSizeAndRotation : MonoBehaviour {

    Vector2 startPos;
    Text t;
    int startSize;
    public int minFontSize;
    public int maxFontSize;
    public int fontsizeMultiplier;


    // Use this for initialization
    void Awake () {
        t = GetComponent<Text>();
        startSize = t.fontSize;
        startPos = transform.localPosition;
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetValues(IntVariable comboVar)
    {
        SetRandomPosition();
        SetRandomRotation();
        SetSize(comboVar.value);
    }

    public void SetRandomPosition()
    {
        Vector2 randomPos = startPos + Random.insideUnitCircle;
        transform.localPosition = randomPos;
    }

    public void SetRandomRotation()
    {
        transform.eulerAngles = new Vector3(0, 0, Random.Range(-15,15));
    }

    public void SetSize(int mod)
    {
        t.fontSize = Mathf.Clamp(startSize + (mod * fontsizeMultiplier), minFontSize, maxFontSize);
    }
}
