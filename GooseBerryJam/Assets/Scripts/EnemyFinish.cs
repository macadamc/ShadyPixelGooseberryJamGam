using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyFinish : MonoBehaviour {

    public UnityEvent onEnemyFinish;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);
            onEnemyFinish.Invoke();
        }
    }

}
