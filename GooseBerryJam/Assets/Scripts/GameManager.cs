using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public UnityEvent onEnableEvent;

    private void OnEnable()
    {
        onEnableEvent.Invoke();
    }

}
