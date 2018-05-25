using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;



public class Pickup : MonoBehaviour
{
    public UnityEvent OnUse;


    public virtual void ActivatePickup()
    {
        OnUse.Invoke();
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            ActivatePickup();
        }
        
    }
}
