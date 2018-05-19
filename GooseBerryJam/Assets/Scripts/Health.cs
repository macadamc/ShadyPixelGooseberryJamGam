using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public int value;

    public UnityEvent OnHurt;
    public UnityEvent OnDeath;

    SpriteRenderer rend;
    bool flashing;

    private void Awake()
    {
        rend = GetComponentInChildren<SpriteRenderer>();
    }

    public void Change(int change)
    {
        if (flashing && change < 0)
            return;

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
