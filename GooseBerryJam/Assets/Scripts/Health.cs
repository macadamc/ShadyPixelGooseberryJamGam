using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public int value;
    public IntVariable intVarToSet;
    public UnityEvent OnHurt;
    public UnityEvent OnDeath;

    SpriteRenderer rend;
    bool flashing;

    private void Awake()
    {
        rend = GetComponentInChildren<SpriteRenderer>();

        if (intVarToSet)
            intVarToSet.value = value;
    }

    public void Change(int change)
    {
        value += change;

        if(value <= 0)
        {
            OnDeath.Invoke();
            return;
        }

        if (change < 0)
        {
            StartCoroutine(DamageFlash(2));
            OnHurt.Invoke();
        }

        if (intVarToSet)
            intVarToSet.value = value;
    }
    public void Set(int value)
    {
        this.value = value;
        if (value <= 0)
        {
            OnDeath.Invoke();
            return;
        }
        else
        {
            StartCoroutine(DamageFlash(2));
            OnHurt.Invoke();
        }

        if (intVarToSet)
            intVarToSet.value = value;
    }

    public IEnumerator DamageFlash(int flashes)
    {
        flashing = true;
        for (int i = 0; i < flashes; i++)
        {
            rend.enabled = false;
            yield return new WaitForSeconds(0.1f);
            rend.enabled = true;
            yield return new WaitForSeconds(0.1f);
        }
        flashing = false;
        yield return null;
    }
}
