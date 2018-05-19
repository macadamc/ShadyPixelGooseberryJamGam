using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyState : MonoBehaviour
{
    public UnityEvent onStartEvent;
    public UnityEvent onEndEvent;
    [HideInInspector]
    public InputController ic;

    public virtual void OnEnable()
    {
        ic = GetComponent<InputController>();
        onStartEvent.Invoke();
    }

    public virtual void Update()
    {

    }

    public virtual void OnDisable()
    {
        onEndEvent.Invoke();
    }

    public void Transition(EnemyState state)
    {
        enabled = false;
        state.enabled = true;

    }

}
