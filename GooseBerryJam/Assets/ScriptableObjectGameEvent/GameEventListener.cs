using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameEventListener : MonoBehaviour
{
    [Tooltip("Event to register with.")]
    public List<GameEvent> Events = new List<GameEvent>();

    [Tooltip("Response to invoke when Event is raised.")]
    public UnityEvent Response;


    private void OnEnable()
    {
        foreach (GameEvent gameEvent in Events)
            gameEvent.RegisterListener(this);
    }

    private void OnDisable()
    {
        foreach (GameEvent gameEvent in Events)
            gameEvent.UnregisterListener(this);
    }

    public void OnEventRaised()
    {
        Response.Invoke();
    }

}
