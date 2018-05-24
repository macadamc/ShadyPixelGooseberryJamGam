using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetImageToGradiant : MonoBehaviour {

    public Gradient gradient;
    public Image image;
    public Slider slider;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        SetColor((slider.value/slider.maxValue));
		
	}

    public void SetColor(float value)
    {
        image.color = gradient.Evaluate(value);
    }
}
