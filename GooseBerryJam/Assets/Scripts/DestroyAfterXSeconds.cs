using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterXSeconds : MonoBehaviour {

    public float lifeSpan  = 1f;

	void Update ()
    {
        lifeSpan -= Time.deltaTime;

        if (lifeSpan <= 0)
            Destroy(gameObject);
	}

    public void ForceDestroy()
    {
        Destroy(gameObject);
    }
}
