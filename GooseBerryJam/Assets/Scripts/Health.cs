using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public int value;

    public UnityEvent OnHurt;
    public UnityEvent OnDeath;

    public void Change(int change)
    {
        value += change;

        if (value <= 0)
            OnDeath.Invoke();
        else if (change < 0)
            OnHurt.Invoke();
    }
}
