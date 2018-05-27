using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HeathPickup : Pickup
{
    public IntVariable maxHP;
    public IntVariable score;
    UnityAction useAction;
    public int scoreOnFullHealth;

    public UnityEvent OnPickedUpAtFullHP;
    private void Awake()
    {
        this.useAction += Use;
        this.OnUse.AddListener(useAction);
    }

    void Use ()
    {
        Health hp = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
        if (hp.value < maxHP.value)
        {
            hp.Change(1);
        }
        else
        {
            OnPickedUpAtFullHP.Invoke();
        }
        
    }
}
