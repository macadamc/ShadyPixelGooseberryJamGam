using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DamageOnCollision : MonoBehaviour {

    public int damage;
    public UnityEvent OnHit;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Health hp = collision.gameObject.GetComponent<Health>();
        if(hp != null)
        {
            hp.Change(-damage);
        }
        OnHit.Invoke();
    }
}
