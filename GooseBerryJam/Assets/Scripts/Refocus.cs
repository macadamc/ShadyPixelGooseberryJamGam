using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Refocus : MonoBehaviour
{
    GameObject lastSelectedObject;

    void Update()
    {
        if (EventSystem.current.currentSelectedGameObject == null)
        {
            //Debug.Log("Reselecting first input");
            EventSystem.current.SetSelectedGameObject(lastSelectedObject);
        }
        else if(lastSelectedObject != EventSystem.current.currentSelectedGameObject)
        {
            lastSelectedObject = EventSystem.current.currentSelectedGameObject;
        }
    }
}
