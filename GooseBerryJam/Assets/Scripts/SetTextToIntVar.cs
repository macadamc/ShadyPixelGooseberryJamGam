using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetTextToIntVar : MonoBehaviour {

    public IntVariable intVar;
    Text textObj;

	// Use this for initialization
	void Start () {
        textObj = GetComponent<Text>();
		
	}
	
	// Update is called once per frame
	void Update () {
        textObj.text = intVar.value.ToString();
		
	}
}
