using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Knockback : MonoBehaviour
{
    public float knockback;
    public UnityEvent OnHit;
    public string ownerTag;
    public float moveStunTime;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == ownerTag)
            return;

        MovementController mc = collision.gameObject.GetComponent<MovementController>();
        if (mc != null)
        {
            mc.StunLock(moveStunTime);

            Vector2 k = (collision.gameObject.transform.position - transform.position).normalized * knockback;
            k.x = k.x * 10f;
            mc.AddKnockback(k);
        }

        OnHit.Invoke();
    }
}
