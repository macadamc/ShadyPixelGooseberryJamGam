using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetTextToFloatVar : MonoBehaviour {

    public FloatVariable floatVar;
    public string prefix;
    Text textObj;

	// Use this for initialization
	void Start () {
        textObj = GetComponent<Text>();
		
	}
	
	// Update is called once per frame
	void Update () {

        textObj.text = prefix + floatVar.value.ToString("#.0");
		
	}
}
