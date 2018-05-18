using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MainMenuManager : MonoBehaviour {

    public UnityEvent OnFire1Pressed;
    bool pressed;


	// Update is called once per frame
	void Update () {
		
        if(Input.GetButtonDown("Fire1") && !pressed)
        {
            OnFire1Pressed.Invoke();
            pressed=true;
        }

	}
}
