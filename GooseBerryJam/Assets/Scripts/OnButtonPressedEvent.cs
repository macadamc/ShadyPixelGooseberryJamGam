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

    public float timeBeforeAcceptInput = 1f;
    public float acceptInputTime;

    public List<ButtonEventInfo> buttonEvents = new List<ButtonEventInfo>();

    private void OnEnable()
    {
        acceptInputTime = Time.time + timeBeforeAcceptInput;
    }

    // Update is called once per frame
    void Update ()
    {
        if (Time.time <= acceptInputTime)
            return;

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
