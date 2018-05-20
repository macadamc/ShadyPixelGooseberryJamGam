using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DamageOnCollision : MonoBehaviour
{

    public int damage;
    public UnityEvent OnHit;
    public string ownerTag;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == ownerTag)
            return;

        Health hp = collision.gameObject.GetComponent<Health>();
        if(hp != null)
        {
            hp.Change(-damage);
        }
        OnHit.Invoke();
    }
}
