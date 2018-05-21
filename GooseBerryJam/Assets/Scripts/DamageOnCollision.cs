using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DamageOnCollision : MonoBehaviour
{

    public int damage;
    public UnityEvent OnHit;
    public string ownerTag;
    public float moveStunTime;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == ownerTag)
            return;

        Health hp = collision.gameObject.GetComponent<Health>();
        if(hp != null)
        {
            hp.Change(-damage);
        }

        MovementController mc = collision.gameObject.GetComponent<MovementController>();
        if(mc!=null)
        {
            mc.StunLock(moveStunTime);
        }

        OnHit.Invoke();
    }
}
