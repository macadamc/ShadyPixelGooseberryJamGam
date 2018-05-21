using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnButtonPressedEvent : MonoBehaviour {

    [System.Serializable]
    public class ButtonEventInfo
    {
        public string buttonName;
        public UnityEvent OnPressedEvent;
        public bool pressed;
    }

    public List<ButtonEventInfo> buttonEvents = new List<ButtonEventInfo>();


	// Update is called once per frame
	void Update ()
    {
		foreach(ButtonEventInfo buttonEvent in buttonEvents)
        {
            if (Input.GetButtonDown(buttonEvent.buttonName) && !buttonEvent.pressed)
            {
                buttonEvent.OnPressedEvent.Invoke();
                buttonEvent.pressed = true;
            }
        }
	}
}
